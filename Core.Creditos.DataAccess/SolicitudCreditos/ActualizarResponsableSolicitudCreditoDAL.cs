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
    public class ActualizarResponsableSolicitudCreditoDAL
    {
        public static int Execute(int numeroSolicitud, string responsableNuevo, string usuarioAplicacion)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_ACTUALIZAR_RESPONSABLE.PARAM_NUMERO_SOLICITUD, numeroSolicitud, System.Data.DbType.Int32);
            dynamicParameters.Add(ConstantesPA.PA_CRE_ACTUALIZAR_RESPONSABLE.PARAM_RESPONSABLE_NUEVO, responsableNuevo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_ACTUALIZAR_RESPONSABLE.PARAM_USUARIO_APLICACION, usuarioAplicacion, System.Data.DbType.String);            

            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            var resultado = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_ACTUALIZAR_RESPONSABLE.PA_NOMBRE, dynamicParameters);
            return resultado;
        }
    }
}
