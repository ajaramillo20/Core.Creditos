using Core.Creditos.Model.Entidad.EstadoCredito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Request.EstadosSolicitud
{
    public class EstadoRequest
    {
        public EstadoCredito Estado { get; set; } = new EstadoCredito();
        public List<int> EstadosDestino { get; set; } = new List<int>();
    }
}
