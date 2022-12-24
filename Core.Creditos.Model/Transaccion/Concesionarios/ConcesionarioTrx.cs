using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.Concesionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Concesionarios
{
    public class ConcesionarioTrx : TransaccionBase
    {
        //Variables generales - consulta
        public string Nombre { get; set; } = "";
        public string Ruc { get; set; } = "";
        public string CodigoCredencial { get; set; } = "";
        public List<Concesionario> ListaConcesionarios { get; set; } = new List<Concesionario>();
    }
}
