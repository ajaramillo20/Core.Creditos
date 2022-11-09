using Core.Creditos.Model.Entidad.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.Usuarios
{
    public class ObtenerUsuariosResponse
    {
        public ObtenerUsuariosResponse()
        {
            Usuarios = new List<Usuario>();
        }

        public List<Usuario> Usuarios { get; set; }
    }
}
