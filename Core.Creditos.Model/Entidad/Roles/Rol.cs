using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.Roles
{
    public class Rol
    {
        public int RolId { get; set; }
        public string RolCodigo { get; set; }
        public string RolNombre { get; set; }
        public bool EsAdmin { get; set; }
    }
}
