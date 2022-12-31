using Core.Creditos.DataAccess.ReglasNegocio;
using Core.Creditos.Model.Entidad.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.ReglasNegocio
{
    public class ReglasNegocioAtualizarInformacionBLL
    {
        /// <summary>
        /// Actualizar parametro evaluación
        /// </summary>
        /// <param name="parametroActualizar"></param>
        public static void ActualizarParametroEvaluacion(ParametroEvaluacion parametroActualizar)
        {
            ActualizarParametroEvaluacionDAL.Execute(parametroActualizar.Codigo, parametroActualizar.TipoDato, parametroActualizar.CampoTransaccional, parametroActualizar.Descripcion);
        }

        /// <summary>
        /// Actualiza criterio evaluación
        /// </summary>
        /// <param name="criterioInsertar"></param>
        public static void ActualizarCriterioEvaluacion(CriterioEvaluacion criterioInsertar)
        {
            ActualizarCriterioEvaluacionDAL.Execute(
                                                    criterioInsertar.Id,
                                                    criterioInsertar.CodigoParametro,
                                                    criterioInsertar.CodigoConcesionario,
                                                    criterioInsertar.EvaluacionDescripcion,
                                                    criterioInsertar.CodigoOperador,
                                                    criterioInsertar.ValorEsperado,
                                                    criterioInsertar.IndicaError
                                                   );
        }
    }
}
