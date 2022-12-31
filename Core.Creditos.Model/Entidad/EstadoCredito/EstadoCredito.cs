using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.EstadoCredito
{
    /// <summary>
    /// Entidad estado crédito
    /// </summary>
    public class EstadoCredito
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool RequiereComentario { get; set; }
        public bool RequiereEnvioEmail { get; set; }        
    }
}
