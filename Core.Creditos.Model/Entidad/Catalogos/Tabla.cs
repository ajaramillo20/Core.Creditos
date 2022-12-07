using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.Catalogos
{
    public class Tabla
    {
        [JsonPropertyName("nombreTabla")]
        public string NombreTabla { get; set; } = string.Empty;

        [JsonPropertyName("codigoTabla")]
        public string CodigoTabla { get; set; } = string.Empty;

        [JsonPropertyName("descripcionTabla")]
        public string DescripcionTabla { get; set; } = string.Empty;
    }
}
