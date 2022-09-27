using Core.Common.ProcessTemplate.InternalBusinessLogic;
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
        }

        public void HomologarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {            
            //SolicitudCreditoHomologarInformacionBLL.HomologarCodigosExternos(objetoTransaccional);
        }

        public void InsertarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            AgregarSolicitudCreditoBLL.AgregarsolicitudCredito(objetoTransaccional);
        }

        public void ValidarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            SolicitudCreditoValidarInformacionBLL.ValidarReglasCamposRequest(objetoTransaccional);
            SolicitudCreditoValidarInformacionBLL.ValidarIngresos(objetoTransaccional);
            SolicitudCreditoValidarInformacionBLL.ValidarEdadDeudor(objetoTransaccional);
            SolicitudCreditoValidarInformacionBLL.ValidarResultadoPoliticas(objetoTransaccional);
        }
    }
}
