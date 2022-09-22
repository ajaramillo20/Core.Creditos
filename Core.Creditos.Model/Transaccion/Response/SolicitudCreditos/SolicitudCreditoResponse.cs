using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.SolicitudCreditos
{
    /// <summary>
    /// Respuesta
    /// </summary>
    public class SolicitudCreditoResponse
    {
        /// <summary>
        /// Mensaje de respuesta, Aprobado o Negado
        /// </summary>
        public string MensajeRespuestaSolicitudCredito { get; set; } = "";

        /// <summary>
        /// Id solicitud registrada
        /// </summary>
        public int NumeroSolicitudCredito { get; set; }

        /// <summary>
        /// Codigo del estado de la solicitud
        /// </summary>
        public string ClienteNombre { get; set; }
    }
}
