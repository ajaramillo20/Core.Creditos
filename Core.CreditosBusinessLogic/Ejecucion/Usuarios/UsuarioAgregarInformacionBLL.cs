using Core.Common.Model.ExcepcionServicio;
using Core.Common.Model.Transaccion.Base;
using Core.Common.Util.Helper.API;
using Core.Common.Util.Helper.Internal;
using Core.Creditos.DataAccess.Usuarios;
using Core.Creditos.Model.Entidad.Usuarios;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.CreditosBusinessLogic.Ejecucion.Usuarios
{
    public static class UsuarioAgregarInformacionBLL
    {
        internal static void ObtenerListaDeUsuarios(UsuarioTrx objetoTransaccional)
        {
            var usuariosActivos = ObtenerUsuariosDAL.Execute();
            objetoTransaccional.Usuarios = usuariosActivos.ToList();
        }

        /// <summary>
        /// Obtiene los datos del usuario con sus roles
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void ObtenerInformacionUsuario(UsuarioTrx objetoTransaccional)
        {
            var inforamcionUsuario = ObtenerInformacionUsuarioDAL.Execute(objetoTransaccional.InformacionUsuario.UsuarioNombreRed);
            if (inforamcionUsuario==null)
            {
                throw new ExcepcionServicio((int)ErrorUsuarios.UsuarioNoEncontrado,objetoTransaccional.InformacionUsuario.UsuarioNombreRed);
            }
            objetoTransaccional.InformacionUsuario = inforamcionUsuario;
        }
    }
}
