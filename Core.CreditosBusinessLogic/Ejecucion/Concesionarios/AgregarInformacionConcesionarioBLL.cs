
using Core.Creditos.DataAccess.Concesionarios;
using Core.Creditos.Model.Entidad.Concesionarios;
using Core.Creditos.Model.Transaccion.Concesionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.Concesionarios
{
    public static class AgregarInformacionConcesionarioBLL
    {
        public static void ObtenerConcesionarios(ConcesionarioTrx objetoTransaccional)
        {
            objetoTransaccional.ListaConcesionarios = ObtenerListaConcesionariosDAL.Execute(objetoTransaccional.Nombre, objetoTransaccional.Ruc, objetoTransaccional.CodigoCredencial);
        }

        public static Concesionario ObtenerConcesionario(string codigoCredencial)
        {
           return ObtenerListaConcesionariosDAL.Execute(codigoCredencial: codigoCredencial).FirstOrDefault();
        }
    }
}
