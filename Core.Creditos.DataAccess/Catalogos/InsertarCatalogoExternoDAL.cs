using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Catalogos;
using Core.Creditos.Model.Entidad.Usuarios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Catalogos
{
    public static class InsertarCatalogoExternoDAL
    {
        /// <summary>
        /// sp para insertar un catalogoe externo
        /// </summary>
        /// <param name="catalogo"></param>
        /// <returns></returns>
        public static int Execute(CatalogoExterno catalogo)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_CATALOGO_EXTERNO.PARAM_CODIGO_EXTERNO, catalogo.CodigoExterno, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_CATALOGO_EXTERNO.PARAM_CODIGO_CATALOGO, catalogo.CodigoCatalogo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_CATALOGO_EXTERNO.PARAM_CODIGO_TABLA, catalogo.CodigoTabla, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_CATALOGO_EXTERNO.PARAM_CODIGO_CREDENCIAL, catalogo.CodigoCredencial, System.Data.DbType.String);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_AGREGAR_CATALOGO_EXTERNO.PA_NOMBRE, dynamicParameters);
            return resultado;
        }
    }
}
