using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Creditos.Adapters.Core.Originarsa.Models
{
    public class UsuarioCO
    {
        [JsonProperty("usU_USERNAME")]
        [JsonPropertyName("usU_USERNAME")]
        public string UsuarioRed { get; set; }

        [JsonProperty("usU_IDENTIFICACION")]
        [JsonPropertyName("usU_IDENTIFICACION")]
        public string Identificacion { get; set; }

        [JsonProperty("usU_ID")]
        [JsonPropertyName("usU_ID")]
        public int Id { get; set; }

        [JsonProperty("usU_NOMBRE")]
        [JsonPropertyName("usU_NOMBRE")]
        public string Nombre { get; set; }

        [JsonProperty("usU_ESTADO")]
        [JsonPropertyName("usU_ESTADO")]
        public int Estado { get; set; }

        [JsonProperty("peR_ID")]
        [JsonPropertyName("peR_ID")]
        public int PerId { get; set; }

        [JsonProperty("usU_FECHA_ULTIMO_ACCESO")]
        [JsonPropertyName("usU_FECHA_ULTIMO_ACCESO")]
        public string FechaUltimoAcceso { get; set; }

        
        [JsonProperty("usU_EQUIPO")]
        [JsonPropertyName("usU_EQUIPO")]
        public string Equipo { get; set; }

        [JsonProperty("geRENCIA")]
        [JsonPropertyName("geRENCIA")]
        public string Gerencia { get; set; }

        [JsonProperty("coRREO")]
        [JsonPropertyName("coRREO")]
        public string Correo { get; set; }

        [JsonProperty("uSU_TIPO_ROL")]
        [JsonPropertyName("uSU_TIPO_ROL")]
        public int RolId { get; set; }
    }
}
