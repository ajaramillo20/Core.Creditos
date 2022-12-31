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
    public class AgregarParametroEvaluacionDAL
    {
        public static int Execute(string codigo, string tipoDato, string campoTransaccional, string descripcion)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Codigo", codigo, System.Data.DbType.String);
            dynamicParameters.Add("@TipoDato", tipoDato, System.Data.DbType.String);
            dynamicParameters.Add("@Campo", campoTransaccional, System.Data.DbType.String);
            dynamicParameters.Add("@Descripcion", descripcion, System.Data.DbType.String);
            

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>("PA_CRE_AGREGAR_PARAMETRO_EVALUACION", dynamicParameters);
            return resultado;
        }
    }
}
