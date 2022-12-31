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
    public class ActualizarUsuarioDAL
    {
        public static int Execute(string usuarioNombreRed, string usuarioNombre, string codigosComa)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Nombre",usuarioNombre, System.Data.DbType.String);
            dynamicParameters.Add("@NombreRed", usuarioNombreRed, System.Data.DbType.String);
            dynamicParameters.Add("@CodigosRoles", codigosComa, System.Data.DbType.String);
            
            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);
            int resultado = coneccion.Ejecutar<int>("PA_CRE_ACTUALIZAR_USUARIO", dynamicParameters);
            return resultado;
        }
    }
}
