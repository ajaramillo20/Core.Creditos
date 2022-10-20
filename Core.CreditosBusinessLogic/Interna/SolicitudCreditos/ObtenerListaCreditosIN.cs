using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
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
    public class ObtenerListaCreditosIN : IObtenerTodos<SolicitudCreditoTrx, ObtenerListaCreditosResponse>
    {
        public void AgregarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            SolicitudCreditoObtenerInformacionBLL.ObtenerListaSolicitudCredito(objetoTransaccional);
        }

        public void ValidarInformacion(SolicitudCreditoTrx objetoTransaccional)
        {
            
        }
    }
}
