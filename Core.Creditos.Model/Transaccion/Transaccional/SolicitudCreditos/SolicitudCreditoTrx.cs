using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.InformacionSolicitudCreditos;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Response.TiposCredito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos
{
    public class SolicitudCreditoTrx : TransaccionBase
    {
        public SolicitudCreditoTrx()
        {
            ResultadoEvaluacionPoliticas = new Dictionary<string, bool>();
            SolicitudCreditoList = new List<Solicitud>();
        }

        /// <summary>
        /// Respuesta aprobado o negado
        /// </summary>
        public string MensajeRespuestaSolicitudCredito { get; set; } = "";

        /// <summary>
        /// Codigo del estado aprobado
        /// </summary>
        public string? CodigoEstadoSolicitudCredito { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string? ClienteNombre { get; set; }

        /// <summary>
        /// Respuesta número de solicitud
        /// </summary>
        public int? NumeroSolicitudCredito { get; set; }

        /// <summary>
        /// Datos Solicitud Crédito
        /// </summary>
        public SolicitudCredito? SolicitudCredito { get; set; }

        /// <summary>
        /// Indica si cumple politica de edad
        /// </summary>
        public bool? CumplePoliticaEdad { get; set; }

        /// <summary>
        /// Indica si cumple politica de ingresos
        /// </summary>
        public bool CumplePoliticaIngresos { get; set; }

        public string? SolicitudCreditoJsonRequest { get; set; } = "";

        /// <summary>
        /// Almacena temporalmente los ingresos totales del cliente
        /// </summary>
        public decimal? IngresoTotalCliente { get; set; }

        /// <summary>
        /// Almacena temporalmente la edad del cliente
        /// </summary>
        public int? EdadCliente { get; set; }

        public Dictionary<string, bool> ResultadoEvaluacionPoliticas { get; set; }

        public List<Solicitud> SolicitudCreditoList { get; set; }

        public string Responsable { get; set; }


        #region Reasignación

        /// <summary>
        /// Almacena el nombre de la persona que envia la petición
        /// </summary>
        public string UsuarioAplicacion { get; set; }
        public string Comentario { get; set; }

        #endregion
        public InformacionSolicitudCredito InformacionSolicitudCredito { get; set; }
        public List<TipoCreditoRol> TipoCreditoRolList { get; set; }
    }
}
