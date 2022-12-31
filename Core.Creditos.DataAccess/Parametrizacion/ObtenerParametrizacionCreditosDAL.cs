using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Parametrizacion
{
    public static class ObtenerParametrizacionCreditosDAL
    {
        public static ObtenerParametrizacionCreditosResult Execute(ParametrizacionCreditos codigoParametrizacion, string codigoCredencial="")
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

                        
            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_PARAMETRIZACION.PARAM_CODIGO_PARAMETRIZACION, codigoParametrizacion.ToString(), System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_PARAMETRIZACION.PARAM_CODIGO_CREDENCIAL, string.IsNullOrEmpty(codigoCredencial)?null: codigoCredencial, System.Data.DbType.String);

            var resultado = coneccion.ObtenerListaDatos<ObtenerParametrizacionCreditosResult>(ConstantesPA.PA_CRE_OBTENER_PARAMETRIZACION.PA_NOMBRE, dynamicParameters);
            return resultado.First();
        }

        public static List<Parametro> Execute(string? codigo = null)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();


            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_PARAMETRIZACION.PARAM_CODIGO_PARAMETRIZACION, codigo, System.Data.DbType.String);
            
            var resultado = coneccion.ObtenerListaDatos<Parametro>(ConstantesPA.PA_CRE_OBTENER_PARAMETRIZACION.PA_NOMBRE, dynamicParameters);
            return resultado;
        }

        public class ObtenerParametrizacionCreditosResult
        {
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
            public string Valor { get; set; }
        }
    }
}
