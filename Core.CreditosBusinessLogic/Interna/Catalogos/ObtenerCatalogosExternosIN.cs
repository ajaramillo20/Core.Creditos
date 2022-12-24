using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Model.Transaccion.Response.Catalogos;
using Core.Creditos.Model.Transaccion.Transaccional.Catalogos;
using Core.CreditosBusinessLogic.Ejecucion.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.Catalogos
{
    public class ObtenerCatalogosExternosIN : IObtenerTodos<CatalogoTrx, ObtenerCatalogosResponse>
    {
        public void AgregarInformacion(CatalogoTrx objetoTransaccional)
        {
            AgregarInformacionCatalogoBLL.ObtenerCatalogosExternosList(objetoTransaccional);
        }

        public void ValidarInformacion(CatalogoTrx objetoTransaccional)
        {
            
        }
    }
}
