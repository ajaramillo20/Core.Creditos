using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.Catalogos;
using Core.Creditos.DataAccess.General;
using Core.Creditos.DataAccess.Parametrizacion;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class SolicitudCreditoValidarInformacionBLL
    {
        /// <summary>
        /// /// Valida los ingresos del deudor
        /// La regla aplica para la suma de todos sus ingresos
        /// ingresoTotal = ingresosDeudor+ingresosConyuge+otrosIngresosDeudor+otrosingresosConyuge;
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ValidarIngresos(SolicitudCreditoTrx objetoTransaccional)
        {
            try
            {
                var solicitud = objetoTransaccional?.SolicitudCredito?.Solicitud;
                var informacionCredito = solicitud?.InformacionCredito;

                var result = ValidarPoliticaIngresosSolicitudCreditoDAL.Execute(informacionCredito.IngresosDeudor,
                                                                                informacionCredito.OtrosIngresosDeudor,
                                                                                informacionCredito.IngresosConyuge,
                                                                                informacionCredito.OtrosIngresosConyuge,
                                                                                ParametrizacionCreditos.POLITICA_VALIDACION_INGRESO_REQUERIDO.ToString());
                objetoTransaccional.CumplePoliticaIngresos = result == (int)CodigosSolicitudCredito.OK;
                objetoTransaccional.Respuesta.CodigoInternoRespuesta = result;
            }
            catch (Exception ex)
            {
                objetoTransaccional.CumplePoliticaIngresos = false;
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Metodo para validar la edad del deudor en base a su fecha de nacimiento
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ValidarEdadDeudor(SolicitudCreditoTrx objetoTransaccional)
        {
            try
            {
                var politicaEdadMinima = ObtenerParametrizacionCreditosDAL.Execute(ParametrizacionCreditos.POLITICA_VALIDACION_EDAD_MINIMA);
                var politicaEdadMaxima = ObtenerParametrizacionCreditosDAL.Execute(ParametrizacionCreditos.POLITICA_VALIDACION_EDAD_MAXIMA);

                var cliente = objetoTransaccional?.SolicitudCredito?.Solicitud?.Cliente;
                var fechaNacimiento = cliente.FechaNacimiento;
                int edadDeudor = DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;

                int edadMinima = Convert.ToInt32(politicaEdadMinima.Valor);
                var edadMaxima = Convert.ToInt32(politicaEdadMaxima.Valor);

                var result = ValidarPoliticaEdadSolicitudCreditoDAL.Execute(edadMinima, edadMaxima, edadDeudor);

                objetoTransaccional.CumplePoliticaEdad = (result != (int)CodigosSolicitudCredito.OK) ? false : true;
                objetoTransaccional.Respuesta.CodigoInternoRespuesta = result;
            }
            catch (Exception ex)
            {
                objetoTransaccional.CumplePoliticaEdad = false;
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Valida los resultados de las politicas
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ValidarResultadoPoliticas(SolicitudCreditoTrx objetoTransaccional)
        {
            if (objetoTransaccional.CumplePoliticaEdad && objetoTransaccional.CumplePoliticaIngresos)
            {
                var estadoAprobado = ObtenerParametrizacionCreditosDAL.Execute(ParametrizacionCreditos.ESTADO_APROBAR_SOLICITUD_CREDITO);
                objetoTransaccional.MensajeRespuestaSolicitudCredito = estadoAprobado.Valor;
                objetoTransaccional.CodigoEstadoSolicitudCredito = estadoAprobado.Codigo;
            }
            else
            {
                var estadoNegado = ObtenerParametrizacionCreditosDAL.Execute(ParametrizacionCreditos.ESTADO_NEGAR_SOLICITUD_CREDITO);
                objetoTransaccional.MensajeRespuestaSolicitudCredito = estadoNegado.Valor;
                objetoTransaccional.CodigoEstadoSolicitudCredito = estadoNegado.Codigo;
            }
        }

        public static void ValidarReglasCamposRequest(SolicitudCreditoTrx objetoTransaccional)
        {
            var reglasCamposRequest = ObtenerReglasCamposRequestDAL.Execute(objetoTransaccional.CodigoEntidad);

            JObject objOrigen = JObject.Parse(objetoTransaccional.SolicitudCreditoJsonRequest);
            JObject objDestino = JObject.Parse(objetoTransaccional.SolicitudCreditoJsonRequest);

            foreach (var campo in reglasCamposRequest)
            {
                string nombreCampo = campo.Campo;
                bool esObligatorio = campo.EsObligatorio;
                bool requiereHomologacion = campo.RequiereHomologacion;
                string codigoTabla = campo.CodigoTabla;
                int codigoError = campo.CodigoError;
                var campoOrigen = objOrigen.SelectToken(nombreCampo);

                if (esObligatorio)
                {
                    if (campoOrigen == null || string.IsNullOrEmpty(campoOrigen.Value<string>()))
                    {
                        throw new Exception($"{nombreCampo} - Obligatorio");
                    }
                }

                if (requiereHomologacion)
                {
                    var codigoHomologcion = HomologarCatalogoExternoDAL.Execute(campoOrigen.Value<string>(), codigoTabla);
                    if (codigoHomologcion == null)
                    {
                        throw new ExcepcionServicio(codigoError);
                    }
                    objDestino.SelectToken(nombreCampo).Replace(codigoHomologcion.CodigoInterno);
                }
            }

            var solicitud = JsonConvert.DeserializeObject<SolicitudCredito>(objDestino.ToString());
            objetoTransaccional.SolicitudCredito = solicitud;
        }


    }
}
