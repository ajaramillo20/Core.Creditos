using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Adapters.Core.Notificaciones;
using Core.Creditos.Model.Transaccion.Response.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.SolicitudCreditos
{
    public class ReasignarSolicitudCreditoIN : IActualizar<SolicitudCreditoTrx, ReasignarSolicitudCreditoResponse>
    {
        public void ActualizarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            SolicitudCreditoActualizarInformacionBLL.ActualizarResponsable(objetoTransaccional);
            EnviarNotificacionCorreoADP.EnviarCorreoAsignacion(objetoTransaccional.Responsable, objetoTransaccional.NumeroSolicitudCredito.ToString());
        }

        public void AgregarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            SolicitudCreditoObtenerInformacionBLL.ObtenerInformacionSolicitudCredito(objetoTransaccional);
            SolicitudCreditoAgregarInformacionBLL.ObtenerTipoCreditosRol(objetoTransaccional);
            SolicitudCreditoAgregarInformacionBLL.ObtenerResponsableColaAutomatico(objetoTransaccional);            
        }

        public void HomologarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            
        }

        public void ValidarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            SolicitudCreditoValidarInformacionBLL.ValidarUsuarioResponsable(objetoTransaccional);
        }
    }
}
