using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using System.Text.Json;

namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class SolicitudCreditoAgregarInformacionBLL
    {
        public static void AgregarJsonPeticionSolicitudCredito(SolicitudCreditoTrx objetoTransaccional)
        {
            string jsonString = JsonSerializer.Serialize(objetoTransaccional.SolicitudCredito);
            objetoTransaccional.SolicitudCreditoJsonRequest = jsonString;
        }
    }
}
