using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.Usuarios
{
    public class UsuarioTrx : TransaccionBase
    {
        public UsuarioTrx()
        {
            Usuarios = new List<Usuario>();
            InformacionUsuario = new Usuario();
        }

        public List<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Variable usada  en obtenerInformacionUsuario
        /// </summary>
        public Usuario InformacionUsuario { get; set; }
        public string[] CodigosRoles { get; set; }
    }
}
