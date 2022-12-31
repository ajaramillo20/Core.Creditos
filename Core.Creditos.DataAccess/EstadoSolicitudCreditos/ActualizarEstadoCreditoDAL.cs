using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.EstadoSolicitudCreditos
{
    public class ActualizarEstadoCreditoDAL
    {
        public static int Execute(string codigo, string? nombre = null, bool? requiereComentario = null, bool? requiereEnvioEmail = null, string? estadosComa = null)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Codigo", codigo, System.Data.DbType.String);
            dynamicParameters.Add("@Nombre", nombre, System.Data.DbType.String);
            dynamicParameters.Add("@RequiereComentario", requiereComentario, System.Data.DbType.Boolean);
            dynamicParameters.Add("@RequiereEmail", requiereEnvioEmail, System.Data.DbType.Boolean);
            dynamicParameters.Add("@Destinos", estadosComa, System.Data.DbType.String);

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            int resultado = coneccion.Ejecutar<int>("PA_CRE_ACTUALIZAR_ESTADO_CREDITO", dynamicParameters);
            return resultado;

        }
    }
}
