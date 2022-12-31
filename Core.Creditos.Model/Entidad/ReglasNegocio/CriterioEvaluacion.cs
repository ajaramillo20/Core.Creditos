using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.ReglasNegocio
{
    /// <summary>
    /// entidad criterio evaluación
    /// </summary>
    public class CriterioEvaluacion
    {
        public int Id { get; set; }
        public string TipoDato { get; set; } = string.Empty;
        public string CampoRequest { get; set; } = string.Empty;
        public string EvaluacionDescripcion { get; set; } = string.Empty;
        public string ValorEsperado { get; set; } = string.Empty;
        public string Operador { get; set; } = string.Empty;
        public string CodigoOperador { get; set; } = string.Empty;        
        public bool IndicaError { get; set; } 
        public string CodigoConcesionario { get; set; } = string.Empty;
        public string CodigoParametro { get; set; } = string.Empty;
        public string NombreConcesionario { get; set; } = string.Empty;
    }
}

