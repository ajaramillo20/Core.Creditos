using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;


namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class AgregarSolicitudCreditoBLL
    {
        public static void AgregarsolicitudCredito(SolicitudCreditoTrx objetoTransaccional)
        {
            var agregarSolicitudCreditoResult = AgregarSolicitudCreditoDAL.Execute(objetoTransaccional);
            objetoTransaccional.NumeroSolicitudCredito = agregarSolicitudCreditoResult.NumeroSolicitudCredito;
            objetoTransaccional.ClienteNombre = agregarSolicitudCreditoResult.ClienteNombre;
        }
    }
}
