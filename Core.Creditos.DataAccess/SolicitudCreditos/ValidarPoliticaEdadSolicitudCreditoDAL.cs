using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.SolicitudCreditos
{
    /// <summary>
    /// Procedimiento almacenado PA_CRE_POLITICA_VALIDAD_EDAD
    /// </summary>
    public static class ValidarPoliticaEdadSolicitudCreditoDAL
    {
        public static int Execute(int edadMinima, int edadMaxima, int edadDedeudor)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_POLITICA_VALIDAD_EDAD.PARAM_CODIGO_EDAD_MAXIMA, edadMaxima, System.Data.DbType.Int32);
            dynamicParameters.Add(ConstantesPA.PA_CRE_POLITICA_VALIDAD_EDAD.PARAM_CODIGO_EDAD_MINIMA, edadMinima, System.Data.DbType.Int32);
            dynamicParameters.Add(ConstantesPA.PA_CRE_POLITICA_VALIDAD_EDAD.PARAM_EDAD_DEUDOR, edadDedeudor, System.Data.DbType.Int32);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            var resultado = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_POLITICA_VALIDAD_EDAD.PA_NOMBRE, dynamicParameters);
            return resultado;
        }
    }
}
