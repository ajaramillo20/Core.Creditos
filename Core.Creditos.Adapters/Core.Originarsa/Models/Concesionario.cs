using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Creditos.Adapters.Core.Originarsa.Models
{
    /// <summary>
    /// Modelol Micro Servicio Core.Originarsa
    /// </summary>
    public class Concesionario
    {
        [JsonProperty("coN_ID")]        
        [JsonPropertyName("coN_ID")]
        public int Id { get; set; }

        [JsonProperty("coN_NOMBRE")]
        [JsonPropertyName("coN_NOMBRE")]
        public string Nombre { get; set; } = "";

        [JsonProperty("coN_DIRECCION")]
        [JsonPropertyName("coN_DIRECCION")]
        public string Direccion { get; set; } = "";

        [JsonProperty("coN_RUC")]
        [JsonPropertyName("coN_RUC")]
        public string Ruc { get; set; } = "";

        [JsonProperty("coN_GRP_CONCESIONARIO")]
        [JsonPropertyName("coN_GRP_CONCESIONARIO")]
        public string GRPConcesionario { get; set; } = "";

        [JsonProperty("coN_GRP_EMPRESARIAL")]
        [JsonPropertyName("coN_GRP_EMPRESARIAL")]
        public string GRPEmpresarial { get; set; } = "";

        [JsonProperty("coN_RAZON_SOCIAL")]
        [JsonPropertyName("coN_RAZON_SOCIAL")]
        public string RazonSocial { get; set; } = "";

        [JsonProperty("geO_COD_REGION")]
        [JsonPropertyName("geO_COD_REGION")]
        public string Region { get; set; } = "";

        [JsonProperty("geO_COD_PROVINCIA")]
        [JsonPropertyName("geO_COD_PROVINCIA")]
        public string Provincia { get; set; } = "";

        [JsonProperty("geO_COD_CIUDAD")]
        [JsonPropertyName("geO_COD_CIUDAD")]
        public string Ciudad { get; set; } = "";

        [JsonProperty("dcA_ID")]
        [JsonPropertyName("dcA_ID")]
        public int DCAId { get; set; }

        [JsonProperty("coN_ESTADO")]
        [JsonPropertyName("coN_ESTADO")]
        public bool Estado { get; set; }
    }
}
