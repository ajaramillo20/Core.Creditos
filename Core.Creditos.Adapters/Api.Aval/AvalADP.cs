using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Core.Common.Util.Helper.API;

namespace Core.Creditos.Adapters.Api.Aval
{
    public static class AvalADP
    {
        public static async Task<ResultadoBuro> ObtenerInformacionAVAL(string cedula, string ingreso, string monto, string plazo)
        {
            var url = SettingsHelper.ObtenerSettigsKey("AVALAPI.Url");
            var cuerpo = new AvalPostBody();
            var result = new ResultadoBuro();
            cuerpo.request.datosEntrada.Add(new DatosEntrada()
            {
                clave = "tipoIdentificacionSujeto",
                valor = "C"
            });
            cuerpo.request.datosEntrada.Add(new DatosEntrada()
            {
                clave = "identificacionSujeto",
                valor = cedula
            });
            cuerpo.request.datosEntrada.Add(new DatosEntrada()
            {
                clave = "ingresos",
                valor = ingreso.Replace(',', '.')
            });
            cuerpo.request.datosEntrada.Add(new DatosEntrada()
            {
                clave = "gastoFinanciero",
                valor = monto.Replace(',', '.')
            });
            cuerpo.request.datosEntrada.Add(new DatosEntrada()
            {
                clave = "montoSolicitado",
                valor = monto.Replace(',','.')
            });
            cuerpo.request.datosEntrada.Add(new DatosEntrada()
            {
                clave = "plazo",
                valor = plazo.Replace(',', '.')
            });
            cuerpo.request.datosEntrada.Add(new DatosEntrada()
            {
                clave = "gastoHogar",
                valor = "0"
            });

            var jsonBody = JsonConvert.SerializeObject(cuerpo);

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), SettingsHelper.ObtenerSettigsKey("AVALAPI.Url")))
                {

                    request.Headers.TryAddWithoutValidation("Authorization", SettingsHelper.ObtenerSettigsKey("AVALAPI.Key"));
                    request.Content = new StringContent(jsonBody);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request).Result.Content.ReadAsStringAsync();
                    var jsonRespuesta = JObject.Parse(response);

                    result = jsonRespuesta.ToObject<ResultadoBuro>();
                }
            }

            return result;
        }
    }
}
