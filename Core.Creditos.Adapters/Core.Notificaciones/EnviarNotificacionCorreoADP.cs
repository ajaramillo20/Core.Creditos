using Core.Common.Model.General;
using Core.Common.Util.Helper.API;
using Core.Common.Util.Helper.Autenticacion;
using Core.Common.Util.Helper.Internal;
using Core.Creditos.Adapters.Core.Originarsa;
using Core.Creditos.Adapters.Core.Originarsa.Models;
using Core.Creditos.DataAccess.General;
using Core.Creditos.DataAccess.Parametrizacion;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Helpers;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.Entidad.Usuarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Core.Creditos.Adapters.Core.Notificaciones
{
    public static class EnviarNotificacionCorreoADP
    {
        private static string URLBASE = SettingsHelper.ObtenerSettigsKey("UrlBaseAdapters.CoreNotificaciones");

        private const string _EnviarNotificacion = "/Correos/EnviarCorreo";
        private static void AgregarCorreo(string correoDestino, string asunto, string contenido)
        {
            dynamic postBody = new ExpandoObject();
            postBody.correosDestino = "csilva@originarsa.com;ajaramillo@originarsa.com;pmejia@originarsa.com";
            postBody.asunto = asunto;
            postBody.contenido = contenido;

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

        public static void EnviarCorreoAsignacion(string responsable, string numeroSolicitud)
        {

            var usuario = CoreOriginarsaADP.ObtenerUsuarios().FirstOrDefault(f => f.UsuarioRed == responsable);

            if (usuario == null)
            {
                LogHelper.EscribirLog("EnviarCorreoAsignacion", $"{responsable} - {numeroSolicitud}", "Core.Creditos.Adapters.EnviarCorreo", responsable, TipoMensajeLog.Error);
                return;
            }
            ArmarEstructuraCorreo(usuario, numeroSolicitud);
        }


        public static void ArmarEstructuraCorreo(UsuarioCO usuario, string numeroSolicitud)
        {
            var informacionSolicitud = ObtenerInformacionCreditosDAL.Execute(numeroSolicitud);

            string asunto = $"Asignación Solicitud: {numeroSolicitud}";
            string destinatario = usuario.Correo;

            string contenido = ObtenerParametrizacionCreditosDAL.Execute(ParametrizacionCreditos.PLANTILLA_ENVIO_SOLICITUD_CREDITO).Valor;
            string token = GenerarToken(usuario, numeroSolicitud);
            contenido = contenido.Inject(usuario);
            contenido = contenido.Inject(informacionSolicitud);            
            contenido = contenido.Inject(informacionSolicitud?.InformacionVehiculo);
            contenido = contenido.Inject(informacionSolicitud.InformacionCliente);
            informacionSolicitud.InformacionConyuge = (informacionSolicitud.InformacionConyuge == null) ? new ObtenerInformacionCreditosDAL.InformacionConyuge() : informacionSolicitud.InformacionConyuge;
            contenido = contenido.Inject(informacionSolicitud?.InformacionConyuge);            
            
            contenido = contenido.Replace("{token}", token);

            AgregarCorreo(destinatario, asunto, contenido);
        }

        private static string GenerarToken(UsuarioCO usuario, string numeroSolicitud)
        {
            var fechaExpiracion = DateTime.Now.AddDays(10);
            var token = $"{usuario.UsuarioRed};{numeroSolicitud};{fechaExpiracion}";
            return ConvertStringToHex(token, Encoding.Unicode);
        }

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
