using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.Plantilla
{
    /// <summary>
    /// Entidad plantilla email
    /// </summary>
    public class Plantilla
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
    }
}
