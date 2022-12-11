using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Roles;
using Core.Creditos.Model.Entidad.Usuarios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.Usuarios
{
    public class ObtenerUsuariosDAL
    {
        public static List<Usuario> Execute()
        {
            var result = new List<Usuario>();
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            var listaUsuariosActivos = coneccion.ObtenerListaDatos<ObtenerUsuariosResult>(ConstantesPA.PA_CRE_OBTENER_USUARIOS.PA_NOMBRE, dynamicParameters);

            var usuariosAgrupados = listaUsuariosActivos.GroupBy(grp => grp.UsuarioNombreRed).ToList();


            foreach (var usr in usuariosAgrupados)
            {
                var usrKey = usr.Key;
                var informacion = usr.FirstOrDefault();
                var usuario = new Usuario
                {
                    UsuarioBPMId = informacion.UsuarioBPMId,
                    UsuarioNombre = informacion.UsuarioNombre,
                    UsuarioNombreRed = informacion.UsuarioNombreRed,
                    UsuarioActivo = informacion.UsuarioActivo
                };

                foreach (var rol in usr)
                {
                    usuario.Roles.Add(new Rol
                    {
                        RolCodigo = rol.RolCodigo,
                        RolId = rol.RolId,
                        RolNombre = rol.RolNombre
                    });
                }
                result.Add(usuario);
            }
            return result;
        }
        public class ObtenerUsuariosResult
        {
            public int UsuarioBPMId { get; set; }
            public string UsuarioNombreRed { get; set; } = string.Empty;
            public string UsuarioNombre { get; set; } = string.Empty;
            public bool UsuarioActivo { get; set; }
            public int RolId { get; set; }
            public string RolCodigo { get; set; } = string.Empty;
            public string RolNombre { get; set; } = string.Empty;
        }
    }
}
