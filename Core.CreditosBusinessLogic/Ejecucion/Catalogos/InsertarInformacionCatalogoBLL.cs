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
        /// <summary>
        /// Inserta catálogo
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        internal static void InsertarCatalogo(CatalogoTrx objetoTransaccional)
        {
            var resultado = InsertarCatalogoDAL.Execute(objetoTransaccional.CatalogoInsertar);
            if (resultado!= (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(resultado);
            }
        }

        /// <summary>
        /// Inserta catálogo externo
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void InsertarCatalogoExterno(CatalogoTrx objetoTransaccional)
        {
            var resultado = InsertarCatalogoExternoDAL.Execute(objetoTransaccional.CatalogoExternoInsertar);
            if (resultado != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(resultado);
            }
        }
    }
}
