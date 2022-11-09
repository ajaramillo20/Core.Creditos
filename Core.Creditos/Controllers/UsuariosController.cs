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
        [Route("ObtenerUsuarios")]
        [Produces(typeof(EstructuraBase<ObtenerUsuariosResponse>))]
        public IActionResult ObtenerUsuariosActivos()
        {
            UsuarioTrx transaccion = this.GenerarTransaccion<UsuarioTrx>();

            EstructuraBase<ObtenerUsuariosResponse> respuesta = this.ObtenerTodos<UsuarioTrx, ObtenerUsuariosResponse, ObtenerUsuariosIN>(
                new ObtenerUsuariosIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ObtenerInformacionUsuario")]
        [Produces(typeof(EstructuraBase<ObtenerInformacionUsuarioResponse>))]
        public IActionResult ObtenerInformacionUsuario(string usuarioRed)
        {
            UsuarioTrx transaccion = this.GenerarTransaccion<UsuarioTrx>();
            transaccion.InformacionUsuario.UsuarioNombreRed = usuarioRed;

            EstructuraBase<ObtenerInformacionUsuarioResponse> respuesta = this.Obtener<UsuarioTrx, ObtenerInformacionUsuarioResponse, ObtenerInformacionUsuarioIN>(
                new ObtenerInformacionUsuarioIN(),
                transaccion);

            return Ok(respuesta);
        }

        [HttpPut]
        [Route("CambiarEstadoUsuario")]
        [Produces(typeof(EstructuraBase<CambiarEstadoUsuarioResponse>))]
        public IActionResult CambiarEstadoUsuario(string usuarioId, bool activar)
        {
            UsuarioTrx transaccion = this.GenerarTransaccion<UsuarioTrx>();
            transaccion.InformacionUsuario.UsuarioBPMId = Convert.ToInt32(usuarioId);
            transaccion.InformacionUsuario.UsuarioActivo = activar;

            EstructuraBase<CambiarEstadoUsuarioResponse> respuesta = this.Actualizar<UsuarioTrx, CambiarEstadoUsuarioResponse, CambiarEstadoUsuarioResponseIN>(
                new CambiarEstadoUsuarioResponseIN(),
                transaccion);

            return Ok(respuesta);
        }
    }
}
