using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.CambiarEstadoSolicitudCreditos
{
    public class CambiarEstadoSolicitudCreditoResponse
    {
        public string NumeroSolicitud { get; set; }
        public string MensajeCambioDeEstado { get; set; }
        public string CodigoEstado { get; set; }
        public string NombreEstado { get; set; }
        public Dictionary<string, string> ResultadoActualizacion { get; set; }
    }
}
