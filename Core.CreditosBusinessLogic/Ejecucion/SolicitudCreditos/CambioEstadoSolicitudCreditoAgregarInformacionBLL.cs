using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.EstadoSolicitudCreditos;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.CambiarEstadoSolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class CambioEstadoSolicitudCreditoAgregarInformacionBLL
    {
        public static void ObtenerInformacionCambioEstadoSolicitud(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {
            var solicitud = ObtenerSolicitudCreditoPorNumeroDAL.Execute(objetoTransaccional.NumeroSolicitudCredito);
            if (solicitud == null) throw new ExcepcionServicio((int)ErroresSolicitudCredito.SolicitudNoEncontrada);
            objetoTransaccional.IdEstadoSolicitudCredito = solicitud.EstadoId;
            objetoTransaccional.NombreEstadoSolicitud = solicitud.EstadoNombre;
            objetoTransaccional.CodigoEstadoSolicitudCredito = solicitud.EstadoCodigo;
            objetoTransaccional.CredencialCodigoSolicitudCredito = solicitud.CodigoCredencial;

            objetoTransaccional.IdEstadoSolicitudCreditoOrigen = solicitud.EstadoId;
            objetoTransaccional.NombreEstadoSolicitudCreditoOrigen = solicitud.EstadoNombre;
            objetoTransaccional.CodigoEstadoSolicitudCreditoOrigen = solicitud.EstadoCodigo;
        }

        internal static void ObtenerInformacionEstadoDestino(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {
            var estado = ObtenerEstadoSolicitudCreditoDAL.Execute(idEstado: objetoTransaccional.IdEstadoSolicitudCreditoDestino);
            objetoTransaccional.CodigoEstadoSolicitudCreditoDestino = estado.CodigoEstado;
            objetoTransaccional.NombreEstadoSolicitudCreditoDestino = estado.NombreEstado;
        }
    }
}
