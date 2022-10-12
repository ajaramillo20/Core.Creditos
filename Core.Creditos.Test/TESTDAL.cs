using Core.Common.DataAccess.Helper;
using Core.Common.Model.General;
using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Test
{
    public static class TESTDAL
    {
        public static GetPeticionCabeceraResult GetRespuestaconfig()
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@CodigoCredencial", "MAR_001", System.Data.DbType.String);

            DBConnectionHelper databaseTemplate = new DBConnectionHelper(EnumDBConnection.SqlConnection, DBConnectionString.BD_CONFIGURACIONES_DEV);
            var peticion = databaseTemplate.ObtenerListaDatos<GetPeticionCabeceraResult>("PA_CON_API_OBTENER_DATOS_PETICION", parametros).FirstOrDefault();

            if (peticion != null)
            {
                databaseTemplate = new DBConnectionHelper(EnumDBConnection.SqlConnection, DBConnectionString.BD_CONFIGURACIONES_DEV);
                var headers = databaseTemplate.ObtenerListaDatos<ParametrosPeticion>("PA_CON_API_OBTENER_HEADERS_PETICION", parametros);

                databaseTemplate = new DBConnectionHelper(EnumDBConnection.SqlConnection, DBConnectionString.BD_CONFIGURACIONES_DEV);
                var queryParams = databaseTemplate.ObtenerListaDatos<ParametrosPeticion>("PA_CON_API_OBTENER_QUERY_PARAMS_PETICION", parametros);
                peticion.Headers = headers;
                peticion.QueryParams = queryParams;
            }
            return peticion;
        }

        public class GetPeticionCabeceraResult
        {
            public string Url { get; set; }
            public string Metodo { get; set; }
            public string ContentType { get; set; }
            public string CredencialCodigo { get; set; }
            public string Content { get; set; }
            public List<ParametrosPeticion> Headers { get; set; }

            public List<ParametrosPeticion> QueryParams { get; set; }
        }

        public class ParametrosPeticion
        {
            public string Nombre { get; set; }
            public string Valor { get; set; }
        }


    }
}
