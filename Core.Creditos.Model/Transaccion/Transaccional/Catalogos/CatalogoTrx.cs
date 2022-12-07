using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.Catalogos
{
    public class CatalogoTrx : TransaccionBase
    {
        //VARIABBLES GENERALES / CONSULTA
        public string CodigoCatalogo { get; set; } = string.Empty;
        public string CodigoTabla { get; set; } = string.Empty;

        //VARIABLES PARA RESPONSE
        public List<Catalogo> ListaCatalogos { get; set; } = new List<Catalogo>();
        public List<Tabla> ListaTablas { get; set; } = new List<Tabla>();

        //VARIABLES INSERTAR
        public Catalogo CatalogoInsertar { get; set; } = new Catalogo();

    }
}
