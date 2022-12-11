using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Creditos.DataAccess.EstadoSolicitudCreditos.ObtenerEstadoSolicitudCreditoDAL;

namespace Core.Creditos.DataAccess.EstadoSolicitudCreditos
{
    public static class ObtenerFlujoEstadoCreditoDAL
    {
        public static List<ObtenerFlujoEstadoCreditoResult> Execute(int estadoId)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_FLUJO_ESTADO_CREDITO.PARRAM_ESTADO_ORIGEN, estadoId, System.Data.DbType.Int32);

            var resultado = coneccion.ObtenerListaDatos<ObtenerFlujoEstadoCreditoResult>(ConstantesPA.PA_CRE_OBTENER_FLUJO_ESTADO_CREDITO.PA_NOMBRE, dynamicParameters);
            return resultado;
        }

        public class ObtenerFlujoEstadoCreditoResult
        {
            public int EstadoId { get; set; }
            public string EstadoNombre { get; set; }
            public string EstadoCodigo { get; set; }
        }
    }
}
