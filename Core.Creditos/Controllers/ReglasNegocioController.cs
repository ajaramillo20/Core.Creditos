using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Creditos.Model.Entidad.ReglasNegocio;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Response.ReglasNegocio;
using Core.Creditos.Model.Transaccion.Response.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.ReglasNegocio;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Interna.ReglasNegocio;
using Core.CreditosBusinessLogic.Interna.SolicitudCreditos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Creditos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReglasNegocioController : Controller
    {

        [HttpGet]        
        [Route("ObtenerParametrosEvaluacion")]
        [Produces(typeof(EstructuraBase<ReglaNegocioResponse>))]
        public IActionResult ObtenerParametrosEvaluacion()
        {
            ReglaNegocioTrx transaccion = this.GenerarTransaccion<ReglaNegocioTrx>();
            
            EstructuraBase<ReglaNegocioResponse> respuesta = this.ObtenerTodos<ReglaNegocioTrx, ReglaNegocioResponse, ObtenerParametrosEvaluacionIN>(
                new ObtenerParametrosEvaluacionIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ObtenerCriteriosEvaluacion")]
        [Produces(typeof(EstructuraBase<ReglaNegocioResponse>))]
        public IActionResult ObtenerCriteriosEvaluacion()
        {
            ReglaNegocioTrx transaccion = this.GenerarTransaccion<ReglaNegocioTrx>();

            EstructuraBase<ReglaNegocioResponse> respuesta = this.ObtenerTodos<ReglaNegocioTrx, ReglaNegocioResponse, ObtenerCriteriosEvaluacionIN>(
                new ObtenerCriteriosEvaluacionIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpPost]
        [Route("AgregarParametroEvaluacion")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult AgregarParametroEvaluacion([FromBody] ParametroEvaluacion parametro)
        {
            ReglaNegocioTrx transaccion = this.GenerarTransaccion<ReglaNegocioTrx>();
            transaccion.ParametroInsertar = parametro;

            EstructuraBase<ReglaNegocioResponse> respuesta = this.Insertar<ReglaNegocioTrx, ReglaNegocioResponse, AgregarParametroEvaluacionIN>(
                new AgregarParametroEvaluacionIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpPost]
        [Route("AgregarCriterioEvaluacion")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult AgregarCriterioEvaluacion([FromBody] CriterioEvaluacion criterio)
        {
            ReglaNegocioTrx transaccion = this.GenerarTransaccion<ReglaNegocioTrx>();
            transaccion.CriterioInsertar = criterio;

            EstructuraBase<ReglaNegocioResponse> respuesta = this.Insertar<ReglaNegocioTrx, ReglaNegocioResponse, AgregarCriterioEvaluacionIN>(
                new AgregarCriterioEvaluacionIN(),
                transaccion);

            return Ok(respuesta);
        }


        [HttpPut]
        [Route("ActualizarParametroEvaluacion")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult ActualizarParametroEvaluacion([FromBody] ParametroEvaluacion parametro)
        {
            ReglaNegocioTrx transaccion = this.GenerarTransaccion<ReglaNegocioTrx>();
            transaccion.ParametroInsertar = parametro;

            EstructuraBase<ReglaNegocioResponse> respuesta = this.Actualizar<ReglaNegocioTrx, ReglaNegocioResponse, ActualizarParametroEvaluacionIN>(
                new ActualizarParametroEvaluacionIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("ActualizarCriterioEvaluacion")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult ActualizarCriterioEvaluacion([FromBody] CriterioEvaluacion criterio)
        {
            ReglaNegocioTrx transaccion = this.GenerarTransaccion<ReglaNegocioTrx>();
            transaccion.CriterioInsertar = criterio;

            EstructuraBase<ReglaNegocioResponse> respuesta = this.Actualizar<ReglaNegocioTrx, ReglaNegocioResponse, ActualizarCriterioEvaluacionIN>(
                new ActualizarCriterioEvaluacionIN(),
                transaccion);

            return Ok(respuesta);
        }


        [HttpPut]
        [Route("EliminarParametroEvaluacion")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult EliminarParametroEvaluacion(string codigo)
        {
            ReglaNegocioTrx transaccion = this.GenerarTransaccion<ReglaNegocioTrx>();
            transaccion.CodigoParametroEliminar = codigo;

            EstructuraBase<ReglaNegocioResponse> respuesta = this.Eliminar<ReglaNegocioTrx, ReglaNegocioResponse, EliminarParametroEvaluacionIN>(
                new EliminarParametroEvaluacionIN(),
                transaccion);

            return Ok(respuesta);
        }


        [HttpPut]
        [Route("EliminarCriterioEvaluacion")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult EliminarCriterioEvaluacion(int id)
        {
            ReglaNegocioTrx transaccion = this.GenerarTransaccion<ReglaNegocioTrx>();
            transaccion.IdCriterioEliminar = id;

            EstructuraBase<ReglaNegocioResponse> respuesta = this.Eliminar<ReglaNegocioTrx, ReglaNegocioResponse, EliminarCriterioEvaluacionIN>(
                new EliminarCriterioEvaluacionIN(),
                transaccion);

            return Ok(respuesta);
        }
    }
}
