using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Catalogos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Catalogos
{
    public class ObtenerCatalogosExternosDAL
    {
        public static List<CatalogoExterno> Execute(string codigoTabla, string codigoCredencial, string codigoCatalogo, string nombreCatalogo)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(codigoTabla))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_CATALOGO_EXTERNO.PARAM_CODIGO_TABLA, codigoTabla, System.Data.DbType.String);

            if (!string.IsNullOrEmpty(codigoCatalogo))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_CATALOGO_EXTERNO.PARAM_CODIGO_CATALOGO, codigoCatalogo, System.Data.DbType.String);

            if (!string.IsNullOrEmpty(codigoCredencial))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_CATALOGO_EXTERNO.PARAM_CODIGO_CREDENCIAL, codigoCredencial, System.Data.DbType.String);

            if (!string.IsNullOrEmpty(nombreCatalogo))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_CATALOGO_EXTERNO.PARAM_CODIGO_NOMBRE, nombreCatalogo, System.Data.DbType.String);

            var resultado = coneccion.ObtenerListaDatos<CatalogoExterno>(ConstantesPA.PA_CRE_OBTENER_CATALOGO_EXTERNO.PA_NOMBRE, dynamicParameters);
            return resultado;
        }
    }
}
