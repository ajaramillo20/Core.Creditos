using Core.Creditos.Model.Entidad.HistorialSolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.HistorialSolicitudCreditos
{
    public class ObtenerHistorialSolicitudCreditoResponse
    {
        public List<HistorialSolicitudCredito> Historial { get; set; }
        public ObtenerHistorialSolicitudCreditoResponse()
        {
            Historial = new List<HistorialSolicitudCredito>();
        }
    }
}
