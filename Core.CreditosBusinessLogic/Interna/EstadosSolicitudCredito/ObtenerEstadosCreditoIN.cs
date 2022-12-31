using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Model.Transaccion.Response.EstadosCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.EstadosCreditos;
using Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.EstadosSolicitudCredito
{
    public class ObtenerEstadosCreditoIN : IObtenerTodos<EstadoCreditoTrx, ObtenerEstadosCreditoResponse>
    {
        public void AgregarInformacion(EstadoCreditoTrx objetoTransaccional)
        {
            objetoTransaccional.Estados = EstadoCreditoAgregarInformacionBLL.ObtenerEstadoCreditoList(objetoTransaccional.CodigoObtener, objetoTransaccional.IdObtener);
        }

        public void ValidarInformacion(EstadoCreditoTrx objetoTransaccional)
        {

        }
    }
}
