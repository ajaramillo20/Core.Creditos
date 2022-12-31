using Core.Creditos.Model.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.Parametrizacion
{
    public class ObtenerParametrizacionResponse
    {
        public List<Parametro> Parametros { get; set; } = new List<Parametro>();
    }
}
