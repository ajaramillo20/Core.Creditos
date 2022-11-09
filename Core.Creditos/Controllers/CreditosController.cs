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
        [Route("CambiarEstadoSolicitudCredito")]
        [Produces(typeof(EstructuraBase<CambiarEstadoSolicitudCreditoResponse>))]
        public IActionResult CambiarEstadoSolicitudCredito(string numeroSolicitud, int estadoSolicitudCreditoId, string? usuarioRed, string? comentario="")
        {
            CambiarEstadoSolicitudCreditoTrx transaccion = this.GenerarTransaccion<CambiarEstadoSolicitudCreditoTrx>();
            
            transaccion.NumeroSolicitudCredito = numeroSolicitud;
            transaccion.IdEstadoSolicitudCreditoDestino = estadoSolicitudCreditoId;
            transaccion.ComentarioCambioEstado = comentario;
            transaccion.UsuarioRed = usuarioRed;
           
            EstructuraBase<CambiarEstadoSolicitudCreditoResponse> respuesta = this.Actualizar<CambiarEstadoSolicitudCreditoTrx, CambiarEstadoSolicitudCreditoResponse, CambiarEstadoSolicitudCreditoIN>(
                new CambiarEstadoSolicitudCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpGet]        
        [Route("ObtenerListaCreditos")]
        [Produces(typeof(EstructuraBase<ObtenerListaCreditosResponse>))]
        public IActionResult ObtenerListaCreditos()
        {
            SolicitudCreditoTrx transaccion = this.GenerarTransaccion<SolicitudCreditoTrx>();   
            
            EstructuraBase<ObtenerListaCreditosResponse> respuesta = this.ObtenerTodos<SolicitudCreditoTrx, ObtenerListaCreditosResponse, ObtenerListaCreditosIN>(
                new ObtenerListaCreditosIN(),
                transaccion);

            return Ok(respuesta);
        }


        [HttpGet]        
        [Route("ObtenerInformacionCredito")]
        [Produces(typeof(EstructuraBase<ObtenerInformacionCreditoResponse>))]
        public IActionResult ObtenerInformacionCredito(int numeroSolicitud)
        {
            SolicitudCreditoTrx transaccion = this.GenerarTransaccion<SolicitudCreditoTrx>();
            transaccion.NumeroSolicitudCredito = numeroSolicitud;

            EstructuraBase<ObtenerInformacionCreditoResponse> respuesta = this.Obtener<SolicitudCreditoTrx, ObtenerInformacionCreditoResponse, ObtenerInformacionCreditoIN>(
                new ObtenerInformacionCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }


        [HttpPut]
        [Route("ReasignarSolicitudCredito/{numeroSolicitud}/{nombreRedReasignado}/{usuarioAplicacion}")]
        [Produces(typeof(EstructuraBase<ReasignarSolicitudCreditoResponse>))]
        public IActionResult ReasignarSolicitudCredito(int numeroSolicitud, string nombreRedReasignado,string usuarioAplicacion)
        {
            SolicitudCreditoTrx transaccion = this.GenerarTransaccion<SolicitudCreditoTrx>();
            transaccion.NumeroSolicitudCredito = numeroSolicitud;
            transaccion.Responsable = nombreRedReasignado;
            transaccion.UsuarioAplicacion = usuarioAplicacion;            

            EstructuraBase<ReasignarSolicitudCreditoResponse> respuesta = this.Actualizar<SolicitudCreditoTrx, ReasignarSolicitudCreditoResponse, ReasignarSolicitudCreditoIN>(
                new ReasignarSolicitudCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }        
    }
}
