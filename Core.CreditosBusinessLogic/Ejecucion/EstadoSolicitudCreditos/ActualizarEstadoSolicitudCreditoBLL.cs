using Core.Common.Model.ExcepcionServicio;
using Core.Common.Model.General;
using Core.Common.Util.Helper.API;
using Core.Creditos.Adapters.NotificacionCambioEstadoSolicitudCredito;
using Core.Creditos.DataAccess.HistorialSolicitud;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.CambiarEstadoSolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos
{
    public class ActualizarEstadoSolicitudCreditoBLL
    {
        public static void ActualizarEstadoSolicitudCredito(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {
            var resultadoActualizar = ActualizarEstadoSolicitudCreditoDAL.Execute(objetoTransaccional.NumeroSolicitudCredito, objetoTransaccional.CodigoEstadoSolicitudCreditoDestino);
            if (resultadoActualizar!=(int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(resultadoActualizar);
            }

            var informacionSolicitudCreditoActualizado = ObtenerSolicitudCreditoPorNumeroDAL.Execute(objetoTransaccional.NumeroSolicitudCredito);
            objetoTransaccional.CodigoEstadoSolicitudCredito = informacionSolicitudCreditoActualizado.EstadoCodigo;
            objetoTransaccional.NombreEstadoSolicitud = informacionSolicitudCreditoActualizado.EstadoNombre;
            objetoTransaccional.IdEstadoSolicitudCredito = informacionSolicitudCreditoActualizado.EstadoId;
            objetoTransaccional.MensajeCambioEstadoSolicitudCredito = $"Solicitud Crédito Actualizada";

            AgregarHistorialSolicitudCreditoDAL.Execute(objetoTransaccional.UsuarioRed, objetoTransaccional.CodigoEstadoSolicitudCredito, Convert.ToInt32(objetoTransaccional.NumeroSolicitudCredito), objetoTransaccional.ComentarioCambioEstado ?? "");
        }

        public static void NotificarCambioEstado(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {
         objetoTransaccional.ResultadoRespuestaApiExterna = NotificarCambioEstadoSolicitudCreditoAdapter.EnviarInformacionRequest(objetoTransaccional.NumeroSolicitudCredito);
        }
    }
}
