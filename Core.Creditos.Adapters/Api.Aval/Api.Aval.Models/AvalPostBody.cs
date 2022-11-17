using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Adapters.Api.Aval
{   
    public class DatosEntrada
    {
        public string clave { get; set; }
        public string valor { get; set; }
    }

    public class Request
    {
        public string codigoProducto { get; set; } = "T603";
        public List<DatosEntrada> datosEntrada { get; set; } = new List<DatosEntrada>();
    }

    public class AvalPostBody
    {
        public string origin { get; set; } = "webservice";
        public Request request { get; set; } = new Request();
    }
}
