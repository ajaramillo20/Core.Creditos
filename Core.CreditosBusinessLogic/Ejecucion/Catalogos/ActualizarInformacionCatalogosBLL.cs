using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.Catalogos;
using Core.Creditos.Model.Entidad.Catalogos;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.Catalogos
{
    public static class ActualizarInformacionCatalogosBLL
    {
        /// <summary>
        /// Actualiza catálogo
        /// </summary>
        /// <param name="catalogoInsertar"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void ActualizarCatalogo(Catalogo catalogoInsertar)
        {
            var resultado = ActualizarCatalogoDAL.Execute(catalogoInsertar);
            if (resultado != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(resultado);
            }
        }

        /// <summary>
        /// Actualiza un catálogo externo
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void ActualizarCatalogoExterno(CatalogoTrx objetoTransaccional)
        {
            var resultado = ActualizarCatalogoExternoDAL.Execute(objetoTransaccional.CatalogoExternoInsertar);
            if (resultado != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(resultado);
            }
        }
    }
}
