using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Creditos.Model.Entidad.EstadoCredito;
using Core.Creditos.Model.Transaccion.Response.EstadosCreditos;
using Core.Creditos.Model.Transaccion.Response.Usuarios;
using Core.Creditos.Model.Transaccion.Transaccional.EstadosCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.Usuarios;
using Core.CreditosBusinessLogic.Interna.EstadosSolicitudCredito;
using Core.CreditosBusinessLogic.Interna.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Core.Creditos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        [HttpGet]
        [Route("ObtenerUsuariosActivos")]
        [Produces(typeof(EstructuraBase<ObtenerUsuariosActivosResponse>))]
        public IActionResult ObtenerUsuariosActivos()
        {
            UsuarioTrx transaccion = this.GenerarTransaccion<UsuarioTrx>();
            
            EstructuraBase<ObtenerUsuariosActivosResponse> respuesta = this.ObtenerTodos<UsuarioTrx, ObtenerUsuariosActivosResponse, ObtenerUsuariosActivosIN>(
                new ObtenerUsuariosActivosIN(),
                transaccion);

            return Ok(respuesta);
        }
    }
}
