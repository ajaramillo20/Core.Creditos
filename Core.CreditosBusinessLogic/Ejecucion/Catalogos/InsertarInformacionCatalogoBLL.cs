using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.Catalogos;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.Catalogos
{
    public static class InsertarInformacionCatalogoBLL
    {
        internal static void InsertarCatalogo(CatalogoTrx objetoTransaccional)
        {
            var resultado = InsertarCatalogoDAL.Execute(objetoTransaccional.CatalogoInsertar);
            if (resultado!= (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(resultado);
            }
        }
    }
}
