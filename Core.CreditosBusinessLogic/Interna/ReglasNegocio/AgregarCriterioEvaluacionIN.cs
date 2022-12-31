using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Model.Transaccion.Response.ReglasNegocio;
using Core.Creditos.Model.Transaccion.Transaccional.ReglasNegocio;
using Core.CreditosBusinessLogic.Ejecucion.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.ReglasNegocio
{
    public class AgregarCriterioEvaluacionIN : IInsertar<ReglaNegocioTrx, ReglaNegocioResponse>
    {
        public void AgregarInformacion(ReglaNegocioTrx objetoTransaccional)
        {
            
        }

        public void HomologarInformacion(ReglaNegocioTrx objetoTransaccional)
        {
            
        }

        public void InsertarInformacion(ReglaNegocioTrx objetoTransaccional)
        {
            ReglasNegocioInsertarInformacionBLL.InsertarCriterioEvaluacion(objetoTransaccional.CriterioInsertar);
        }

        public void ValidarInformacion(ReglaNegocioTrx objetoTransaccional)
        {
            
        }
    }
}
