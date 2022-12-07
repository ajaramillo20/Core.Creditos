using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Response.HistorialSolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Ejecucion.HistorialSolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.HistorialSolicitudCreditos
{
    public class ObtenerHistorialSolicitudCreditoIN : IObtenerTodos<SolicitudCreditoTrx, ObtenerHistorialSolicitudCreditoResponse>
    {
        public void AgregarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            AgregarInformacionHistorialSolicitudCreditoBLL.ObtenerHistorial(objetoTransaccional);
        }

        public void ValidarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            //throw new NotImplementedException();
        }
    }
}
