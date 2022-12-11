using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Parametrizacion
{
    public static class ObtenerReglasCamposRequestDAL
    {        
        public static List<ObtenerReglasCamposRequestResult> Execute(string codigoEntidad)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();
            
            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_REGLAS_CAMPOS_REQUEST.PARMA_CODIGO_ENTIDAD, codigoEntidad.ToString(), System.Data.DbType.String);

            var resultado = coneccion.ObtenerListaDatos<ObtenerReglasCamposRequestResult>(ConstantesPA.PA_CRE_OBTENER_REGLAS_CAMPOS_REQUEST.PA_NOMBRE, dynamicParameters);
            return resultado.ToList();
        }

        public class ObtenerReglasCamposRequestResult
        {
            /// <summary>
            /// Campo json del requesst
            /// </summary>
            public string Campo { get; set; }

            /// <summary>
            /// indica si es un campo obligatorio
            /// </summary>
            public bool EsObligatorio { get; set; }

            /// <summary>
            /// indica si el campo requiere homologación
            /// </summary>
            public bool RequiereHomologacion { get; set; }

            /// <summary>
            /// Indica la tabla donde debe homologar en caso de que aplica
            /// </summary>
            public string CodigoTabla { get; set; }            
        }
    }
}
