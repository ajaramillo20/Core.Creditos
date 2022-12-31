using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.ReglasNegocio;
using Core.Creditos.Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.ReglasNegocio
{
    public class ReglasNegocioEliminarInformacionBLL
    {
        /// <summary>
        /// Elimina parametro evaluación
        /// </summary>
        /// <param name="codigoParametroEliminar"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void EliminarParametroEvaluacion(string codigoParametroEliminar)
        {
            var result = EliminarParametroEvaluacionDAL.Execute(codigoParametroEliminar);
            if (result != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(result);
            }
        }

        /// <summary>
        /// elimina criterio información
        /// </summary>
        /// <param name="idCriterioEliminar"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void EliminarCriterioEvaluacion(int idCriterioEliminar)
        {
            var result = EliminarCriterioEvaluacionDAL.Execute(idCriterioEliminar);
            if (result != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(result);
            }
        }
    }
}
