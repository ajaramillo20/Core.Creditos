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
    public class ActualizarCatalogoExternoDAL
    {
        /// <summary>
        /// SP para actualizar un catálogo externo
        /// </summary>
        /// <param name="catalogoExterno"></param>
        /// <returns></returns>
        public static int Execute(CatalogoExterno catalogoExterno)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_ACTUALIZAR_CATALOGO_EXTERNO.PARAM_ID, catalogoExterno.Id, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_ACTUALIZAR_CATALOGO_EXTERNO.PARAM_CODIGO_EXTERNO, catalogoExterno.CodigoExterno, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_ACTUALIZAR_CATALOGO_EXTERNO.PARAM_CODIGO_CATALOGO, catalogoExterno.CodigoCatalogo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_ACTUALIZAR_CATALOGO_EXTERNO.PARAM_CODIGO_TABLA, catalogoExterno.CodigoTabla, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_ACTUALIZAR_CATALOGO_EXTERNO.PARAM_CODIGO_CREDENCIAL, catalogoExterno.CodigoCredencial, System.Data.DbType.String);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);
            return coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_ACTUALIZAR_CATALOGO_EXTERNO.PA_NOMBRE, dynamicParameters);
        }
    }
}
