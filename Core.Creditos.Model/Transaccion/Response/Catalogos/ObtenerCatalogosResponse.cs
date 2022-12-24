using Core.Creditos.Model.Entidad.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.Catalogos
{
    public class ObtenerCatalogosResponse
    {
        public List<Catalogo> ListaCatalogos { get; set; } = new List<Catalogo>();
        public List<CatalogoExterno> ListaCatalogosExternos { get; set; } = new List<CatalogoExterno>();
    }
}
