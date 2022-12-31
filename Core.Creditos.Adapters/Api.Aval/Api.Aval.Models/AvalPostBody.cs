using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Adapters.Api.Aval
{   
    /// <summary>
    /// CLASE REQUEST AVAL
    /// </summary>
    public class DatosEntrada
    {
        public string clave { get; set; }
        public string valor { get; set; }
    }

    /// <summary>
    /// CLASE REQUEST AVAL
    /// </summary>
    public class Request
    {
        public string codigoProducto { get; set; } = "T603";
        public List<DatosEntrada> datosEntrada { get; set; } = new List<DatosEntrada>();
    }

    /// <summary>
    /// CLASE REQUEST AVAL
    /// </summary>
    public class AvalPostBody
    {
        public string origin { get; set; } = "webservice";
        public Request request { get; set; } = new Request();
    }
}
