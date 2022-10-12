using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.SolicitudCreditos
{
    public static class ActualizarEstadoSolicitudCreditoDAL
    {
        public static int Execute(string numeroSolicitud, string codigoEstadoDestino)
        {

            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_CAMBIAR_ESTADO_SOLICITUD_CREDITO.PARAM_NUMERO_SOLICITUD, numeroSolicitud, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_CAMBIAR_ESTADO_SOLICITUD_CREDITO.PARAM_CODIGO_ESTADO_DESTINO, codigoEstadoDestino, System.Data.DbType.String);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_CAMBIAR_ESTADO_SOLICITUD_CREDITO.PA_NOMBRE, dynamicParameters);
            return resultado;
        }
    }
}
