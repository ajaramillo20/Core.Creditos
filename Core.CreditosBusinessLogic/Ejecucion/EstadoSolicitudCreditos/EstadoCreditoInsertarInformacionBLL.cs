using Core.Creditos.DataAccess.EstadoSolicitudCreditos;
using Core.Creditos.Model.Entidad.EstadoCredito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos
{
    /// <summary>
    ///  Capa BL insertar información de estados de crédito
    /// </summary>
    public static class EstadoCreditoInsertarInformacionBLL
    {
        /// <summary>
        /// Inserta un estado nuevo
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="estadosDestino"></param>
        public static void InsertarEstadoCredito(EstadoCredito estado, List<int> estadosDestino)
        {
            var estadosComa = estadosDestino.Count>0?string.Join(",", estadosDestino): string.Empty;
            InsertarEstadoCreditoDAL.Execute(estado.Codigo, estado.Nombre, estado.RequiereEnvioEmail,estadosComa);
        }
    }
}
