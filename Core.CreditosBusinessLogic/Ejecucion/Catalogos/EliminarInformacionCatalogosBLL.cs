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
    public static class EliminarInformacionCatalogosBLL
    {
        /// <summary>
        /// Eliminar catalogo
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void EliminarCatalogo(CatalogoTrx objetoTransaccional)
        {
            var resultado = EliminarCatalogoDAL.Execute(objetoTransaccional.CodigoCatalogo);
            if (resultado!= (int) CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(resultado);
            }
        }

        /// <summary>
        /// eliminar catalogoe xterno
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void EliminarCatalogoExterno(CatalogoTrx objetoTransaccional)
        {
            var resultado = EliminarCatalogoExternoDAL.Execute(objetoTransaccional.IdCodigoHomologacion);
            if (resultado != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(resultado);
            }
        }
    }
}
