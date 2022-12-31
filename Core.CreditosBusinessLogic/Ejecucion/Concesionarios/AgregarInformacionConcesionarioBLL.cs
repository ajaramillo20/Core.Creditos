
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
        /// <summary>
        /// OBtiene lista de concesionarios
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ObtenerConcesionarios(ConcesionarioTrx objetoTransaccional)
        {
            objetoTransaccional.ListaConcesionarios = ObtenerListaConcesionariosDAL.Execute(objetoTransaccional.Nombre, objetoTransaccional.Ruc, objetoTransaccional.CodigoCredencial);
        }

        /// <summary>
        /// Obtiene inoformación concesionario
        /// </summary>
        /// <param name="codigoCredencial"></param>
        /// <returns></returns>
        public static Concesionario ObtenerConcesionario(string codigoCredencial)
        {
           return ObtenerListaConcesionariosDAL.Execute(codigoCredencial: codigoCredencial).FirstOrDefault();
        }
    }
}
