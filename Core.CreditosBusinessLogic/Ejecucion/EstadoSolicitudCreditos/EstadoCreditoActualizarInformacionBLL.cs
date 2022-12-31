using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.EstadoSolicitudCreditos;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.Entidad.EstadoCredito;
using Core.Creditos.Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos
{
    public class EstadoCreditoActualizarInformacionBLL
    {
        /// <summary>
        /// Actualiza un estado de crédito
        /// </summary>
        /// <param name="estadoCredito"></param>
        public static void ActualizarEstado(EstadoCredito estadoCredito, List<int> estadosDestino)
        {
            var estadosComa = estadosDestino.Count > 0 ? string.Join(",", estadosDestino) : null;
            var result = ActualizarEstadoCreditoDAL.Execute(estadoCredito.Codigo, estadoCredito.Nombre, estadoCredito.RequiereComentario, estadoCredito.RequiereEnvioEmail,estadosComa);
            if (result!= (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(result);
            }
        }
    }
}
