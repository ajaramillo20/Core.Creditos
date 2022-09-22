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
        /// Nombre de usuario, se obtiene del JWT
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Codigo entidad, se obtiene del JWT
        /// </summary>
        public string CodigoEntidad { get; set; }        

        /// <summary>
        /// Respuesta aprobado o negado
        /// </summary>
        public string MensajeRespuestaSolicitudCredito { get; set; } = "";

        /// <summary>
        /// Codigo del estado aprobado
        /// </summary>
        public string CodigoEstadoSolicitudCredito { get; set; }

        /// <summary>
        /// Respuesta número de solicitud
        /// </summary>
        public int NumeroSolicitud { get; set; }

        /// <summary>
        /// Datos Solicitud Crédito
        /// </summary>
        public SolicitudCredito? SolicitudCredito { get; set; }

        /// <summary>
        /// Indica si cumple politica de edad
        /// </summary>
        public bool CumplePoliticaEdad { get; set; }

        /// <summary>
        /// Indica si cumple politica de ingresos
        /// </summary>
        public bool CumplePoliticaIngresos { get; set; }

        public string SolicitudCreditoJsonRequest { get; set; } = "";
    }
}
