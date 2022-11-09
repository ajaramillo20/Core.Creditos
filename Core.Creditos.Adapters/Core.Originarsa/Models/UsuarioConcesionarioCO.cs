using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Creditos.Adapters.Core.Originarsa.Models
{
    public class UsuarioConcesionarioCO
    {
        [JsonProperty("coN_ID")]
        [JsonPropertyName("coN_ID")]
        public int ConcesionarioId;

        [JsonProperty("usU_ID")]
        [JsonPropertyName("usU_ID")]
        public int UsuarioId;
    }
}
