using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.Usuarios;
using Core.Creditos.Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.Usuarios
{
    public class UsuarioInsertarInformacionBLL
    {
        public static void Insertar(string usuarioNombre, string usuarioNombreRed, string[] codigosRoles)
        {
            string rolesComas = string.Join(",", codigosRoles);
            var result = InsertarUsuarioDAL.Execute(usuarioNombre, usuarioNombreRed, rolesComas);
            if (result != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(result);
            }
        }
    }
}
