using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.ReglasNegocio;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.ReglasNegocio
{
    public class ObtenerParametrosEvaluacionDAL
    {
        public static List<ParametroEvaluacion> Execute()
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();
                      
            var resultado = coneccion.ObtenerListaDatos<ParametroEvaluacion>("PA_CRE_OBTENER_PARAMETROS_EVALUACION", dynamicParameters);
            return resultado;
        }
    }
}
