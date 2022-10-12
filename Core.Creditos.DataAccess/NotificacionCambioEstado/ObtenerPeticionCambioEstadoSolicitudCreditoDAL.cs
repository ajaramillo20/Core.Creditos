﻿using Core.Common.DataAccess.Helper;
using Core.Common.Model.General;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.NotificacionCambioEstado
{
    public static class ObtenerPeticionCambioEstadoSolicitudCreditoDAL
    {
        public static GetPeticionCabeceraResult Execute(string codigoCredencial)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(ConstantesPA.PA_CRE_API_OBTENER_DATOS_PETICION.PARAM_CODIGO_CREDENCIAL, codigoCredencial, System.Data.DbType.String);

            DBConnectionHelper databaseTemplate = new DBConnectionHelper(EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
            var peticion = databaseTemplate.ObtenerListaDatos<GetPeticionCabeceraResult>(ConstantesPA.PA_CRE_API_OBTENER_DATOS_PETICION.PA_NOMBRE, parametros).FirstOrDefault();

            if (peticion != null)
            {
                databaseTemplate = new DBConnectionHelper(EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
                var headers = databaseTemplate.ObtenerListaDatos<ParametrosPeticionResult>(ConstantesPA.PA_CRE_API_OBTENER_DATOS_PETICION.PA_NOMBRE_HEADERS, parametros);

                databaseTemplate = new DBConnectionHelper(EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
                var queryParams = databaseTemplate.ObtenerListaDatos<ParametrosPeticionResult>(ConstantesPA.PA_CRE_API_OBTENER_DATOS_PETICION.PA_NOMBRE_QUERY_PARAMS, parametros);
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
            public List<ParametrosPeticionResult> Headers { get; set; } = new List<ParametrosPeticionResult>();

            public List<ParametrosPeticionResult> QueryParams { get; set; } = new List<ParametrosPeticionResult>();
        }

        public class ParametrosPeticionResult
        {
            public string Nombre { get; set; }
            public string Valor { get; set; }
        }
    }
}
