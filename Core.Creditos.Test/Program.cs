using Core.Common.Util.Helper.API;
using Core.Common.Util.Helper.Autenticacion;
using Core.Creditos.Adapters;
using Core.Creditos.Adapters.Core.Notificaciones;

using Core.Creditos.DataAccess.Usuarios;
using Core.Creditos.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SelectPdf;
using System.Dynamic;

var builder = WebApplication.CreateBuilder();





var x = builder.Configuration.GetValue<string>("UrlBaseAdapters:CoreSeguridades");
SettingsHelper.ObtenerJsonAppSetings(builder.Configuration);


var aaa = builder.Configuration.GetValue<string>("UrlBaseAdapters:CoreSeguridades");

builder.Services.AddHttpClient("CoreSeguridades", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("UrlBaseAdapters:CoreSeguridades"));
    client.Timeout = new TimeSpan(0, 0, 50);
    //client.DefaultRequestHeaders.Clear
});


var servicio = builder.Services.BuildServiceProvider();
var httpClientFactory = servicio.GetRequiredService<IHttpClientFactory>();
HttpClientHelper.InyectHttpClientHelper(httpClientFactory);

EnviarNotificacionCorreoADP.EnviarCorreoAsignacion("ajaramillo", "100476");

return 0;