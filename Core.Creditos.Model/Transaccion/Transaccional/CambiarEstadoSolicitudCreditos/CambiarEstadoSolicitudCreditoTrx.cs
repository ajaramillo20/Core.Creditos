using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.CambiarEstadoSolicitudCreditos
{
    public class CambiarEstadoSolicitudCreditoTrx : TransaccionBase
    {
        public string NumeroSolicitudCredito { get; set; }

        public int EstadoSolicitudCreditoDestinoId { get; set; }

        public int EstadoSolicitudCreditoId { get; set; }
        public string NombreEstadoSolicitud { get; set; }
        public DateTime FechaProcesoSolicitud { get; set; }
    }
}
