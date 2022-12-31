using Core.Creditos.DataAccess.Catalogos;
using Core.Creditos.Model.Transaccion.Transaccional.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.Catalogos
{
    public static class AgregarInformacionCatalogoBLL
    {
        /// <summary>
        /// Obtiene lista de catalogos
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ObtenerCatalogosList(CatalogoTrx objetoTransaccional)
        {
            objetoTransaccional.ListaCatalogos = ObtenerCatalogosDAL.Execute(objetoTransaccional.CodigoTabla, objetoTransaccional.CodigoCatalogo);
        }

        /// <summary>
        /// Obtiene lista de indices
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ObtenerIndices(CatalogoTrx objetoTransaccional)
        {
            objetoTransaccional.ListaTablas = ObtenerIndicesDAL.Execute(objetoTransaccional.CodigoTabla);
        }

        /// <summary>
        /// OBtiene lista de catalogos externos
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ObtenerCatalogosExternosList(CatalogoTrx objetoTransaccional)
        {
            objetoTransaccional.ListaCatalogosExternos = ObtenerCatalogosExternosDAL.Execute(objetoTransaccional.CodigoTabla, objetoTransaccional.CodigoCredencial, objetoTransaccional.CodigoCatalogo, objetoTransaccional.NombreCatalogo);
        }
    }
}
