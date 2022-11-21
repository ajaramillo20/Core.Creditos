using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Usuarios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Usuarios
{
    public static class AgregarColaUsuariosDAL
    {
        public static void Execute(List<Usuario> usuariosList)
        {
			try
			{
				foreach (var usr in usuariosList)
				{
					foreach (var rol in usr.Roles)
					{
                        DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
                        var dynamicParameters = new DynamicParameters();

                        dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_USUARIO_COLA.PARAM_NOMBRE_RED, usr.UsuarioNombreRed, System.Data.DbType.String);
                        dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_USUARIO_COLA.PARAM_CODIGO_ROL, rol.RolCodigo, System.Data.DbType.String);

                        dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

                        int resultado = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_AGREGAR_USUARIO_COLA.PA_NOMBRE, dynamicParameters);
                    }
                    
                }
            }
			catch (Exception ex)
			{

				
			}
        }
    }
}
