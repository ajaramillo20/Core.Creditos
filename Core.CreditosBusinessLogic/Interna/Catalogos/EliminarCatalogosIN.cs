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
    public class EliminarCatalogosIN : IEliminar<CatalogoTrx, EliminarCatalogoResponse>
    {
        public void AgregarInformacion(CatalogoTrx objetoTransaccional)
        {
            
        }

        public void Eliminarnformacion(CatalogoTrx objetoTransaccional)
        {
            EliminarInformacionCatalogosBLL.EliminarCatalogo(objetoTransaccional);
        }

        public void ValidarInformacion(CatalogoTrx objetoTransaccional)
        {
            
        }
    }
}
