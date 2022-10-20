using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Creditos.Model.Entidad.EstadoCredito;

namespace Core.Creditos.Model.Transaccion.Response.EstadosCreditos
{
    public class ObtenerFlujosEstadoCreditoResponse
    {
        public EstadoCredito EstadoCredito { get; set; }
        public List<EstadoCredito> FlujosEstadoCredito { get; set; }
    }
}
