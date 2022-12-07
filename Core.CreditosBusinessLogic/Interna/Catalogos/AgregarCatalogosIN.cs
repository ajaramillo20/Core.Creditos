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
    public class AgregarCatalogosIN : IInsertar<CatalogoTrx, AgregarCatalogoResponse>
    {
        public void AgregarInformacion(CatalogoTrx objetoTransaccional)
        {
            AgregarInformacionCatalogoBLL.AgregarCatalogo(objetoTransaccional);
        }

        public void HomologarInformacion(CatalogoTrx objetoTransaccional)
        {
            
        }

        public void InsertarInformacion(CatalogoTrx objetoTransaccional)
        {
            
        }

        public void ValidarInformacion(CatalogoTrx objetoTransaccional)
        {
            
        }
    }
}
