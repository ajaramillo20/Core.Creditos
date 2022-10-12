using Core.Common.Model.General;
using Core.Common.Util.Helper.API;
using Core.Creditos.Adapters.NotificacionCambioEstadoSolicitudCredito;
using Core.Creditos.DataAccess.SolicitudCreditos;
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
            ActualizarEstadoSolicitudCreditoDAL.Execute(objetoTransaccional.NumeroSolicitudCredito, objetoTransaccional.CodigoEstadoSolicitudCreditoDestino);
        }

        public static void NotificarCambioEstado(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {
            NotificarCambioEstadoSolicitudCreditoAdapter.GetInformacionRequest(objetoTransaccional.NumeroSolicitudCredito);
        }
    }
}
