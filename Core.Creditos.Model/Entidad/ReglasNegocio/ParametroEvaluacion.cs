using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.ReglasNegocio
{
    /// <summary>
    /// Entidad Parámetro
    /// </summary>
    public class ParametroEvaluacion
    {
        public string Codigo { get; set; } = string.Empty;
        public string TipoDato { get; set; } = string.Empty;
        public string CampoTransaccional { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
