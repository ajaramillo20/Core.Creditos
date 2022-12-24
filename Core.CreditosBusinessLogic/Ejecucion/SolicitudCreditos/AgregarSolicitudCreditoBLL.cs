using Core.Creditos.Adapters.Core.Notificaciones;
using Core.Creditos.DataAccess.HistorialSolicitud;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Ejecucion.Concesionarios;
using Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos;

namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class AgregarSolicitudCreditoBLL
    {
        public static void AgregarsolicitudCredito(SolicitudCreditoTrx objetoTransaccional)
        {
            objetoTransaccional.SolicitudCredito.Solicitud.Responsable = objetoTransaccional.Responsable;
            var agregarSolicitudCreditoResult = AgregarSolicitudCreditoDAL.Execute(objetoTransaccional);
            objetoTransaccional.NumeroSolicitudCredito = agregarSolicitudCreditoResult.NumeroSolicitudCredito;
            objetoTransaccional.ClienteNombre = agregarSolicitudCreditoResult.ClienteNombre;
            objetoTransaccional.CodigoEstadoSolicitudCredito = agregarSolicitudCreditoResult.CodigoEstadoSolicitudCredito;
            objetoTransaccional.MensajeRespuestaSolicitudCredito = agregarSolicitudCreditoResult.NombreEstadoSolicitudCredito;

            var concesionario = AgregarInformacionConcesionarioBLL.ObtenerConcesionario(objetoTransaccional.Credenciales.Codigo);
            AgregarHistorialSolicitudCreditoDAL.Execute(concesionario.Nombre, objetoTransaccional.CodigoEstadoSolicitudCredito, (int)objetoTransaccional.NumeroSolicitudCredito, "");

            EstadoCreditoValidarInformacionBLL.ValidaAccionesEstado(objetoTransaccional);            
        }        
    }
}
