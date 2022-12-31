using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.CambiarEstadoSolicitudCreditos
{
    /// <summary>
    /// Entidad resultado actualizacion de estado solicitud crédito
    /// </summary>
    public class CambiarEstadoSolicitudCreditoResponse
    {
        public string NumeroSolicitud { get; set; }
        public string MensajeCambioDeEstado { get; set; }
        public string CodigoEstado { get; set; }
        public string NombreEstado { get; set; }

        /// <summary>
        /// RESULTADO API EXTERNA
        /// </summary>
        public Dictionary<string, string> ResultadoActualizacion { get; set; }
    }
}
