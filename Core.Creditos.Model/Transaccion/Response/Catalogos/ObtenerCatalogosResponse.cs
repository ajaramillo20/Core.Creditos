using Core.Creditos.Model.Entidad.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.Catalogos
{
    /// <summary>
    /// Clase obtener catalogos response
    /// </summary>
    public class ObtenerCatalogosResponse
    {
        /// <summary>
        /// Lista de catalogos
        /// </summary>
        public List<Catalogo> ListaCatalogos { get; set; } = new List<Catalogo>();

        /// <summary>
        /// Lista de catalogos externos
        /// </summary>
        public List<CatalogoExterno> ListaCatalogosExternos { get; set; } = new List<CatalogoExterno>();
    }
}
