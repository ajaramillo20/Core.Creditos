using Core.Creditos.Model.Entidad.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.Catalogos
{
    public class ObtenerIndicesResponse
    {
        public List<Tabla> ListaTablas { get; set; } = new List<Tabla>();
    }
}
