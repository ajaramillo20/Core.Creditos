using Core.Common.Model.ExcepcionServicio;
using Core.Common.Util.Helper.API;
using Core.Creditos.Adapters;
using Core.Creditos.DataAccess.General;
using Core.Creditos.DataAccess.Parametrizacion;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.DataAccess.TiposCreditosRol;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Response.TiposCredito;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Microsoft.JSInterop.Implementation;
using System.Text.Json;

namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class SolicitudCreditoAgregarInformacionBLL
    {
        public static void AgregarJsonPeticionSolicitudCredito(SolicitudCreditoTrx objetoTransaccional)
        {
            string jsonString = JsonSerializer.Serialize(objetoTransaccional.SolicitudCredito);
            objetoTransaccional.SolicitudCreditoJsonRequest = jsonString;
        }

        /// <summary>
        /// Calcula edad del deudor/Cliente por el campo de fecha nacimiento
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        /// <exception cref="Exception"></exception>
        public static void CalcularEdadCliente(SolicitudCreditoTrx objetoTransaccional)
        {
            try
            {
                var cliente = objetoTransaccional?.SolicitudCredito?.Solicitud?.Cliente;
                var fechaNacimiento = cliente.FechaNacimiento;
                objetoTransaccional.EdadCliente = DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Calcula los ingresos totales = ingresosTotalDeudor + IgresoTotalConyuge
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        internal static void CalcularIngresosTotalCliente(SolicitudCreditoTrx objetoTransaccional)
        {
            var informacionCredito = objetoTransaccional?.SolicitudCredito?.Solicitud?.InformacionCredito;
            var ingresosDeudor = decimal.Add(informacionCredito?.IngresosDeudor ?? 0, informacionCredito?.OtrosIngresosDeudor ?? 0);
            var ingresosConyuge = decimal.Add(informacionCredito?.IngresosConyuge ?? 0, informacionCredito?.OtrosIngresosConyuge ?? 0);
            objetoTransaccional.IngresoTotalCliente = decimal.Add(ingresosDeudor, ingresosConyuge);
        }

        public static void ObtenerResponsableCola(SolicitudCreditoTrx objetoTransaccional)
        {
            var codigoProductoHomologado = objetoTransaccional.SolicitudCredito.Solicitud.CodigoProducto;
            var rolPermitido = objetoTransaccional.TipoCreditoRolList.FirstOrDefault(f => f.CodigoProducto == codigoProductoHomologado);
            if (rolPermitido == null)
            {
                throw new ExcepcionServicio((int)ErrorUsuarios.UsuarioNoEncontrado);
            }

            var responsable = QueueResponsables.GetResponsableEnCola(rolPermitido.CodigoRol, objetoTransaccional?.SolicitudCredito?.Solicitud?.CodigoConcesionario);
            if (responsable == null)
            {
                throw new ExcepcionServicio((int)ErrorUsuarios.UsuarioNoEncontrado);
            }

            objetoTransaccional.Responsable = responsable.UsuarioNombreRed;
        }

        public static void ObtenerResponsableColaAutomatico(SolicitudCreditoTrx objetoTransaccional)
        {
            if (string.IsNullOrEmpty(objetoTransaccional.Responsable))
            {
                var codigoProductoHomologado = objetoTransaccional.InformacionSolicitudCredito.CodigoProducto;
                var rolPermitido = objetoTransaccional.TipoCreditoRolList.FirstOrDefault(f => f.CodigoProducto == codigoProductoHomologado);
                if (rolPermitido == null)
                {
                    throw new ExcepcionServicio((int)ErrorUsuarios.UsuarioNoEncontrado);
                }

                var responsable = QueueResponsables.GetResponsableEnCola(rolPermitido.CodigoRol, objetoTransaccional?.InformacionSolicitudCredito?.CodigoConcesionario);
                if (responsable == null)
                {
                    throw new ExcepcionServicio((int)ErrorUsuarios.UsuarioNoEncontrado);
                }

                objetoTransaccional.Responsable = responsable.UsuarioNombreRed;
            }
        }

        public static void ObtenerTipoCreditosRol(SolicitudCreditoTrx objetoTransaccional)
        {
            objetoTransaccional.TipoCreditoRolList = ObtenerTipoCreditoRolDAL.Execute();
        }
    }
}
