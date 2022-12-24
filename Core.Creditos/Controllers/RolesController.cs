using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Creditos.Model.Transaccion.Response.Roles;
using Core.Creditos.Model.Transaccion.Transaccional.Roles;
using Core.CreditosBusinessLogic.Interna.Roles;
using Microsoft.AspNetCore.Mvc;

namespace Core.Creditos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        [HttpGet]
        [Route("ObtenerRoles")]
        [Produces(typeof(EstructuraBase<ObtenerRolesResponse>))]
        public IActionResult ObtenerRoles()
        {
            RolTrx transaccion = this.GenerarTransaccion<RolTrx>();
            

            EstructuraBase<ObtenerRolesResponse> respuesta = this.ObtenerTodos<RolTrx, ObtenerRolesResponse, ObtenerRolesIN>(
                new ObtenerRolesIN(),
                transaccion);

            return Ok(respuesta);
        }
    }
}
