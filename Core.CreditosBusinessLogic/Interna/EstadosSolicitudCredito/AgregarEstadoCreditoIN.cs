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
    public class AgregarEstadoCreditoIN : IInsertar<EstadoCreditoTrx, EstadosResponse>
    {
        public void AgregarInformacion(EstadoCreditoTrx objetoTransaccional)
        {            
            
        }

        public void HomologarInformacion(EstadoCreditoTrx objetoTransaccional)
        {
            
        }

        public void InsertarInformacion(EstadoCreditoTrx objetoTransaccional)
        {
            EstadoCreditoInsertarInformacionBLL.InsertarEstadoCredito(objetoTransaccional.EstadoCredito, objetoTransaccional.EstadosDestino);
        }

        public void ValidarInformacion(EstadoCreditoTrx objetoTransaccional)
        {
            EstadoCreditoValidarInformacionBLL.ExisteCodigoEstadoCredito(objetoTransaccional.EstadoCredito.Codigo);
        }
    }
}
