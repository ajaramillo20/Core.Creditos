using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.DataAccess.TiposCreditosRol;
using Core.Creditos.Model.Transaccion.Response.TiposCredito;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.HistorialSolicitud
{
    public static class AgregarHistorialSolicitudCreditoDAL
    {
        public static void Execute(string usuarioRed, string estadoCodigo, int numeroSolicitud, string comentario)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_HISTORIAL_SOLICITUD_CREDITO.PARAM_USUARIO_RED, usuarioRed, System.Data.DbType.String);
            if (!string.IsNullOrEmpty(estadoCodigo))
            {
                dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_HISTORIAL_SOLICITUD_CREDITO.PARAM_ESTADO_CODIGO, estadoCodigo, System.Data.DbType.String);
            }
            dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_HISTORIAL_SOLICITUD_CREDITO.PARAM_NUMERO_SOLICITUD, numeroSolicitud, System.Data.DbType.Int32);
            dynamicParameters.Add(ConstantesPA.PA_CRE_AGREGAR_HISTORIAL_SOLICITUD_CREDITO.PARAM_COMENTARIO, comentario, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.CodigoRetorno, System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            var result = coneccion.Ejecutar<int>(ConstantesPA.PA_CRE_AGREGAR_HISTORIAL_SOLICITUD_CREDITO.PA_NOMBRE, dynamicParameters);
        }
    }
}
