using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.ReglasNegocio;
using Core.Creditos.Model.Entidad.ReglasNegocio;
using Core.Creditos.Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.ReglasNegocio
{
    public class ReglasNegocioInsertarInformacionBLL
    {
        /// <summary>
        /// Inserta parametro evaluación
        /// </summary>
        /// <param name="parametroInsertar"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void InsertarParametroEvaluacion(ParametroEvaluacion parametroInsertar)
        {
            var result = AgregarParametroEvaluacionDAL.Execute(parametroInsertar.Codigo, parametroInsertar.TipoDato, parametroInsertar.CampoTransaccional, parametroInsertar.Descripcion);
            if (result != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(result);
            }

        }

        /// <summary>
        /// inserta criterio´evaluación
        /// </summary>
        /// <param name="criterioInsertar"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void InsertarCriterioEvaluacion(CriterioEvaluacion criterioInsertar)
        {
            var result = AgregarCriterioEvaluacionDAL.Execute(
                                                                criterioInsertar.CodigoConcesionario,
                                                                criterioInsertar.CodigoParametro,
                                                                criterioInsertar.EvaluacionDescripcion,
                                                                criterioInsertar.CodigoOperador,
                                                                criterioInsertar.ValorEsperado,
                                                                criterioInsertar.IndicaError
                                                               );
            if (result != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(result);
            }
        }
    }
}
