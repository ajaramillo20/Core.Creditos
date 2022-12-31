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
    public class EliminarEstadoCreditoIN : IEliminar<EstadoCreditoTrx, EstadosResponse>
    {
        public void AgregarInformacion(EstadoCreditoTrx objetoTransaccional)
        {
            
        }

        public void Eliminarnformacion(EstadoCreditoTrx objetoTransaccional)
        {
            EstadoCreditoEliminarnformacionBLL.EliminarEstado(objetoTransaccional.CodigoEliminar);
        }

        public void ValidarInformacion(EstadoCreditoTrx objetoTransaccional)
        {
            
        }
    }
}
