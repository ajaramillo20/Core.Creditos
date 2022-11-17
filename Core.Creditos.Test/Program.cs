using Core.Common.Util.Helper.API;
using Core.Common.Util.Helper.Autenticacion;
using Core.Creditos.Adapters;
using Core.Creditos.Adapters.Core.Notificaciones;
using Core.Creditos.DataAccess.Usuarios;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using System.Dynamic;

var builder = WebApplication.CreateBuilder(args);

SettingsHelper.ObtenerJsonAppSetings(builder.Configuration);

EnviarNotificacionCorreoADP.ArmarEstructuraCorreo(null, "100363");

return 0;