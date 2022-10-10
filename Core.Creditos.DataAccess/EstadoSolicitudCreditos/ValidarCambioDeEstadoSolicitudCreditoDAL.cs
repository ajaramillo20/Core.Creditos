using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.EstadoSolicitudCreditos
{
    public static class ValidarCambioDeEstadoSolicitudCreditoDAL
    {
        public static int Execute(int estadoOrigenId, int estadoDestinoId)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_VALIDAR_CAMBIO_ESTADO_SOLICITUD_CREDITO.PARAM_ESTADO_ORIGEN_ID, estadoOrigenId, System.Data.DbType.Int32);
            dynamicParameters.Add(ConstantesPA.PA_CRE_VALIDAR_CAMBIO_ESTADO_SOLICITUD_CREDITO.PARAM_ESTADO_DESTINO_ID, estadoDestinoId, System.Data.DbType.Int32);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_VALIDAR_CAMBIO_ESTADO_SOLICITUD_CREDITO.PA_NOMBRE, dynamicParameters);
            return resultado;
        }        
    }
}
