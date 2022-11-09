using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Creditos.DataAccess.SolicitudCreditos.ObtenerListaSolicitudCreditosDAL;

namespace Core.Creditos.DataAccess.Usuarios
{
    public class ValidarUsuarioResponsableDAL
    {
        public static bool Execute(string usuario)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_VALIDAR_USUARIO_RESPONSABLE.PARAM_USUARIO, usuario, System.Data.DbType.String);
            var resultado = coneccion.ObtenerListaDatos<bool>(ConstantesPA.PA_CRE_VALIDAR_USUARIO_RESPONSABLE.PA_NOMBRE, dynamicParameters).FirstOrDefault();
            return resultado;
        }

        public class ValidarUsuarioResponsableResult
        {
            public bool Activo { get; set; }
        }
    }
}
