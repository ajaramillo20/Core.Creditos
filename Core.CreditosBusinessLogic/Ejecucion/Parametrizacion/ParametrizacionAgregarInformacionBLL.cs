using Core.Creditos.DataAccess.Parametrizacion;
using Core.Creditos.Model.Transaccion.Transaccional.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.Parametrizacion
{
    public class ParametrizacionAgregarInformacionBLL
    {
        /// <summary>
        /// Obtiene inforamción parametrización
        /// </summary>
        /// <param name="objetoTransaccionl"></param>
        public static void ObtenerParametrizacion(ParametroTrx objetoTransaccionl)
        {
            objetoTransaccionl.Parametros =  ObtenerParametrizacionCreditosDAL.Execute(objetoTransaccionl.CodigoObtener);
        }
    }
}
