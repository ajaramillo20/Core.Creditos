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
    public static class ValidarPoliticaIngresosSolicitudCreditoDAL
    {
        /// <summary>
        /// Valida los ingresos del deudor y conyuge
        /// </summary>
        /// <param name="ingresosDeudor"></param>
        /// <param name="otrosIngresosDeudor"></param>
        /// <param name="ingresosConyuge"></param>
        /// <param name="otrosIngresosConyuge"></param>
        /// <param name="codigoPolitica"></param>
        /// <returns></returns>
        public static int Execute(decimal? ingresosDeudor, decimal? otrosIngresosDeudor, decimal? ingresosConyuge, decimal? otrosIngresosConyuge, string codigoPolitica)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_POLITICA_VALIDAR_INGRESOS.PARAM_INGRESOS_DEUDOR, ingresosDeudor, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_POLITICA_VALIDAR_INGRESOS.PARAM_OTROS_INGRESOS_DEUDOR, otrosIngresosDeudor, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_POLITICA_VALIDAR_INGRESOS.PARAM_INGRESOS_CONYUGE, ingresosConyuge, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_POLITICA_VALIDAR_INGRESOS.PARAM_OTROS_INGRESOS_CONYUGE, otrosIngresosConyuge, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_POLITICA_VALIDAR_INGRESOS.PARAM_CODIGO_POLITICA_INGRESOS, codigoPolitica, System.Data.DbType.String);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);
            
            var resultado = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_POLITICA_VALIDAR_INGRESOS.PA_NOMBRE, dynamicParameters);
            return resultado;
        }
    }
}
