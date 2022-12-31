using Core.Common.Model.General;
using Core.Common.Util.Helper.API;
using Core.Common.Util.Helper.Autenticacion;
using Core.Common.Util.Helper.Internal;
using Core.Creditos.Adapters.Core.Originarsa;
using Core.Creditos.Adapters.Core.Originarsa.Models;
using Core.Creditos.Adapters.Core.Seguridades;
using Core.Creditos.Adapters.HtmlConverter;
using Core.Creditos.DataAccess.General;
using Core.Creditos.DataAccess.Parametrizacion;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Helpers;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.Entidad.Usuarios;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Core.Creditos.DataAccess.Plantillas;

namespace Core.Creditos.Adapters.Core.Notificaciones
{
    /// <summary>
    /// Clase para el uso de Core.Notificaciones
    /// </summary>
    public static class EnviarNotificacionCorreoADP
    {
        private static string URLBASE = SettingsHelper.ObtenerSettigsKey("UrlBaseAdapters.CoreNotificaciones");

        private const string _EnviarNotificacion = "/api/Correos/EnviarCorreo";

        /// <summary>
        /// Metodo para agregar un correo a la cola de envío
        /// </summary>
        /// <param name="correoDestino">correo o correos separados por coma</param>
        /// <param name="asunto"></param>
        /// <param name="contenido"></param>
        /// <param name="nombreArchivo"></param>
        /// <param name="encodeBytes"></param>
        private static void AgregarCorreo(string correoDestino, string asunto, string contenido,string? nombreArchivo, string? encodeBytes)
        {
            dynamic postBody = new ExpandoObject();
            postBody.correosDestino = correoDestino;
            postBody.asunto = asunto;
            postBody.contenido = contenido;
            postBody.nombreArchivo = nombreArchivo;
            postBody.encodeBytes = encodeBytes;

            var jsonBody = JsonConvert.SerializeObject(postBody);

            using (var httpClient = new HttpClient())
            {
                var x = $"{URLBASE}{_EnviarNotificacion}";
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{URLBASE}{_EnviarNotificacion}"))
                {
                    request.Content = new StringContent(jsonBody);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = httpClient.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
                }
            }
        }

        /// <summary>
        /// Envía un correo de asignación
        /// </summary>
        /// <param name="responsable">usuariored</param>
        /// <param name="numeroSolicitud">numerosolicitud</param>
        public static void EnviarCorreoAsignacion(string responsable, string numeroSolicitud)
        {

            var usuario = CoreSeguridadesADP.ObtenerInformacionBaseUsuario(responsable).Result;

            if (usuario == null)
            {
                LogHelper.EscribirLog("EnviarCorreoAsignacion", $"{responsable} - {numeroSolicitud}", "Core.Creditos.Adapters.EnviarCorreo", responsable, TipoMensajeLog.Error);
                return;
            }
            var usuarioCo = new UsuarioCO()
            {
                Correo = usuario.CorreoElectronico,
                UsuarioRed = usuario.NombreRed,
                Nombre = $"{usuario.Nombres} {usuario.Apellidos}",                
                Id = usuario.Id,
            };
            ArmarEstructuraCorreo(usuarioCo, numeroSolicitud);
        }

        /// <summary>
        /// Arma la estrutura de un correo en base a la información obtenida de core.originarsa
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="numeroSolicitud"></param>
        public static void ArmarEstructuraCorreo(UsuarioCO usuario, string numeroSolicitud)
        {
            var informacionSolicitud = ObtenerInformacionCreditosDAL.Execute(numeroSolicitud);

            var codigoPlantilla = ObtenerParametrizacionCreditosDAL.Execute(ParametrizacionCreditos.PLANTILLA_ENVIO_SOLICITUD_CREDITO).Valor;
            var plantilla = ObtenerPlantillaEmailDAL.Execute(codigoPlantilla);

            string asunto = plantilla.Asunto.Inject(informacionSolicitud).ToUpper();
            string contenido = plantilla.Cuerpo;
            string token = GenerarToken(usuario, numeroSolicitud);
            string destinatario = usuario.Correo;

            contenido = contenido.Inject(usuario);
            contenido = contenido.Inject(informacionSolicitud);
            contenido = contenido.Inject(informacionSolicitud?.InformacionVehiculo);
            contenido = contenido.Inject(informacionSolicitud.InformacionCliente);
            informacionSolicitud.InformacionConyuge = (informacionSolicitud.InformacionConyuge == null) ? new ObtenerInformacionCreditosDAL.InformacionConyuge() : informacionSolicitud.InformacionConyuge;
            contenido = contenido.Inject(informacionSolicitud?.InformacionConyuge);
            contenido = contenido.Replace("{token}", token);


            
            var fileName = $"{numeroSolicitud}_SolicitudCredito_{informacionSolicitud.NombreConcesionario}.pdf";
            var ruta = ObtenerParametrizacionCreditosDAL.Execute(ParametrizacionCreditos.RUTA_ARCHIVOS_TEMPORALES).Valor;
            var fullPath = $"{ruta}\\{fileName}";            
            HtmlToPdfADP.ConvertHtmlStringToPdf(contenido, fullPath);
            string encodeFile = GetUrlEncodeFromFile(fullPath);

            AgregarCorreo(destinatario, asunto, contenido,fileName,encodeFile);
        }

        /// <summary>
        /// Encripta los links de acceso
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string GetUrlEncodeFromFile(string fileName)
        {
            byte[] file;
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }

            ///METODO PARA ENCRIPTAR
            char[] padding = { '=' };
            string returnValue = Convert.ToBase64String(file).TrimEnd(padding).Replace('+', '-').Replace('/', '_');
            return returnValue;
        }

        /// <summary>
        /// Genera los tokens de acceso
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="numeroSolicitud"></param>
        /// <returns></returns>
        private static string GenerarToken(UsuarioCO usuario, string numeroSolicitud)
        {
            var fechaExpiracion = DateTime.Now.AddDays(10);
            var token = $"{usuario.UsuarioRed};{numeroSolicitud};{fechaExpiracion}";
            return ConvertStringToHex(token, Encoding.Unicode);
        }

        /// <summary>
        /// Convierte los tokens a HEX para que sean admitidos en la URL
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ConvertStringToHex(String input, System.Text.Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }
    }
}
