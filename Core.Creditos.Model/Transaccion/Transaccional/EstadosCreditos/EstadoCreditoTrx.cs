using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.EstadoCredito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.EstadosCreditos
{
    public class EstadoCreditoTrx : TransaccionBase
    {
        public EstadoCreditoTrx()
        {
            EstadoCredito = new EstadoCredito();
            FlujosEstadoCredito = new List<EstadoCredito>();
        }
        public EstadoCredito EstadoCredito { get; set; }
        public List<EstadoCredito> FlujosEstadoCredito { get; set;}        
    }
}
