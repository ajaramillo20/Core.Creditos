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
using static Core.Creditos.DataAccess.Catalogos.ObtenerInformacionCatalogoDAL;

namespace Core.Creditos.DataAccess.Catalogos
{
    public static class ObtenerCatalogosDAL
    {
        /// <summary>
        /// sp para obtener un catalogo externo
        /// </summary>
        /// <param name="codigoTabla"></param>
        /// <param name="codigoCatalogo"></param>
        /// <returns></returns>
        public static List<Catalogo> Execute(string codigoTabla="", string? codigoCatalogo="")
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(codigoTabla))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_CATALOGO.PARAM_CODIGO_TABLA, codigoTabla, System.Data.DbType.String);

            if (!string.IsNullOrEmpty(codigoCatalogo))
                dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_CATALOGO.PARAM_CODIGO_CATALOGO, codigoCatalogo, System.Data.DbType.String);


            var resultado = coneccion.ObtenerListaDatos<Catalogo>(ConstantesPA.PA_CRE_OBTENER_CATALOGO.PA_NOMBRE, dynamicParameters);
            return resultado;
        }
    }
}
