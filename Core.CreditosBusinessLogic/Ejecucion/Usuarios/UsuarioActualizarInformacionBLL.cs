using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.Usuarios;
using Core.Creditos.Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.Usuarios
{
    public class UsuarioActualizarInformacionBLL
    {
        /// <summary>
        /// Actualiza información usuario
        /// </summary>
        /// <param name="usuarioNombreRed"></param>
        /// <param name="usuarioNombre"></param>
        /// <param name="codigosRoles"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        internal static void Actualizar(string usuarioNombreRed, string usuarioNombre, string[] codigosRoles)
        {
            var codigosComa = string.Join(",", codigosRoles);
            var result = ActualizarUsuarioDAL.Execute(usuarioNombreRed, usuarioNombre, codigosComa);
            if (result != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(result);
            }
        }
    }
}
