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
    public class ObtenerFlujosEstadoCreditoIN : IObtenerTodos<EstadoCreditoTrx, ObtenerFlujosEstadoCreditoResponse>
    {
        public void AgregarInformacion(EstadoCreditoTrx objetoTransaccional)
        {
            EstadoCreditoAgregarInformacionBLL.ObtenerEstadoCredito(objetoTransaccional);
            EstadoCreditoAgregarInformacionBLL.ObtenerFlujoEstadoCredito(objetoTransaccional);
        }

        public void ValidarInformacion(EstadoCreditoTrx objetoTransaccional)
        {
            
        }
    }
}
