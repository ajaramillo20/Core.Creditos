using Core.Creditos.DataAccess.HistorialSolicitud;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.HistorialSolicitudCreditos
{
    public static class AgregarInformacionHistorialSolicitudCreditoBLL
    {
        internal static void ObtenerHistorial(SolicitudCreditoTrx objetoTransaccional)
        {
            objetoTransaccional.Historial= ObtenerHistorialSolicitudCreditoDAL.Execute((int)objetoTransaccional.NumeroSolicitudCredito);
        }
    }
}
