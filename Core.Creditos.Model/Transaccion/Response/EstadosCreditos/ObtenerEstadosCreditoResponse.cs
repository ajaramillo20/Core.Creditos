using Core.Creditos.Model.Entidad.EstadoCredito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.EstadosCreditos
{
    public class ObtenerEstadosCreditoResponse
    {
        public List<EstadoCredito> Estados { get; set; } = new List<EstadoCredito>();
    }
}
