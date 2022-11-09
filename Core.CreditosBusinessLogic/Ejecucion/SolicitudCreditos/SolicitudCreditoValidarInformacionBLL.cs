using Core.Common.Model.ExcepcionServicio;
using Core.Common.Util.Helper.Internal;
using Core.Creditos.DataAccess.Catalogos;
using Core.Creditos.DataAccess.EstadoSolicitudCreditos;
using Core.Creditos.DataAccess.General;
using Core.Creditos.DataAccess.Parametrizacion;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.DataAccess.Usuarios;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using IdentityServer4.Stores.Serialization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;




namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class SolicitudCreditoValidarInformacionBLL
    {
        
        /// <summary>
        /// Valida si contienen algun resultado que indique error
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ValidarResultadoPoliticas(SolicitudCreditoTrx objetoTransaccional)
        {
            if (objetoTransaccional.ResultadoEvaluacionPoliticas.Where(w => w.Value == true).Count() > 0)
            {
                var codigoEstado = ObtenerParametrizacionCreditosDAL.Execute(ParametrizacionCreditos.ANALIS_RAPIDO_ESTADO_NEGADO, objetoTransaccional.Credenciales.Codigo);
                var estado = ObtenerEstadoSolicitudCreditoDAL.Execute(
                                                                       codigoEstado: codigoEstado.Valor
                                                                      );

                objetoTransaccional.MensajeRespuestaSolicitudCredito = estado.NombreEstado;
                objetoTransaccional.CodigoEstadoSolicitudCredito = estado.CodigoEstado;
            }
            else
            {
                var codigoEstado = ObtenerParametrizacionCreditosDAL.Execute(ParametrizacionCreditos.ANALIS_RAPIDO_ESTADO_PRE_APROBADO, objetoTransaccional.Credenciales.Codigo);
                var estado = ObtenerEstadoSolicitudCreditoDAL.Execute(
                                                                       codigoEstado: codigoEstado.Valor
                                                                      );

                objetoTransaccional.MensajeRespuestaSolicitudCredito = estado.NombreEstado;
                objetoTransaccional.CodigoEstadoSolicitudCredito = estado.CodigoEstado;
            }
        }


        /// <summary>
        /// Metodo para realizar validaciones a campos,
        /// estos campos se define en base de datos
        /// Campos Base de datos:
        /// Campo Json, obligatorio, requiere homologacion, tabla homologacion, codigo errror
        /// </summary>
        /// <param name="objetoTransaccional">Objeto transaccional del objeto</param>
        /// 
        /// <exception cref="Exception"></exception>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void ValidarReglasCamposRequest(SolicitudCreditoTrx objetoTransaccional)
        {
            var reglasCamposRequest = ObtenerReglasCamposRequestDAL.Execute(objetoTransaccional.Credenciales.Codigo);

            JObject objOrigen = JObject.Parse(objetoTransaccional.SolicitudCreditoJsonRequest);
            JObject objDestino = JObject.Parse(objetoTransaccional.SolicitudCreditoJsonRequest);

            foreach (var campo in reglasCamposRequest)
            {
                string nombreCampo = campo.Campo;
                bool esObligatorio = campo.EsObligatorio;
                bool requiereHomologacion = campo.RequiereHomologacion;
                string codigoTabla = campo.CodigoTabla;
                var campoOrigen = objOrigen.SelectToken(nombreCampo);
                var esnulo = string.IsNullOrEmpty(campoOrigen?.Value<string>());
                if (esObligatorio && esnulo)
                {
                    throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorCampoObligatorio, nombreCampo);
                }

                if (requiereHomologacion)
                {

                    if (!esnulo)
                    {
                        var codigoHomologcion = HomologarCatalogoExternoDAL.Execute(campoOrigen.Value<string>(), codigoTabla);
                        if (codigoHomologcion == null)
                        {
                            throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorHomologacionCodigo, nombreCampo);

                        }
                        objDestino.SelectToken(nombreCampo).Replace(codigoHomologcion.CodigoInterno);
                    }
                }
            }


            var settings = new JsonSerializerSettings();            
            settings.ContractResolver = new CustomContractResolver();

            var solicitud = JsonConvert.DeserializeObject<SolicitudCredito>(objDestino.ToString(), settings);
            objetoTransaccional.SolicitudCredito = solicitud;
        }

        /// <summary>
        /// Valida todas las reglas definidas en bases de datos
        /// </summary>
        public static void ValidarReglasSolicitudCredito(SolicitudCreditoTrx objetoTransaccional)
        {
            Dictionary<string, bool> resultValidacion = new Dictionary<string, bool>();
            var reglasSolicitudCredito = ObtenerReglasSolicitudCreditoDAL.Execute(objetoTransaccional.Credenciales.Codigo);

            TipoDatoParametroEvaluacion tipoDato;
            decimal valorNumericoRegla = 0;
            decimal valorNumericoCampoRequest = 0;

            string valorAlfaNumericoRegla = string.Empty;
            string valorAlfaNumericoCampoRequest = string.Empty; ;

            foreach (var regla in reglasSolicitudCredito)
            {
                if (!Enum.TryParse(regla.TipoDato, out tipoDato))
                    throw new ExcepcionServicio((int)ErroresSolicitudCredito.FormatoIncorrectoResponse, regla.TipoDato);

                if (tipoDato == TipoDatoParametroEvaluacion.ALFANUMERICO)
                {
                    valorAlfaNumericoRegla = regla.ValorEsperado.ToString();
                    valorAlfaNumericoCampoRequest = objetoTransaccional.GetType().GetProperty(regla.CampoRequest).GetValue(objetoTransaccional).ToString();
                }

                switch (regla.Operador)
                {
                    case "=":

                        if (tipoDato == TipoDatoParametroEvaluacion.NUMERICO)
                        {
                            valorNumericoRegla = decimal.Parse(regla.ValorEsperado);
                            valorNumericoCampoRequest = Convert.ToDecimal(objetoTransaccional.GetType().GetProperty(regla.CampoRequest).GetValue(objetoTransaccional));
                            if (!valorNumericoRegla.Equals(valorNumericoCampoRequest))
                            {
                                resultValidacion.Add($"{valorNumericoRegla} != {valorNumericoCampoRequest}", regla.IndicaError);
                            }
                        }

                        if (tipoDato == TipoDatoParametroEvaluacion.ALFANUMERICO)
                        {
                            if (!valorAlfaNumericoRegla.Equals(valorAlfaNumericoCampoRequest))
                            {
                                resultValidacion.Add($"{valorAlfaNumericoRegla} != {valorAlfaNumericoCampoRequest}", regla.IndicaError);
                            }
                        }
                        break;


                    case "!=":
                        if (tipoDato == TipoDatoParametroEvaluacion.NUMERICO)
                        {
                            valorNumericoRegla = decimal.Parse(regla.ValorEsperado);
                            valorNumericoCampoRequest = Convert.ToDecimal(objetoTransaccional.GetType().GetProperty(regla.CampoRequest).GetValue(objetoTransaccional));
                            if (valorNumericoRegla.Equals(valorNumericoCampoRequest))
                            {
                                resultValidacion.Add($"{valorNumericoRegla} != {valorNumericoCampoRequest}", regla.IndicaError);
                            }
                        }

                        if (tipoDato == TipoDatoParametroEvaluacion.ALFANUMERICO)
                        {
                            if (valorAlfaNumericoRegla.Equals(valorAlfaNumericoCampoRequest))
                            {
                                resultValidacion.Add($"{valorAlfaNumericoRegla} != {valorAlfaNumericoCampoRequest}", regla.IndicaError);
                            }
                        }
                        break;

                    case "<=":

                        if (tipoDato == TipoDatoParametroEvaluacion.NUMERICO)
                        {
                            valorNumericoRegla = decimal.Parse(regla.ValorEsperado);
                            valorNumericoCampoRequest = Convert.ToDecimal(objetoTransaccional.GetType().GetProperty(regla.CampoRequest).GetValue(objetoTransaccional));
                            if (valorNumericoCampoRequest > valorNumericoRegla)
                            {
                                resultValidacion.Add($"{valorNumericoRegla} != {valorNumericoCampoRequest}", regla.IndicaError);
                            }
                        }
                        break;

                    case ">=":

                        if (tipoDato == TipoDatoParametroEvaluacion.NUMERICO)
                        {
                            valorNumericoRegla = decimal.Parse(regla.ValorEsperado);
                            valorNumericoCampoRequest = Convert.ToDecimal(objetoTransaccional.GetType().GetProperty(regla.CampoRequest).GetValue(objetoTransaccional));
                            if (valorNumericoCampoRequest < valorNumericoRegla)
                            {
                                resultValidacion.Add($"{valorNumericoRegla}  {valorNumericoCampoRequest}", regla.IndicaError);
                            }
                        }
                        break;

                    case "CONTIENE":
                        if (tipoDato == TipoDatoParametroEvaluacion.ALFANUMERICO)
                        {
                            valorAlfaNumericoCampoRequest = valorAlfaNumericoCampoRequest == null ? String.Empty : valorAlfaNumericoCampoRequest;
                            if (!valorAlfaNumericoCampoRequest.Contains(valorAlfaNumericoRegla))
                            {
                                resultValidacion.Add($"{valorAlfaNumericoCampoRequest} no contiene {valorAlfaNumericoRegla} ", regla.IndicaError);
                            }
                        }
                        break;

                    case "RANGO":

                        if (tipoDato == TipoDatoParametroEvaluacion.NUMERICO)
                        {
                            var rangoValores = regla.ValorEsperado.Split('-');
                            valorNumericoCampoRequest = Convert.ToDecimal(objetoTransaccional.GetType().GetProperty(regla.CampoRequest).GetValue(objetoTransaccional));

                            var valorInicio = decimal.Parse(rangoValores[0]);
                            var valorFinal = decimal.Parse(rangoValores[1]);

                            if (valorNumericoCampoRequest < valorInicio || valorNumericoCampoRequest > valorFinal)
                            {
                                resultValidacion.Add($"Valor {valorAlfaNumericoCampoRequest} fuera del rango {valorInicio} - {valorFinal}", regla.IndicaError);
                            }
                        }

                        break;

                    default:
                        throw new ExcepcionServicio((int)ErroresSolicitudCredito.FormatoIncorrectoResponse);
                }
            }

            objetoTransaccional.ResultadoEvaluacionPoliticas = resultValidacion;
        }

        public static void ValidarUsuarioResponsable(SolicitudCreditoTrx objetoTransaccional)
        {
            if (string.IsNullOrEmpty(objetoTransaccional.Responsable))
            {
                throw new ExcepcionServicio((int)ErroresSolicitudCredito.UsuarioNoActivo);
            }
            if (!ValidarUsuarioResponsableDAL.Execute(objetoTransaccional.Responsable))
            {
                throw new ExcepcionServicio((int)ErroresSolicitudCredito.UsuarioNoActivo);
            }            
        }
    }
}
