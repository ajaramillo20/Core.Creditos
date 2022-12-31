using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Creditos.Model.Entidad.EstadoCredito;
using Core.Creditos.Model.Transaccion.Request.EstadosSolicitud;
using Core.Creditos.Model.Transaccion.Response.EstadosCreditos;
using Core.Creditos.Model.Transaccion.Response.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.EstadosCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Interna.EstadosSolicitudCredito;
using Core.CreditosBusinessLogic.Interna.SolicitudCreditos;
using Microsoft.AspNetCore.Mvc;

namespace Core.Creditos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet]
        [Route("ObtenerEstadosCredito")]
        [Produces(typeof(EstructuraBase<ObtenerEstadosCreditoResponse>))]
        public IActionResult ObtenerEstadosCredito(int? estadoId = null, string? estadoCodigo = "")
        {
            EstadoCreditoTrx transaccion = this.GenerarTransaccion<EstadoCreditoTrx>();
            transaccion.IdObtener = estadoId;
            transaccion.CodigoObtener = estadoCodigo??string.Empty;

            EstructuraBase<ObtenerEstadosCreditoResponse> respuesta = this.ObtenerTodos<EstadoCreditoTrx, ObtenerEstadosCreditoResponse, ObtenerEstadosCreditoIN>(
                new ObtenerEstadosCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpPost]
        [Route("AgregarEstadoSolicitudCredito")]
        [Produces(typeof(EstructuraBase<EstadosResponse>))]
        public IActionResult AgregarEstadoSolicitudCredito([FromBody] EstadoRequest estado)
        {
            EstadoCreditoTrx transaccion = this.GenerarTransaccion<EstadoCreditoTrx>();
            transaccion.EstadoCredito = estado.Estado;
            transaccion.EstadosDestino = estado.EstadosDestino;
            

            EstructuraBase<EstadosResponse> respuesta = this.Insertar<EstadoCreditoTrx, EstadosResponse, AgregarEstadoCreditoIN>(
                new AgregarEstadoCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("ActualizarEstadoSolicitudCredito")]
        [Produces(typeof(EstructuraBase<EstadosResponse>))]
        public IActionResult ActualizarEstadoSolicitudCredito([FromBody] EstadoRequest estado)
        {
            EstadoCreditoTrx transaccion = this.GenerarTransaccion<EstadoCreditoTrx>();
            transaccion.EstadoCredito = estado.Estado;
            transaccion.EstadosDestino = estado.EstadosDestino;

            EstructuraBase<EstadosResponse> respuesta = this.Actualizar<EstadoCreditoTrx, EstadosResponse, ActualizarEstadoCreditoIN>(
                new ActualizarEstadoCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("EliminarEstadoSolicitudCredito")]
        [Produces(typeof(EstructuraBase<EstadosResponse>))]
        public IActionResult EliminarEstadoSolicitudCredito(string codigo)
        {
            EstadoCreditoTrx transaccion = this.GenerarTransaccion<EstadoCreditoTrx>();
            transaccion.CodigoEliminar = codigo;

            EstructuraBase<EstadosResponse> respuesta = this.Eliminar<EstadoCreditoTrx, EstadosResponse, EliminarEstadoCreditoIN>(
                new EliminarEstadoCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }
    }
}
