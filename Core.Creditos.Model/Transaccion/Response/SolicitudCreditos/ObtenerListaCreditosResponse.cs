using Core.Creditos.Model.Entidad.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.SolicitudCreditos
{
    public class ObtenerListaCreditosResponse
    {
        public List<Solicitud> SolicitudCreditos { get; set; }
    }
}
