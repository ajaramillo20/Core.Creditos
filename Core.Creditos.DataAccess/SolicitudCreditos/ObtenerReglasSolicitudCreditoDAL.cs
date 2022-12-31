using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.ReglasNegocio;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.SolicitudCreditos
{
    public static class ObtenerReglasSolicitudCreditoDAL
    {
        /// <summary>
        /// Procedimiento almacenado para obtener todos las reglas
        /// que se requiere validar
        /// </summary>
        /// <param name="codigoCredencial"></param>
        /// <returns></returns>
        public static List<ObtenerReglasSolicitudCreditoResult> Execute(string codigoCredencial)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_REGLAS_SOLICITUD_CREDITO.PARAM_CODIGO_ENTIDAD, codigoCredencial, System.Data.DbType.String);
            var resultado = coneccion.ObtenerListaDatos<ObtenerReglasSolicitudCreditoResult>(ConstantesPA.PA_CRE_OBTENER_REGLAS_SOLICITUD_CREDITO.PA_NOMBRE, dynamicParameters);
            return resultado;
        }

        public static List<CriterioEvaluacion> Execute()
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();
            
            var resultado = coneccion.ObtenerListaDatos<CriterioEvaluacion>(ConstantesPA.PA_CRE_OBTENER_REGLAS_SOLICITUD_CREDITO.PA_NOMBRE, dynamicParameters);
            return resultado;
        }

        public class ObtenerReglasSolicitudCreditoResult
        {
            public string TipoDato { get; set; }
            public string CampoRequest { get; set; }
            public string EvaluacionDescripcion { get; set; }
            public string ValorEsperado { get; set; }
            public string Operador { get; set; }
            public bool IndicaError { get; set; }
        }
    }
}

