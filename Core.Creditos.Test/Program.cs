using Core.Common.Model.ExcepcionServicio;
using Core.Common.Model.Transaccion.Base;
using Core.Common.Util.Helper.API;
using Core.Common.Util.Helper.Autenticacion;
using Core.Creditos.Adapters;
using Core.Creditos.Adapters.Core.Notificaciones;
using Core.Creditos.Adapters.NotificacionCambioEstadoSolicitudCredito;
using Core.Creditos.DataAccess.Concesionarios;
using Core.Creditos.DataAccess.HistorialSolicitud;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Helpers;
using Core.Creditos.Model.General;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder();

SettingsHelper.ObtenerJsonAppSetings(builder.Configuration);

builder.Services.AddHttpClient("CoreSeguridades", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("UrlBaseAdapters:CoreSeguridades"));
    client.Timeout = new TimeSpan(0, 0, 50);
    //client.DefaultRequestHeaders.Clear
});


var servicio = builder.Services.BuildServiceProvider();
var httpClientFactory = servicio.GetRequiredService<IHttpClientFactory>();
HttpClientHelper.InyectHttpClientHelper(httpClientFactory);


//SCRIPT ACTUALIZACIÓN
List<string> listaSolicitudes = new List<string>() {
 "100097",
"100098",
"100099",
"100100",
"100101",
"100102",
"100103",
"100104",
"100105",
"100106",
"100107",
"100108",
"100109",
"100110",
"100111",
"100112",
"100113",
"100114",
"100115",
"100116",
"100117",
"100118",
"100119",
"100120",
"100121",
"100122",
"100123",
"100124",
"100125",
"100126",
"100127",
"100128",
"100129",
};


string docPath =
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt"));

foreach (var item in listaSolicitudes)
{
    var resultado = NotificadorApiExternaADP.EnviarInformacionRequest(item, "");
    //if (resultado.FirstOrDefault(f => f.Key == "Error").Key != null)
    //{
    //    AgregarHistorialSolicitudCreditoDAL.Execute(item.Value, "-", Convert.ToInt32(item.Key), "Error de comunicación externa".ToUpper());
    //    throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorComunicacion);
    //}
    ////ActualizarEstadoSolicitudCreditoDAL.Execute(item.Key, "EST_CRE_001");
    ////AgregarHistorialSolicitudCreditoDAL.Execute(item.Value, "EST_CRE_001", Convert.ToInt32(item.Key), "");
    //EnviarNotificacionCorreoADP.EnviarCorreoAsignacion(item.Value, item.Key);
    var x = resultado.ToJson();
    outputFile.WriteLine($"Solicitud: {item} {x}");
    
    //Console.WriteLine($"{resultado.ToJson()}");
}
outputFile.Close();

Console.ReadKey();

//QueueResponsables./

return 0;