using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Model.Transaccion.Response.Roles;
using Core.Creditos.Model.Transaccion.Transaccional.Roles;
using Core.CreditosBusinessLogic.Ejecucion.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.Roles
{
    public class ObtenerRolesIN : IObtenerTodos<RolTrx, ObtenerRolesResponse>
    {
        public void AgregarInformacion(RolTrx objetoTransaccional)
        {
            AgregarInformacionRolBLL.ObtenerRoles(objetoTransaccional);
        }

        public void ValidarInformacion(RolTrx objetoTransaccional)
        {
            
        }
    }
}
