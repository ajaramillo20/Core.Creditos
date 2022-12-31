using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.DataAccess.Parametrizacion;
using Core.Creditos.Model.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.Parametrizacion
{
    /// <summary>
    /// Capa BL para actualizar información de parametros
    /// </summary>
    public class ParametrizacionActualizarInformacionBLL
    {
        /// <summary>
        /// Actualiza parametro de configuración
        /// </summary>
        /// <param name="codigoActualizar"></param>
        /// <param name="valorActualizar"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void ActualizarParametro(string codigoActualizar, string valorActualizar)
        {
            var result = ActualizarParametroDAL.Execute(codigoActualizar, valorActualizar);
            if (result!= (int)CodigosSolicitudCredito.OK)
            {
                throw new ExcepcionServicio(result);
            }
        }
    }
}
