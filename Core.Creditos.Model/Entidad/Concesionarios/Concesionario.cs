using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.Concesionarios
{
    /// <summary>
    /// Clase para representar un concesionario externo
    /// </summary>
    public class Concesionario
    {
        /// <summary>
        /// entidad concesionario
        /// </summary>
        public int Id { get; set; }
        public string Nombre { get; set; }=string.Empty;
        public string Ruc { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string CodigoCredencial { get; set; } = string.Empty;
    }
}
