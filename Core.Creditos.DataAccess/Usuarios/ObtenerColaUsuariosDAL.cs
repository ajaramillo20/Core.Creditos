using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Roles;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Usuarios
{
    public static class ObtenerColaUsuariosDAL
    {
        public static List<ObtenerColaUsuariosResult> Execute()
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            //dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_USUARIO_COLA.PARAM_NOMBRE_RED, usr.UsuarioBPMId, System.Data.DbType.Int32);
            //dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_USUARIO_COLA.PARAM_CODIGO_ROL, rol.RolCodigo, System.Data.DbType.Boolean);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            var result = coneccion.ObtenerListaDatos<ObtenerColaUsuariosResult>(ConstantesPA.PA_CRE_OBTENER_USUARIOS_COLA.PA_NOMBRE, dynamicParameters);
            return result;
        }
    }

    public class ObtenerColaUsuariosResult
    {
        public string NombreRed { get; set; }
        public string CodigoRol { get; set; }
        public int Orden { get; set; }
    }

}
