using Core.Creditos.Adapters.Core.Notificaciones;
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
        public static void ValidaAccionesEstado(SolicitudCreditoTrx objetoTransaccional)
        {
            var estado = EstadoCreditoAgregarInformacionBLL.ObtenerEstadoCredito(objetoTransaccional.CodigoEstadoSolicitudCredito??"");

            if (estado.RequiereEnvioEmail)
            {
                EnviarNotificacionCorreoADP.EnviarCorreoAsignacion(objetoTransaccional.Responsable, objetoTransaccional.NumeroSolicitudCredito.ToString()??"");
            }
        }
    }
}
