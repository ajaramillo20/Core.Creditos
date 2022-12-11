using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.Roles;
using Core.Creditos.Model.Entidad.Usuarios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core.Records.NotUsed;

namespace Core.Creditos.DataAccess.Usuarios
{
    public class ObtenerInformacionUsuarioDAL
    {
        public static Usuario Execute(string usuarioRed)
        {
            Usuario usuarioResult = null;

            DBConnectionHelper conexion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection,SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(ConstantesPA.PA_CRE_OBTENER_INFORMACION_USUARIO.PA_USUARIO_RED, usuarioRed, System.Data.DbType.String);

            var resultado = conexion.ObtenerListaDatos<ObtenerInformacionUsuarioResult>(ConstantesPA.PA_CRE_OBTENER_INFORMACION_USUARIO.PA_NOMBRE, parametros);
            var usuario = resultado.Count > 0 ? resultado.First() : null;
            if (usuario != null)
            {
                usuarioResult = new Usuario
                {
                    UsuarioBPMId = usuario.UsuarioBPMId,
                    UsuarioNombre = usuario.UsuarioNombre,
                    UsuarioNombreRed = usuario.UsuarioNombreRed,
                    UsuarioActivo = usuario.UsuarioActivo
                };

                resultado.ForEach(f => usuarioResult.Roles.Add(
                    new Rol()
                    {
                        RolId = f.RolId,
                        RolCodigo = f.RolCodigo,
                        RolNombre = f.RolNombre,
                        EsAdmin = f.EsAdmin
                    }
                    ));
            }

            return usuarioResult;
        }

        public class ObtenerInformacionUsuarioResult
        {
            public int UsuarioBPMId { get; set; }
            public string UsuarioNombreRed { get; set; } = string.Empty;
            public string UsuarioNombre { get; set; } = string.Empty;
            public bool UsuarioActivo { get; set; }
            public int RolId { get; set; }
            public string RolCodigo { get; set; } = string.Empty;
            public string RolNombre { get; set; } = string.Empty;
            public bool EsAdmin { get; set; }
        }
    }
}
