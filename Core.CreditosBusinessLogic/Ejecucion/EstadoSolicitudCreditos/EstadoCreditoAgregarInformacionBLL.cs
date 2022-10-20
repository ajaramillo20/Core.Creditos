using Core.Creditos.DataAccess.EstadoSolicitudCreditos;
using Core.Creditos.Model.Entidad.EstadoCredito;
using Core.Creditos.Model.Transaccion.Transaccional.EstadosCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos
{
    public static class EstadoCreditoAgregarInformacionBLL
    {
        public static void ObtenerEstadoCredito(EstadoCreditoTrx objetoTransaccional)
        {
            var estado = ObtenerEstadoSolicitudCreditoDAL.Execute(objetoTransaccional.EstadoCredito.Id);

            objetoTransaccional.EstadoCredito.Nombre = estado.NombreEstado;
            objetoTransaccional.EstadoCredito.Codigo = estado.CodigoEstado;
        }

        internal static void ObtenerFlujoEstadoCredito(EstadoCreditoTrx objetoTransaccional)
        {
            var flujos = ObtenerFlujoEstadoCreditoDAL.Execute(objetoTransaccional.EstadoCredito.Id);
            flujos.ForEach(f => objetoTransaccional.FlujosEstadoCredito.Add(new EstadoCredito
            {
                Id = f.EstadoId,
                Nombre = f.EstadoNombre,
                Codigo = f.EstadoCodigo,
            }));
        }
    }
}
