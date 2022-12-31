using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.HistorialSolicitudCreditos
{
    /// <summary>
    /// Entidad historial solicitud crédito
    /// </summary>
    public class HistorialSolicitudCredito
    {
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }
    }
}
