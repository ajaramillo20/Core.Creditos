using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos
{
    public class SolicitudCreditoTrx : TransaccionBase
    {
        /// <summary>
        /// Respuesta aprobado o negado
        /// </summary>
        public string Respuesta { get; set; }

        /// <summary>
        /// Datos Solicitud Crédito
        /// </summary>
        public SolicitudCredito SolicitudCredito { get; set; }
    }
}
