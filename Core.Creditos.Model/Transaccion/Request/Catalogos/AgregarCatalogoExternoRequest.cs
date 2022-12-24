using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Request.Catalogos
{
    public class AgregarCatalogoExternoRequest
    {
        public string CodigoExterno { get; set; } = string.Empty;
        public string CodigoCatalogo { get; set; } = string.Empty;
        public string CodigoTabla { get; set; } = string.Empty;
        public string CodigoCredencial { get; set; } = string.Empty;
    }
}
