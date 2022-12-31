using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.Catalogos
{
    /// <summary>
    /// entidad catálogo externo
    /// </summary>
    public class CatalogoExterno
    {
        public int Id { get; set; }
        public string CodigoExterno { get; set; } = string.Empty;
        public string CodigoCatalogo { get; set; } = string.Empty;
        public string CodigoTabla { get; set; } = string.Empty;
        public string CodigoCredencial { get; set; } = string.Empty;
        public string NombreCatalogo { get; set; } = string.Empty;
        public string NombreTabla { get; set; } = string.Empty;
        public string NombreConcesionario { get; set; } = string.Empty;
    }
}
