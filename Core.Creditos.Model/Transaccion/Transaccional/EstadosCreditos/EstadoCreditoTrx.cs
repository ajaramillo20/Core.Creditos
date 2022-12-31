using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.EstadoCredito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.EstadosCreditos
{
    /// <summary>
    /// Objeto transaccional estado crédito
    /// </summary>
    public class EstadoCreditoTrx : TransaccionBase
    {
        public EstadoCreditoTrx()
        {
            EstadoCredito = new EstadoCredito();
            FlujosEstadoCredito = new List<EstadoCredito>();
            EstadosDestino = new List<int>();
            Estados = new List<EstadoCredito>();
        }
        public EstadoCredito EstadoCredito { get; set; }
        public List<EstadoCredito> FlujosEstadoCredito { get; set;}

        /// <summary>
        /// INSERTAR VARIABLES
        /// </summary>
        public List<int> EstadosDestino { get; set; }
        

        /// <summary>
        /// OBTENERESTADOS
        /// </summary>
        public int? IdObtener { get; set; }
        public string CodigoObtener { get; set; } = "";
        public List<EstadoCredito> Estados { get; set; }
        public string CodigoEliminar { get; set; } = "";
    }
}
