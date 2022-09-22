using Core.Creditos.DataAccess.Parametrizacion;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
