using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Model.Transaccion.Concesionarios;
using Core.Creditos.Model.Transaccion.Response.Concesionarios;
using Core.CreditosBusinessLogic.Ejecucion.Concesionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.Concesionarios
{
    public class ObtenerConcesionariosIN : IObtenerTodos<ConcesionarioTrx, ObtenerConcesionariosResponse>
    {
        public void AgregarInformacion(ConcesionarioTrx objetoTransaccional)
        {
            AgregarInformacionConcesionarioBLL.ObtenerConcesionarios(objetoTransaccional);
        }

        public void ValidarInformacion(ConcesionarioTrx objetoTransaccional)
        {
            
        }
    }
}
