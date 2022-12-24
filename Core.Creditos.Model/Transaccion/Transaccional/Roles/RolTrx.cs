using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.Roles
{
    public class RolTrx : TransaccionBase
    {
        public List<Rol> ListaRoles = new List<Rol>();

        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
    }
}
