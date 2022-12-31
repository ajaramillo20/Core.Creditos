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
    public class AgregarCriterioEvaluacionDAL
    {
        public static int Execute(string codigoConcesionario, string codigoParametro, string evaluacionDescripcion, string operador, string valorEsperado, bool indicaError)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@CodigoParametro",codigoParametro, System.Data.DbType.String);
            dynamicParameters.Add("@CodigoConcesionario",codigoConcesionario, System.Data.DbType.String);
            dynamicParameters.Add("@Descripcion",evaluacionDescripcion, System.Data.DbType.String);
            dynamicParameters.Add("@CodigoOperador",operador, System.Data.DbType.String);
            dynamicParameters.Add("@Valor",valorEsperado, System.Data.DbType.String);
            dynamicParameters.Add("@IndicaError",indicaError, System.Data.DbType.Boolean);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>("PA_CRE_AGREGAR_CRITERIO_EVALUACION", dynamicParameters);
            return resultado;
        }
    }
}
