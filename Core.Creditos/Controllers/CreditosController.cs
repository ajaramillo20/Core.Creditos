using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Common.Util.Helper.Autenticacion;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Request.SolicitudCredito;
using Core.Creditos.Model.Transaccion.Response.CambiarEstadoSolicitudCreditos;
using Core.Creditos.Model.Transaccion.Response.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.CambiarEstadoSolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Interna.CambiarEstadoSolicitudCreditos;
using Core.CreditosBusinessLogic.Interna.SolicitudCreditos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
            SolicitudCreditoTrx transaccion = this.GenerarTransaccion<SolicitudCreditoTrx>();
            transaccion.SolicitudCredito = new SolicitudCredito();
            transaccion.SolicitudCredito.Solicitud = request.Solicitud;

            EstructuraBase<SolicitudCreditoResponse> respuesta = this.Insertar<SolicitudCreditoTrx, SolicitudCreditoResponse, SolicitudCreditoIN>(
                new SolicitudCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpPut]
        [Authorize]
        [Route("CambiarEstadoSolicitudCredito")]
        [Produces(typeof(EstructuraBase<CambiarEstadoSolicitudCreditoResponse>))]
        public IActionResult CambiarEstadoSolicitudCredito(string numeroSolicitud, int estadoSolicitudCreditoId)
        {
            CambiarEstadoSolicitudCreditoTrx transaccion = this.GenerarTransaccion<CambiarEstadoSolicitudCreditoTrx>();
            transaccion.NumeroSolicitudCredito = numeroSolicitud;
            transaccion.IdEstadoSolicitudCreditoDestino = estadoSolicitudCreditoId;
            
            EstructuraBase<CambiarEstadoSolicitudCreditoResponse> respuesta = this.Actualizar<CambiarEstadoSolicitudCreditoTrx, CambiarEstadoSolicitudCreditoResponse, CambiarEstadoSolicitudCreditoIN>(
                new CambiarEstadoSolicitudCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }


    

    }
}
