using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Request.Usuarios
{
    public class UsuariosRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string NombreRed { get; set; }=string.Empty;
        public string[] Roles { get; set; }
    }
}
