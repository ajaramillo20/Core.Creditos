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
        public static void ObtenerCatalogosList(CatalogoTrx objetoTransaccional)
        {
            objetoTransaccional.ListaCatalogos = ObtenerCatalogosDAL.Execute(objetoTransaccional.CodigoTabla, objetoTransaccional.CodigoCatalogo);
        }

        public static void ObtenerIndices(CatalogoTrx objetoTransaccional)
        {
            objetoTransaccional.ListaTablas = ObtenerIndicesDAL.Execute(objetoTransaccional.CodigoTabla);
        }

        public static void AgregarCatalogo(CatalogoTrx objetoTransaccional)
        {
            
        }
    }
}
