using Core.Common.Util.Helper.Datos;
using Core.Creditos.Adapters.Models;
using Core.Creditos.DataAccess.NotificacionCambioEstado;
using Core.Creditos.DataAccess.SolicitudCreditos;
using System.Net.Http.Headers;

namespace Core.Creditos.Adapters.NotificacionCambioEstadoSolicitudCredito
{
    public static class NotificarCambioEstadoSolicitudCreditoAdapter
    {
        public static void GetInformacionRequest(string numeroSolicitud)
        {
            var informacionSolicitudCredito = ObtenerSolicitudCreditoPorNumeroDAL.Execute(numeroSolicitud);
            var obtenerDatosPeticion = ObtenerPeticionCambioEstadoSolicitudCreditoDAL.Execute(informacionSolicitudCredito.CodigoCredencial);

            obtenerDatosPeticion.Content = obtenerDatosPeticion.Content.Inject(informacionSolicitudCredito);

            RequestApiExterna requestData = new RequestApiExterna
            {
                Content = obtenerDatosPeticion.Content,
                ContentType = obtenerDatosPeticion.ContentType,
                CredencialCodigo = obtenerDatosPeticion.CredencialCodigo,
                Headers = new List<ParametrosPeticion>(),
                QueryParams = new List<ParametrosPeticion>(),
                Metodo = obtenerDatosPeticion.Metodo,
                Url = obtenerDatosPeticion.Url
            };

            obtenerDatosPeticion.Headers.ForEach(f => requestData.Headers.Add(new ParametrosPeticion { Nombre = f.Nombre, Valor = f.Valor }));
            obtenerDatosPeticion.QueryParams.ForEach(f => requestData.QueryParams.Add(new ParametrosPeticion { Nombre = f.Nombre, Valor = f.Valor }));


            using (var httpClient = new HttpClient())
            {
                if (requestData.QueryParams != null && requestData.QueryParams.Count > 0)
                {
                    string queryParams = requestData.QueryParams == null || requestData.QueryParams.Count == 0 ? "" : "?";
                    foreach (var item in requestData.QueryParams)
                    {
                        queryParams = $"{queryParams}{item.Nombre}={item.Valor}&";
                    }
                    requestData.Url = $"{requestData.Url}{queryParams}";
                }
                using (var request = new HttpRequestMessage(new HttpMethod(requestData.Metodo), requestData.Url))
                {

                    foreach (var para in requestData.Headers)
                    {
                        request.Headers.TryAddWithoutValidation(para.Nombre, para.Valor);
                    }

                    request.Content = new StringContent(requestData.Content);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(requestData.ContentType);

                    var response = httpClient.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
                }
            }


        }
    }
}
