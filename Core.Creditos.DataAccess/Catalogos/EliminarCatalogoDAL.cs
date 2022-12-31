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

namespace Core.Creditos.DataAccess.Catalogos
{
    public static class EliminarCatalogoDAL
    {
        /// <summary>
        /// sp para eliminar un catalogo
        /// </summary>
        /// <param name="codigoCatalogo"></param>
        /// <returns></returns>
        public static int Execute(string codigoCatalogo)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_ELIMINAR_CATALOGO.PARAM_CODIGO, codigoCatalogo, System.Data.DbType.String);
            

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_ELIMINAR_CATALOGO.PA_NOMBRE, dynamicParameters);
            return resultado;
        }
    }
}
