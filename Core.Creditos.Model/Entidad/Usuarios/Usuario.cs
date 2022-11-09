using Core.Creditos.Model.Entidad.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Creditos.Model.Entidad.Usuarios
{
    public class Usuario
    {
        public int UsuarioBPMId { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty;
        public string UsuarioNombreRed { get; set; } = string.Empty;
        public bool UsuarioActivo { get; set; }
        public List<Rol> Roles { get; set; } = new List<Rol>();
    }
}
