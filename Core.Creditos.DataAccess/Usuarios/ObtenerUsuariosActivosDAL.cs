using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Usuarios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Usuarios
{
    public class ObtenerUsuariosActivosDAL
    {
        public static List<ObtenerUsuariosActivosResult> Execute()
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
            var dynamicParameters = new DynamicParameters();

            var listaUsuariosActivos = coneccion.ObtenerListaDatos<ObtenerUsuariosActivosResult>(ConstantesPA.PA_CRE_OBTENER_USUARIOS_ACTIVOS.PA_NOMBRE, dynamicParameters);
            return listaUsuariosActivos;
        }
        public class ObtenerUsuariosActivosResult
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string UsuarioRed { get; set; }
        }
    }
}
