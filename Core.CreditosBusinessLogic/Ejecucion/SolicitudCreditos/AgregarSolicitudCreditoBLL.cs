using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class AgregarSolicitudCreditoBLL
    {
        public static void AgregarsolicitudCredito(SolicitudCreditoTrx objetoTransaccional)
        {
            var agregarSolicitudCreditoResult = AgregarSolicitudCreditoDAL.Execute(objetoTransaccional);
            objetoTransaccional.NumeroSolicitud = agregarSolicitudCreditoResult.NumeroSolicitud;
        }
    }
}
