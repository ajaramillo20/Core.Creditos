using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Common.Util.Helper.Autenticacion;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Request.SolicitudCredito;
using Core.Creditos.Model.Transaccion.Response.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Interna.SolicitudCreditos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Creditos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditosController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("SolicitudCredito")]
        [Produces(typeof(EstructuraBase<SolicitudCreditoResponse>))]
        public IActionResult SolicitudCredito([FromBody] SolicitudCreditoRequest request)
        {            
            var token = JwtHelper.DesencriptarJWT(Request);            
            SolicitudCreditoTrx transaccion = this.GenerarTransaccion<SolicitudCreditoTrx>();
            transaccion.SolicitudCredito = new SolicitudCredito();
            transaccion.SolicitudCredito.Solicitud = request.Solicitud;
            //Revisar temas de claims
            
            transaccion.Usuario = JwtHelper.GetClaim(token, "Usuario");
            transaccion.CodigoEntidad = JwtHelper.GetClaim(token, "Entidad");

            EstructuraBase<SolicitudCreditoResponse> respuesta = this.Insertar<SolicitudCreditoTrx, SolicitudCreditoResponse, SolicitudCreditoIN>(
                new SolicitudCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }
    }
}
