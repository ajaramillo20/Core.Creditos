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
    public static class ActualizarEstadoUsuarioDAL
    {
        public static int Execute(int usuarioId, bool activar)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_ACTUALIZAR_ESTADO_USUARIO.PARAM_USUARIO_ID, usuarioId, System.Data.DbType.Int32);
            dynamicParameters.Add(ConstantesPA.PA_CRE_ACTUALIZAR_ESTADO_USUARIO.PARAM_ESTADO, activar, System.Data.DbType.Boolean);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_ACTUALIZAR_ESTADO_USUARIO.PA_NOMBRE, dynamicParameters);
            return resultado;
            
        }
    }
}
