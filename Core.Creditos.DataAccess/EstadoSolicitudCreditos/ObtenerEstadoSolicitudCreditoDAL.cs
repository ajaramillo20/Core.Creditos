using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Creditos.DataAccess.Parametrizacion.ObtenerParametrizacionCreditosDAL;

namespace Core.Creditos.DataAccess.EstadoSolicitudCreditos
{
    public static class ObtenerEstadoSolicitudCreditoDAL
    {
        public static ObtenerEstadoSolicitudCreditoResult Execute(int? idEstado=null, string codigoEstado="", string nombreEstado="")
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();


            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_ESTADO_SOLICITUD_CREDITO.PARAM_ID_ESTADO, idEstado==null?null:(int)idEstado, System.Data.DbType.Int32);
            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_ESTADO_SOLICITUD_CREDITO.PARAM_CODIGO_ESTADO, string.IsNullOrEmpty(codigoEstado) ? null : codigoEstado, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_ESTADO_SOLICITUD_CREDITO.PARAM_NOMBRE_ESTADO, string.IsNullOrEmpty(nombreEstado) ? null : nombreEstado, System.Data.DbType.String);            

            var resultado = coneccion.ObtenerListaDatos<ObtenerEstadoSolicitudCreditoResult>(ConstantesPA.PA_CRE_OBTENER_ESTADO_SOLICITUD_CREDITO.PA_NOMBRE, dynamicParameters);
            return resultado.First();
        }

        public class ObtenerEstadoSolicitudCreditoResult
        {
            public string IdEstado { get; set; }
            public string CodigoEstado { get; set; }
            public string NombreEstado { get; set; }
            public string CredencialCodigo { get; set; }
        }
    }
}
