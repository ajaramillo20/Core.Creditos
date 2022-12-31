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
    /// <summary>
    /// sp para actualizar criterio de evaluación
    /// </summary>
    public class ActualizarParametroEvaluacionDAL
    {
        public static int Execute(string codigo, string? tipoDato = null, string? campo = null, string? descripcion = null)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Codigo", codigo, System.Data.DbType.String);
            dynamicParameters.Add("@TipoDato", tipoDato, System.Data.DbType.String);
            dynamicParameters.Add("@Campo", campo, System.Data.DbType.String);
            dynamicParameters.Add("@Descripcion", descripcion, System.Data.DbType.String);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>("PA_CRE_ACTUALIZAR_PARAMETRO_EVALUACION", dynamicParameters);
            return resultado;
        }
    }
}
