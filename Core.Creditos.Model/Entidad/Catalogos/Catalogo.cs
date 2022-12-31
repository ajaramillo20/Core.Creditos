using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.Catalogos
{
    /// <summary>
    /// Entidad catálogo
    /// </summary>
    public class Catalogo
    {
        [JsonPropertyName("nombreTabla")]
        public string NombreTabla { get; set; } = string.Empty;

        [JsonPropertyName("codigoTabla")]
        public string CodigoTabla { get; set; } = string.Empty;

        [JsonPropertyName("descripcionTabla")]
        public string DescripcionTabla { get; set; }=string.Empty;

        [JsonPropertyName("codigoCatalogo")]
        public string CodigoCatalogo { get; set; } = string.Empty;

        [JsonPropertyName("nombreCatalogo")]
        public string NombreCatalogo { get; set; } = string.Empty;

        [JsonPropertyName("valorCatalogo")]
        public string ValorCatalogo { get; set; } = string.Empty;

        [JsonPropertyName("descripcionCatalogo")]
        public string DescripcionCatalogo { get; set; } = string.Empty;                
    }
}
