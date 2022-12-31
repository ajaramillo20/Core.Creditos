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
    /// <summary>
    /// Capa BL metodos para validar información de estados de solicitud
    /// </summary>
    public static class CambiarEstadoSolicitudCreditoValidarInformacionBLL
    {
        /// <summary>
        /// Verifica si se permite el cambio entre estados
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        /// <exception cref="ExcepcionServicio"></exception>
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
