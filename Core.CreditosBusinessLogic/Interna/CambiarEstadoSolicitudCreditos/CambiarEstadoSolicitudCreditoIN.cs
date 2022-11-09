using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Adapters.Core.Originarsa;
using Core.Creditos.DataAccess.EstadoSolicitudCreditos;
using Core.Creditos.DataAccess.HistorialSolicitud;
using Core.Creditos.Model.Transaccion.Response.CambiarEstadoSolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.CambiarEstadoSolicitudCreditos;
using Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos;
using Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.CambiarEstadoSolicitudCreditos
{
    public class CambiarEstadoSolicitudCreditoIN : IActualizar<CambiarEstadoSolicitudCreditoTrx, CambiarEstadoSolicitudCreditoResponse>
    {


        public void AgregarInformacion(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {            
            CambioEstadoSolicitudCreditoAgregarInformacionBLL.ObtenerInformacionCambioEstadoSolicitud(objetoTransaccional);
            CambioEstadoSolicitudCreditoAgregarInformacionBLL.ObtenerInformacionEstadoDestino(objetoTransaccional);
            
        }

        public void HomologarInformacion(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {

        }

        public void ValidarInformacion(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {
            //Valida policitcas de estados
            CambiarEstadoSolicitudCreditoValidarInformacionBLL.ValidarCambioDeEstado(objetoTransaccional);
        }

        public void ActualizarInformacion(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {
            ActualizarEstadoSolicitudCreditoBLL.ActualizarEstadoSolicitudCredito(objetoTransaccional);
            ActualizarEstadoSolicitudCreditoBLL.NotificarCambioEstado(objetoTransaccional);            
        }        
    }
}
