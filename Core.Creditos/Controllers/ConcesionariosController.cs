using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Creditos.Model.Transaccion.Concesionarios;
using Core.Creditos.Model.Transaccion.Response.Catalogos;
using Core.Creditos.Model.Transaccion.Response.Concesionarios;
using Core.Creditos.Model.Transaccion.Transaccional.Catalogos;
using Core.CreditosBusinessLogic.Interna.Catalogos;
using Core.CreditosBusinessLogic.Interna.Concesionarios;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Core.Creditos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcesionariosController : Controller
    {
        [HttpGet]
        [Route("ObtenerConcesionarios")]
        [Produces(typeof(EstructuraBase<ObtenerConcesionariosResponse>))]
        public IActionResult ObtenerConcesionarios(string? nombre = "", string? ruc = "", string? codigoCredencial = "")
        {
            ConcesionarioTrx transaccion = this.GenerarTransaccion<ConcesionarioTrx>();
            transaccion.Nombre = nombre ?? string.Empty;
            transaccion.Ruc = ruc ?? string.Empty;
            transaccion.CodigoCredencial = codigoCredencial ?? string.Empty;

            EstructuraBase<ObtenerConcesionariosResponse> respuesta = this.ObtenerTodos<ConcesionarioTrx, ObtenerConcesionariosResponse, ObtenerConcesionariosIN>(
                new ObtenerConcesionariosIN(),
                transaccion);

            return Ok(respuesta);
        }
    }
}
