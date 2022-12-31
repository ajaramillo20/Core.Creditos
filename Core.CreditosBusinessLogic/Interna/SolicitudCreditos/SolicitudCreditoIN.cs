using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Adapters.Core.Notificaciones;
using Core.Creditos.DataAccess.HistorialSolicitud;
using Core.Creditos.Model.Transaccion.Response.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Ejecucion.Concesionarios;
using Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos;

namespace Core.CreditosBusinessLogic.Interna.SolicitudCreditos
{
    public class SolicitudCreditoIN : IInsertar<SolicitudCreditoTrx, SolicitudCreditoResponse>
    {
        public void AgregarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            SolicitudCreditoAgregarInformacionBLL.AgregarJsonPeticionSolicitudCredito(objetoTransaccional);
            SolicitudCreditoAgregarInformacionBLL.CalcularEdadCliente(objetoTransaccional);
            SolicitudCreditoAgregarInformacionBLL.CalcularIngresosTotalCliente(objetoTransaccional);
            SolicitudCreditoAgregarInformacionBLL.ObtenerTipoCreditosRol(objetoTransaccional);
            SolicitudCreditoAgregarInformacionBLL.ObtenerInformacionBuro(objetoTransaccional);            
        }

        public void HomologarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            
        }

        public void InsertarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            AgregarSolicitudCreditoBLL.AgregarsolicitudCredito(objetoTransaccional);            
        }

        public void ValidarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            SolicitudCreditoValidarInformacionBLL.ValidarReglasCamposRequest(objetoTransaccional);
            SolicitudCreditoValidarInformacionBLL.ValidarReglasSolicitudCredito(objetoTransaccional);            
            SolicitudCreditoValidarInformacionBLL.ValidarResultadoPoliticas(objetoTransaccional);
            SolicitudCreditoAgregarInformacionBLL.ObtenerResponsableCola(objetoTransaccional);
            SolicitudCreditoValidarInformacionBLL.ValidarUsuarioResponsable(objetoTransaccional);
        }
    }
}
