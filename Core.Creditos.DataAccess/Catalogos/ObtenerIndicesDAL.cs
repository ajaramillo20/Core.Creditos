using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Catalogos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Catalogos
{
    public static class ObtenerIndicesDAL
    {
        public static List<Tabla> Execute(string codigoTabla)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(codigoTabla))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_INDICES.PARAM_CODIGO_TABLA, codigoTabla, System.Data.DbType.String);

            var resultado = coneccion.ObtenerListaDatos<Tabla>(ConstantesPA.PA_CRE_OBTENER_INDICES.PA_NOMBRE, dynamicParameters);
            return resultado;
        }
    }
}
