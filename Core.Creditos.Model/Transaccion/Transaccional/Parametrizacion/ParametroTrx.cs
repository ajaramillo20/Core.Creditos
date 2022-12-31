using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.Parametrizacion
{
    /// <summary>
    /// Objeto transaccional parametros
    /// </summary>
    public class ParametroTrx : TransaccionBase
    {
        public string CodigoObtener { get; set; }=string.Empty;

        public List<Parametro> Parametros = new List<Parametro>();

        public string CodigoActualizar { get; set; } = string.Empty;
        public string ValorActualizar { get; set; }= string.Empty;  

    }
}
