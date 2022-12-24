using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Concesionarios;
using Core.Creditos.Model.Entidad.Usuarios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Concesionarios
{
    public static class ObtenerListaConcesionariosDAL
    {
        public static List<Concesionario> Execute(string nombre = "", string ruc = "", string codigoCredencial = "")
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(nombre))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_CONCESIONARIOS.PARAM_NOMBRE, nombre, System.Data.DbType.String);

            if (!string.IsNullOrEmpty(ruc))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_CONCESIONARIOS.PARAM_RUC, ruc, System.Data.DbType.String);

            if (!string.IsNullOrEmpty(codigoCredencial))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_CONCESIONARIOS.PARAM_CODIGO_CREDENCIAL, codigoCredencial, System.Data.DbType.String);

            return coneccion.ObtenerListaDatos<Concesionario>(ConstantesPA.PA_CRE_OBTENER_CONCESIONARIOS.PA_NOMBRE, dynamicParameters);
        }
    }
}
