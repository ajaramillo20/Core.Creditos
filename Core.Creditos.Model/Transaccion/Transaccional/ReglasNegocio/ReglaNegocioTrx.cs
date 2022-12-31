using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.ReglasNegocio
{
    /// <summary>
    /// Objeto transaccional reglas negocio
    /// </summary>
    public class ReglaNegocioTrx : TransaccionBase
    {        
        public List<ParametroEvaluacion> ParametrosEvaluacion { get; set; } = new List<ParametroEvaluacion>();
        public List<CriterioEvaluacion> CriteriosEvaluacion { get; set; } = new List<CriterioEvaluacion>();

        public ParametroEvaluacion ParametroInsertar = new ParametroEvaluacion();
        public CriterioEvaluacion CriterioInsertar = new CriterioEvaluacion();

        public string CodigoParametroEliminar { get; set; } = "";
        public int IdCriterioEliminar { get; set; }
    }
}
