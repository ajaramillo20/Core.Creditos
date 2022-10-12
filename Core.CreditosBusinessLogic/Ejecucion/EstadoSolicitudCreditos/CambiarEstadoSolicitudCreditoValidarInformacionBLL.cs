using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.EstadoSolicitudCreditos;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.CambiarEstadoSolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos
{
    public static class CambiarEstadoSolicitudCreditoValidarInformacionBLL
    {
        public static void ValidarCambioDeEstado(CambiarEstadoSolicitudCreditoTrx objetoTransaccional)
        {
            var codigoResultado = ValidarCambioDeEstadoSolicitudCreditoDAL.Execute(objetoTransaccional.IdEstadoSolicitudCredito, objetoTransaccional.IdEstadoSolicitudCreditoDestino);
            if (codigoResultado!= (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(codigoResultado);
            }            
        }
    }
}
