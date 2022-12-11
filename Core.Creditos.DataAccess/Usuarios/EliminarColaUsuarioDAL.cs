using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Usuarios
{
    public static class EliminarColaUsuarioDAL
    {
        public static void Execute(string nombreRed, string codigoRol)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_ELIMINAR_USUARIO_COLA.PARAM_NOMBRE_RED, nombreRed, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_ELIMINAR_USUARIO_COLA.PARAM_CODIGO_ROL, codigoRol, System.Data.DbType.String);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            var result = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_ELIMINAR_USUARIO_COLA.PA_NOMBRE, dynamicParameters);
            
        }
    }
}
