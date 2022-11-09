using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class SolicitudCreditoActualizarInformacionBLL
    {
        public static void ActualizarResponsable(SolicitudCreditoTrx objetoTransaccional)
        {
            var result = ActualizarResponsableSolicitudCreditoDAL.Execute(Convert.ToInt32(objetoTransaccional.InformacionSolicitudCredito.NumeroSolicitud), objetoTransaccional.Responsable, objetoTransaccional.UsuarioAplicacion);
            if (result != (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(result);
            }
        }
    }
}
