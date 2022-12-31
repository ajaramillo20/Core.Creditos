using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.EstadoSolicitudCreditos
{
    public class InsertarEstadoCreditoDAL
    {
        public static int Execute(string codigo, string nombre, bool requiereEnvioEmail, string idDestinos="")        
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Codigo", codigo, DbType.String);
            dynamicParameters.Add("@Nombre", nombre, DbType.String);
            dynamicParameters.Add("@RequiereEnvioEmail", requiereEnvioEmail, DbType.Boolean);
            dynamicParameters.Add("@Destinos", idDestinos, DbType.String);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, DbType.Int32, direction: ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>("PA_CRE_INSERTAR_ESTADO_CREDITO", dynamicParameters);
            return resultado;
        }
    }
}
