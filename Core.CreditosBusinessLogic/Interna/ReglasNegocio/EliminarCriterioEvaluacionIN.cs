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
    public class EliminarCriterioEvaluacionIN : IEliminar<ReglaNegocioTrx, ReglaNegocioResponse>
    {
        public void AgregarInformacion(ReglaNegocioTrx objetoTransaccional)
        {
            
        }

        public void Eliminarnformacion(ReglaNegocioTrx objetoTransaccional)
        {
            ReglasNegocioEliminarInformacionBLL.EliminarCriterioEvaluacion(objetoTransaccional.IdCriterioEliminar);
        }

        public void ValidarInformacion(ReglaNegocioTrx objetoTransaccional)
        {
            
        }
    }
}
