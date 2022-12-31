using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Util.Helper.API;
using Core.Creditos.Adapters.Core.Originarsa.Models;
using Org.BouncyCastle.Bcpg.Sig;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Creditos.Adapters.Core.Originarsa
{
    /// <summary>
    /// Adaptador apra microservicio core.originarsa
    /// </summary>
    public static class CoreOriginarsaADP
    {
        /// <summary>
        /// URLS BASE
        /// </summary>
        private static string URLBASE = SettingsHelper.ObtenerSettigsKey("UrlBaseAdapters.CoreOriginarsa");
        private const string ObtenerConcesionario = "/api/Concesionario/ObtenerConcesionario/93F6F130FB85B7BA5F70C2AA3F96E6212B9F3BC3EC20E24506392719C39F308F";
        private const string ObtenerUsuarioEjecutivo = "/api/Usuario/ObtenerUsuarioEjecutivo/93F6F130FB85B7BA5F70C2AA3F96E6212B9F3BC3EC20E24506392719C39F308F";
        private const string ObtenerUsuarioConcesionario = "/api/Usuario/ObtenerUsuarioConcesionario/93F6F130FB85B7BA5F70C2AA3F96E6212B9F3BC3EC20E24506392719C39F308F";

        /// <summary>
        /// Obtiene concesionario
        /// </summary>
        /// <returns></returns>
        public static List<Concesionario> ObtenerConcesionarios()
        {
            var result = new List<Concesionario>();
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{URLBASE}{ObtenerConcesionario}"))
                {
                    //request.Headers.TryAddWithoutValidation("Authorization", "Basic VEVTVC1PUklHSU5BUlNBOjU3RSl1OVk4Rkg=");
                    //request.Content = new StringContent(jsonBody);
                    //request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = httpClient.SendAsync(request).Result.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<List<Concesionario>>(response);
                }
            }
            return result;
        }

        /// <summary>
        /// Obtiene usuario
        /// </summary>
        /// <returns></returns>
        public static List<UsuarioCO> ObtenerUsuarios()
        {
            var result = new List<UsuarioCO>();
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{URLBASE}{ObtenerUsuarioEjecutivo}"))
                {
                    var response = httpClient.SendAsync(request).Result.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<List<UsuarioCO>>(response);
                }
            }
            return result;
        }

        /// <summary>
        /// Obtiene relacion usuario concesionario
        /// </summary>
        /// <returns></returns>
        public static List<UsuarioConcesionarioCO> ObtenerUsuariosConcesionarios()
        {
            var result = new List<UsuarioConcesionarioCO>();
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"{URLBASE}{ObtenerUsuarioConcesionario}"))
                {
                    var response = httpClient.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<UsuarioConcesionarioCO>>(response);
                }
            }
            return result;
        }
    }
}
