using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Roles;
using Core.Creditos.Model.Entidad.Usuarios;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Roles
{
    public class ObtenerRolesDAL
    {
        public static List<Rol> Execute(string codigo, string nombre)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(codigo))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_ROLES.PARAM_CODIGO, codigo, System.Data.DbType.String);

            if (!string.IsNullOrEmpty(nombre))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_ROLES.PARAM_NOMBRE, nombre, System.Data.DbType.String);

            return coneccion.ObtenerListaDatos<Rol>(ConstantesPA.PA_CRE_OBTENER_ROLES.PA_NOMBRE, dynamicParameters);
        }
    }
}
