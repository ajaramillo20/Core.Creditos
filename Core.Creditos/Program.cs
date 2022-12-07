using Core.Common.Util.Helper.Autenticacion;
using Core.Common.Util.Helper.API;
using Core.Common.Util.Helper.Internal;
using Core.Creditos.Adapters;
using Google.Protobuf.WellKnownTypes;
using Core.Creditos.Helpers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

//Configuración JWT;
JwtHelper.ConfigurarServicioJWT(builder);
//Configurar Settings Helper
SettingsHelper.ObtenerJsonAppSetings(builder.Configuration);
LogHelper.ConfigurarServicio(builder);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
QueueResponsables.StartQueueService();

var env = builder.Configuration.GetValue<string>("Env:Name");
Console.WriteLine(env);

builder.Services.AddHttpClient("CoreSeguridades", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("UrlBaseAdapters:CoreSeguridades"));
    client.Timeout = new TimeSpan(0, 0, 50);
    //client.DefaultRequestHeaders.Clear
});


var servicio = builder.Services.BuildServiceProvider();
var httpClientFactory = servicio.GetRequiredService<IHttpClientFactory>();
HttpClientHelper.InyectHttpClientHelper(httpClientFactory);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cors => cors
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(Any => true)
.AllowCredentials()
);



app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
