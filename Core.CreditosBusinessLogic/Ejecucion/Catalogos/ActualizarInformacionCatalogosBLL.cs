using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.Catalogos;
using Core.Creditos.Model.Entidad.Catalogos;
using Core.Creditos.Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.Catalogos
{
    public static class ActualizarInformacionCatalogosBLL
    {
        internal static void ActualizarCatalogo(Catalogo catalogoInsertar)
        {
            var resultado = ActualizarCatalogoDAL.Execute(catalogoInsertar);
            if (resultado!= (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(resultado);
            }
        }
    }
}
