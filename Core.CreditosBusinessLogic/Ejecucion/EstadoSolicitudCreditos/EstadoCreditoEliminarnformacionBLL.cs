using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.EstadoSolicitudCreditos;
using Core.Creditos.Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos
{
    public class EstadoCreditoEliminarnformacionBLL
    {
        /// <summary>
        /// Elimina estado por codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void EliminarEstado(string codigo)
        {
            var result = EliminarEstadoCreditoDAL.Execute(codigo);
            if (result!= (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(result);
            }
        }
    }
}
