using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.DataAccess.HistorialSolicitud;
using Core.Creditos.Model.Transaccion.Response.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
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
        }

        public void HomologarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            
        }

        public void InsertarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            //AgregarSolicitudCreditoBLL.AgregarsolicitudCredito(objetoTransaccional);
            //AgregarHistorialSolicitudCreditoDAL.Execute(objetoTransaccional.Credenciales.Codigo, objetoTransaccional.CodigoEstadoSolicitudCredito, (int)objetoTransaccional.NumeroSolicitudCredito, "");
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
