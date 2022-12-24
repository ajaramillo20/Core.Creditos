using Core.Creditos.DataAccess.Roles;
using Core.Creditos.Model.Transaccion.Transaccional.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.Roles
{
    public static class AgregarInformacionRolBLL
    {
        public static void ObtenerRoles(RolTrx objetoTransaccional)
        {
            objetoTransaccional.ListaRoles = ObtenerRolesDAL.Execute(objetoTransaccional.Codigo, objetoTransaccional.Nombre);
        }
    }
}
