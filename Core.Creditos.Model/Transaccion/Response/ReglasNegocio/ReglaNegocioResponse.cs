using Core.Creditos.Model.Entidad.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Response.ReglasNegocio
{
    public class ReglaNegocioResponse
    {
        public List<ParametroEvaluacion> ParametrosEvaluacion { get; set; } = new List<ParametroEvaluacion>();
        public List<CriterioEvaluacion> CriteriosEvaluacion { get; set; } = new List<CriterioEvaluacion>();
    }
}
