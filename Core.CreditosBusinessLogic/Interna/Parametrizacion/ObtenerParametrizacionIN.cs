using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Model.Transaccion.Response.Parametrizacion;
using Core.Creditos.Model.Transaccion.Transaccional.Parametrizacion;
using Core.CreditosBusinessLogic.Ejecucion.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.Parametrizacion
{
    public class ObtenerParametrizacionIN : IObtenerTodos<ParametroTrx, ObtenerParametrizacionResponse>
    {
        public void AgregarInformacion(ParametroTrx objetoTransaccional)
        {
            ParametrizacionAgregarInformacionBLL.ObtenerParametrizacion(objetoTransaccional);
        }

        public void ValidarInformacion(ParametroTrx objetoTransaccional)
        {
            
        }
    }
}
