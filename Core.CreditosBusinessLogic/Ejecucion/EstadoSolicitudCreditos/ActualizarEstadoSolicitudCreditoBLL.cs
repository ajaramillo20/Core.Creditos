using Core.Common.Model.ExcepcionServicio;
using Core.Common.Model.General;
using Core.Common.Model.Transaccion.Base;
using Core.Common.Util.Helper.API;
using Core.Creditos.Adapters.NotificacionCambioEstadoSolicitudCredito;
using Core.Creditos.DataAccess.HistorialSolicitud;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.CambiarEstadoSolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;

namespace Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos
{
    /// <summary>
    /// Capa BL metodos para actualizar estados de solicitud de crédito
    /// </summary>
    public class ActualizarEstadoSolicitudCreditoBLL
    {
        public static void ActualizarEstadoSolicitudCredito(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {
            var resultadoActualizar = ActualizarEstadoSolicitudCreditoDAL.Execute(objetoTransaccional.NumeroSolicitudCredito, objetoTransaccional.CodigoEstadoSolicitudCreditoDestino);
            if (resultadoActualizar != (int)CodigosSolicitudCredito.OK)
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

        /// <summary>
        /// Notifica cambio de estado a entidad externa
        /// se tiene 3 constantes:
        /// Error: indica mensaje de error capturado con try catch.
        /// status: 0 si existe error, 1 para ok,
        /// Ori-Response: Respuesta plana del resultado obtenido
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void NotificarCambioEstado(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {
            var resultado = NotificadorApiExternaADP.EnviarInformacionRequest(objetoTransaccional.NumeroSolicitudCredito, objetoTransaccional.ComentarioCambioEstado);
            var tieneError = resultado.FirstOrDefault(f => f.Key == "Error").Value;
            var estatus = resultado.FirstOrDefault(f => f.Key == "status").Value == "0";
            var responseOriginal = resultado.FirstOrDefault(f => f.Key == "Ori-Response");

            AgregarHistorialSolicitudCreditoDAL.Execute(objetoTransaccional.UsuarioRed, string.Empty, Convert.ToInt32(objetoTransaccional.NumeroSolicitudCredito), $"Resultado Externo: {responseOriginal.Value}".ToUpper());

            if (tieneError != null || estatus)
            {
                AgregarHistorialSolicitudCreditoDAL.Execute(objetoTransaccional.UsuarioRed, string.Empty, Convert.ToInt32(objetoTransaccional.NumeroSolicitudCredito), "Error de comunicación externa".ToUpper());
                var resultadoActualizar = ActualizarEstadoSolicitudCreditoDAL.Execute(objetoTransaccional.NumeroSolicitudCredito, objetoTransaccional.CodigoEstadoSolicitudCreditoOrigen);
                if (resultadoActualizar != (int)CodigosSolicitudCredito.OK)
                {
                    throw new ExcepcionServicio(resultadoActualizar);
                }
                AgregarHistorialSolicitudCreditoDAL.Execute(objetoTransaccional.UsuarioRed, objetoTransaccional.CodigoEstadoSolicitudCreditoOrigen, Convert.ToInt32(objetoTransaccional.NumeroSolicitudCredito), $"{objetoTransaccional.NombreEstadoSolicitudCreditoDestino} > {objetoTransaccional.NombreEstadoSolicitudCreditoOrigen} ".ToUpper());
                throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorComunicacion);
            }

            objetoTransaccional.ResultadoRespuestaApiExterna = resultado;
        }
     
    }
}
