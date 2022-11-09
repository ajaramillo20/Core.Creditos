using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Usuarios;
using Core.Creditos.Model.Transaccion.Response.TiposCredito;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Creditos.DataAccess.Usuarios.ObtenerUsuariosDAL;

namespace Core.Creditos.DataAccess.TiposCreditosRol
{
    public class ObtenerTipoCreditoRolDAL
    {
        public static List<TipoCreditoRol> Execute()
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
            var dynamicParameters = new DynamicParameters();

            var listaCreditoRol = coneccion.ObtenerListaDatos<ObtenerTipoCreditoRolResult>(ConstantesPA.PA_CRE_OBTENER_CREDITO_ROL.PA_NOMBRE, dynamicParameters);

            var result = AutoMapperHelper.MapeoDinamicoListasAutoMapper<TipoCreditoRol, ObtenerTipoCreditoRolResult>(listaCreditoRol);

            return result;
        }


    }
    public class ObtenerTipoCreditoRolResult
    {
        public int TipoCreditoRolId { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoRol { get; set; }
        public string NombreRol { get; set; }
    }
}
