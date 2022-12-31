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
    public class ObtenerCriteriosEvaluacionIN : IObtenerTodos<ReglaNegocioTrx, ReglaNegocioResponse>
    {
        public void AgregarInformacion(ReglaNegocioTrx objetoTransaccional)
        {
            ReglasNegocioAgregarInformacionBLL.ObtenerCriteriosEvaluacion(objetoTransaccional);
        }

        public void ValidarInformacion(ReglaNegocioTrx objetoTransaccional)
        {
            
        }
    }
}
