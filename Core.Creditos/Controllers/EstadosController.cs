using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Creditos.Model.Entidad.EstadoCredito;
using Core.Creditos.Model.Transaccion.Response.EstadosCreditos;
using Core.Creditos.Model.Transaccion.Response.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.EstadosCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Interna.EstadosSolicitudCredito;
using Core.CreditosBusinessLogic.Interna.SolicitudCreditos;
using Microsoft.AspNetCore.Mvc;

namespace Core.Creditos.Controllers
{
    public class EstadosController : Controller
    {
        [HttpGet]
        [Route("ObtenerFlujosEstadoCredito")]
        [Produces(typeof(EstructuraBase<ObtenerFlujosEstadoCreditoResponse>))]
        public IActionResult ObtenerFlujosEstadoCredito(int estadoId)
        {
            EstadoCreditoTrx transaccion = this.GenerarTransaccion<EstadoCreditoTrx>();
            transaccion.EstadoCredito = new EstadoCredito();
            transaccion.EstadoCredito.Id = estadoId;            

            EstructuraBase<ObtenerFlujosEstadoCreditoResponse> respuesta = this.ObtenerTodos<EstadoCreditoTrx, ObtenerFlujosEstadoCreditoResponse, ObtenerFlujosEstadoCreditoIN>(
                new ObtenerFlujosEstadoCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }
    }
}
