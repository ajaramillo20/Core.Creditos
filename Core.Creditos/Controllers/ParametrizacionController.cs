using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Creditos.Model.Entidad.EstadoCredito;
using Core.Creditos.Model.Transaccion.Response.EstadosCreditos;
using Core.Creditos.Model.Transaccion.Response.Parametrizacion;
using Core.Creditos.Model.Transaccion.Transaccional.EstadosCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.Parametrizacion;
using Core.CreditosBusinessLogic.Interna.EstadosSolicitudCredito;
using Core.CreditosBusinessLogic.Interna.Parametrizacion;
using Microsoft.AspNetCore.Mvc;

namespace Core.Creditos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrizacionController : Controller
    {
        [HttpGet]
        [Route("ObtenerParametrizacion")]
        [Produces(typeof(EstructuraBase<ObtenerParametrizacionResponse>))]
        public IActionResult ObtenerEstadosCredito(string? codigo = null)
        {
            ParametroTrx transaccion = this.GenerarTransaccion<ParametroTrx>();
            transaccion.CodigoObtener = codigo;

            EstructuraBase<ObtenerParametrizacionResponse> respuesta = this.ObtenerTodos<ParametroTrx, ObtenerParametrizacionResponse, ObtenerParametrizacionIN>(
                new ObtenerParametrizacionIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("ActualizarParametrizacion")]
        [Produces(typeof(EstructuraBase<ParametrizacionResponse>))]
        public IActionResult ActualizarParametrizacion(string codigo, string valor)
        {
            ParametroTrx transaccion = this.GenerarTransaccion<ParametroTrx>();
            transaccion.CodigoActualizar = codigo;
            transaccion.ValorActualizar = valor;

            EstructuraBase<ParametrizacionResponse> respuesta = this.Actualizar<ParametroTrx, ParametrizacionResponse, ActualizarParametrizacionIN>(
                new ActualizarParametrizacionIN(),
                transaccion);

            return Ok(respuesta);
        }       
    }
}
