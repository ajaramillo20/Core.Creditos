using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Catalogos
{
    public static class HomologarCatalogoExternoDAL
    {
        /// <summary>
        /// sp para homologar un catálogo
        /// </summary>
        /// <param name="codigoExterno"></param>
        /// <param name="codigoTabla"></param>
        /// <param name="codigoCredencial"></param>
        /// <returns></returns>
        public static HomologarCatalogoExternoResult Execute(string codigoExterno, string codigoTabla, string codigoCredencial)
        {            
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_HOMOLOGAR_CODIGO_EXTERNO.PARAM_CODIGO_EXTERNO, codigoExterno, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_HOMOLOGAR_CODIGO_EXTERNO.PARAM_CODIGO_TABLA, codigoTabla, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_HOMOLOGAR_CODIGO_EXTERNO.PARAM_CODIGO_CREDENCIAL, codigoCredencial, System.Data.DbType.String);

            var resultado = coneccion.ObtenerListaDatos<HomologarCatalogoExternoResult>(ConstantesPA.PA_CRE_HOMOLOGAR_CODIGO_EXTERNO.PA_NOMBRE, dynamicParameters);
            return resultado.FirstOrDefault();
        }

        public class HomologarCatalogoExternoResult
        {
            public string CodigoExterno { get; set; }
            public string CodigoInterno { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string Valor { get; set; }
        }
    }
}
