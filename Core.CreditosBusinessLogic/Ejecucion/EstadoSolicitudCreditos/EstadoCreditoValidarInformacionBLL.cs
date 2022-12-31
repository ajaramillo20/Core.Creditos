using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.Adapters.Core.Notificaciones;
using Core.Creditos.Model.Entidad.EstadoCredito;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos
{
    public class EstadoCreditoValidarInformacionBLL
    {
        /// <summary>
        /// Valida información estado
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ValidaAccionesEstado(SolicitudCreditoTrx objetoTransaccional)
        {
            var estado = EstadoCreditoAgregarInformacionBLL.ObtenerEstadoCredito(objetoTransaccional.CodigoEstadoSolicitudCredito??"");

            if (estado.RequiereEnvioEmail)
            {
                EnviarNotificacionCorreoADP.EnviarCorreoAsignacion(objetoTransaccional.Responsable, objetoTransaccional.NumeroSolicitudCredito.ToString()??"");
            }
        }

        /// <summary>
        /// valida si existe codigo estdo
        /// </summary>
        /// <param name="codigoEstado"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void ExisteCodigoEstadoCredito(string codigoEstado)
        {
            var existe = EstadoCreditoAgregarInformacionBLL.ObtenerEstadoCredito(codigoEstado: codigoEstado);
            if (existe!=null)
            {
                throw new ExcepcionServicio((int)ErroresSolicitudCredito.RegistroDuplicado, existe.Codigo);
            }
        }
    }
}
