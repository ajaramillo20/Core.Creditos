using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Common.Util.Helper.Internal;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.HistorialSolicitudCreditos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.HistorialSolicitud
{
    public class ObtenerHistorialSolicitudCreditoDAL
    {
        public static List<HistorialSolicitudCredito> Execute(int numeroSolicitud)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_HISTORIAL_SOLICITUD_CREDITO.PARAM_NUMERO_SOLICITUD, numeroSolicitud, System.Data.DbType.Int32);

            var result = coneccion.ObtenerListaDatos<ObtenerHistorialSolicitudCreditoResult>(ConstantesPA.PA_CRE_OBTENER_HISTORIAL_SOLICITUD_CREDITO.PA_NOMBRE, dynamicParameters);
            return AutoMapperHelper.MapeoDinamicoListasAutoMapper<HistorialSolicitudCredito, ObtenerHistorialSolicitudCreditoResult>(result);            
        }

        /// <summary>
        /// Resultado Historial
        /// </summary>
        public class ObtenerHistorialSolicitudCreditoResult
        {
            public DateTime Fecha { get; set; }
            public string Usuario { get; set; }
            public string Estado { get; set; }
            public string Comentario { get; set; }
        }
    }
}
