using Core.Creditos.DataAccess.ReglasNegocio;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.ReglasNegocio
{
    public class ReglasNegocioAgregarInformacionBLL
    {
        /// <summary>
        /// OBtiene parametro evaluación
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ObtenerParametrosEvaluacion(ReglaNegocioTrx objetoTransaccional)
        {
            objetoTransaccional.ParametrosEvaluacion = ObtenerParametrosEvaluacionDAL.Execute();
        }

        /// <summary>
        /// Obtiene criterio evaluación
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ObtenerCriteriosEvaluacion(ReglaNegocioTrx objetoTransaccional)
        {
            objetoTransaccional.CriteriosEvaluacion = ObtenerReglasSolicitudCreditoDAL.Execute();
        }
    }
}
