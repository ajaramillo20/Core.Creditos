using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.ReglasNegocio
{
    public class ActualizarCriterioEvaluacionDAL
    {
        /// <summary>
        /// sp para obtener criterios de evaluación
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigoParametro"></param>
        /// <param name="codigoConcesionario"></param>
        /// <param name="evaluacionDescripcion"></param>
        /// <param name="operador"></param>
        /// <param name="valorEsperado"></param>
        /// <param name="indicaError"></param>
        /// <returns></returns>
        public static int Execute(int id, string codigoParametro, string codigoConcesionario, string evaluacionDescripcion, string operador, string valorEsperado, bool indicaError)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Id", id , System.Data.DbType.String);
            dynamicParameters.Add("@CodigoParametro", codigoParametro, System.Data.DbType.String);
            dynamicParameters.Add("@CodigoConcesionario", codigoConcesionario, System.Data.DbType.String);
            dynamicParameters.Add("@Descripcion", evaluacionDescripcion, System.Data.DbType.String);
            dynamicParameters.Add("@CodigoOperador", operador, System.Data.DbType.String);
            dynamicParameters.Add("@Valor",valorEsperado , System.Data.DbType.String);
            dynamicParameters.Add("@IndicaError", indicaError, System.Data.DbType.Boolean);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>("PA_CRE_ACTUALIZAR_CRITERIO_EVALUACION", dynamicParameters);
            return resultado;
        }
    }
}
