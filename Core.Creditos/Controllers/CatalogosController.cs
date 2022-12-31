using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Request.Catalogos;
using Core.Creditos.Model.Transaccion.Request.SolicitudCredito;
using Core.Creditos.Model.Transaccion.Response.Catalogos;
using Core.Creditos.Model.Transaccion.Response.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.Catalogos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Interna.Catalogos;
using Core.CreditosBusinessLogic.Interna.SolicitudCreditos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Core.Creditos.Controllers
{
    /// <summary>
    /// CONTROLADOR CATALOGOS
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : Controller
    {        
        /// <summary>
        /// Obtiene indices o cabeceras
        /// </summary>
        /// <param name="codigoTabla">Codigo Indice - Cabecera</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerIndices")]
        [Produces(typeof(EstructuraBase<ObtenerIndicesResponse>))]
        public IActionResult ObtenerIndices(string? codigoTabla = "")
        {
            CatalogoTrx transaccion = this.GenerarTransaccion<CatalogoTrx>();
            transaccion.CodigoTabla = codigoTabla ?? string.Empty;

            EstructuraBase<ObtenerIndicesResponse> respuesta = this.ObtenerTodos<CatalogoTrx, ObtenerIndicesResponse, ObtenerIndicesIN>(
                new ObtenerIndicesIN(),
                transaccion);

            return Ok(respuesta);
        }

        /// <summary>
        /// Obtiene listado de todos los catálogos
        /// </summary>
        /// <param name="codigoTabla">Codigo indice o cabecera</param>
        /// <param name="codigoCatalogo">código catálogo</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerCatalogos")]
        [Produces(typeof(EstructuraBase<ObtenerCatalogosResponse>))]
        public IActionResult ObtenerCatalogos(string? codigoTabla = "", string? codigoCatalogo = "")
        {
            CatalogoTrx transaccion = this.GenerarTransaccion<CatalogoTrx>();
            transaccion.CodigoTabla = codigoTabla;
            transaccion.CodigoCatalogo = codigoCatalogo;

            EstructuraBase<ObtenerCatalogosResponse> respuesta = this.ObtenerTodos<CatalogoTrx, ObtenerCatalogosResponse, ObtenerCatalogosIN>(
                new ObtenerCatalogosIN(),
                transaccion);

            return Ok(respuesta);
        }

        /// <summary>
        /// Obtiene Catálogo externo
        /// </summary>
        /// <param name="codigoTabla"></param>
        /// <param name="codigoCredencial"></param>
        /// <param name="codigoCatalogo"></param>
        /// <param name="nombreCatalogo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerCatalogosExternos")]
        [Produces(typeof(EstructuraBase<ObtenerCatalogosResponse>))]
        public IActionResult ObtenerCatalogosExternos(string? codigoTabla = "", string? codigoCredencial = "", string? codigoCatalogo = "", string? nombreCatalogo = "")
        {
            CatalogoTrx transaccion = this.GenerarTransaccion<CatalogoTrx>();
            transaccion.CodigoTabla = codigoTabla ?? string.Empty;
            transaccion.CodigoCatalogo = codigoCatalogo ?? string.Empty;
            transaccion.CodigoCredencial = codigoCredencial ?? string.Empty;
            transaccion.NombreCatalogo = nombreCatalogo ?? string.Empty;

            EstructuraBase<ObtenerCatalogosResponse> respuesta = this.ObtenerTodos<CatalogoTrx, ObtenerCatalogosResponse, ObtenerCatalogosExternosIN>(
                new ObtenerCatalogosExternosIN(),
                transaccion);

            return Ok(respuesta);
        }

        /// <summary>
        /// Agrega catalogo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AgregarCatalogo")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult AgregarCatalogo([FromBody] AgregarCatalogoRequest request)
        {
            CatalogoTrx transaccion = this.GenerarTransaccion<CatalogoTrx>();
            transaccion.CatalogoInsertar.CodigoCatalogo = request.Codigo;
            transaccion.CatalogoInsertar.NombreCatalogo = request.Nombre;
            transaccion.CatalogoInsertar.ValorCatalogo = request.Valor;
            transaccion.CatalogoInsertar.CodigoTabla = request.TablaCodigo;
            transaccion.CatalogoInsertar.DescripcionCatalogo = request.Descripcion;

            EstructuraBase<AgregarCatalogoResponse> respuesta = this.Insertar<CatalogoTrx, AgregarCatalogoResponse, AgregarCatalogosIN>(
                new AgregarCatalogosIN(),
                transaccion);

            return Ok(respuesta);
        }

        /// <summary>
        /// Agrega catálogo para homologación
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AgregarCatalogoExterno")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult AgregarCatalogoExterno([FromBody] AgregarCatalogoExternoRequest request)
        {
            CatalogoTrx transaccion = this.GenerarTransaccion<CatalogoTrx>();
            transaccion.CatalogoExternoInsertar.CodigoExterno = request.CodigoExterno;
            transaccion.CatalogoExternoInsertar.CodigoCatalogo = request.CodigoCatalogo;
            transaccion.CatalogoExternoInsertar.CodigoTabla = request.CodigoTabla;
            transaccion.CatalogoExternoInsertar.CodigoCredencial = request.CodigoCredencial;

            EstructuraBase<AgregarCatalogoResponse> respuesta = this.Insertar<CatalogoTrx, AgregarCatalogoResponse, AgregarCatalogosExternoIN>(
                new AgregarCatalogosExternoIN(),
                transaccion);

            return Ok(respuesta);
        }

        /// <summary>
        /// Actualiza catálogo interno
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="valor"></param>
        /// <param name="tabla"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ActualizarCatalogo")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult ActualizarCatalogo(string codigo, string nombre, string valor, string tabla, string descripcion)
        {
            CatalogoTrx transaccion = this.GenerarTransaccion<CatalogoTrx>();
            transaccion.CatalogoInsertar.CodigoCatalogo = codigo;
            transaccion.CatalogoInsertar.NombreCatalogo = nombre;
            transaccion.CatalogoInsertar.ValorCatalogo = valor;
            transaccion.CatalogoInsertar.CodigoTabla = tabla;
            transaccion.CatalogoInsertar.DescripcionCatalogo = descripcion;

            EstructuraBase<ActualizarCatalogoResponse> respuesta = this.Actualizar<CatalogoTrx, ActualizarCatalogoResponse, ActualizarCatalogosIN>(
                new ActualizarCatalogosIN(),
                transaccion);

            return Ok(respuesta);
        }

        /// <summary>
        /// Actualiza catálogo externo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigoExterno"></param>
        /// <param name="codigoCatalogo"></param>
        /// <param name="codigoTabla"></param>
        /// <param name="codigoCredencial"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ActualizarCatalogoExterno")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult ActualizarCatalogoExterno(int id, string codigoExterno, string codigoCatalogo, string codigoTabla, string codigoCredencial)
        {
            CatalogoTrx transaccion = this.GenerarTransaccion<CatalogoTrx>();
            transaccion.CatalogoExternoInsertar.Id = id;
            transaccion.CatalogoExternoInsertar.CodigoExterno = codigoExterno;
            transaccion.CatalogoExternoInsertar.CodigoCatalogo = codigoCatalogo;
            transaccion.CatalogoExternoInsertar.CodigoTabla = codigoTabla;
            transaccion.CatalogoExternoInsertar.CodigoCredencial = codigoCredencial;

            EstructuraBase<ActualizarCatalogoResponse> respuesta = this.Actualizar<CatalogoTrx, ActualizarCatalogoResponse, ActualizarCatalogosExternosIN>(
                new ActualizarCatalogosExternosIN(),
                transaccion);

            return Ok(respuesta);
        }

        /// <summary>
        /// Elimina catálogo
        /// </summary>
        /// <param name="codigoCatalogo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EliminarCatalogo/{codigoCatalogo}")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult EliminarCatalogo(string codigoCatalogo)
        {
            CatalogoTrx transaccion = this.GenerarTransaccion<CatalogoTrx>();
            transaccion.CodigoCatalogo = codigoCatalogo;

            EstructuraBase<EliminarCatalogoResponse> respuesta = this.Eliminar<CatalogoTrx, EliminarCatalogoResponse, EliminarCatalogosIN>(
                new EliminarCatalogosIN(),
                transaccion);

            return Ok(respuesta);
        }

        /// <summary>
        /// Elimina código de homologación externa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EliminarCatalogoExterno/{id}")]
        [Produces(typeof(EstructuraBase<>))]
        public IActionResult EliminarCatalogoExterno(int id)
        {
            CatalogoTrx transaccion = this.GenerarTransaccion<CatalogoTrx>();
            transaccion.IdCodigoHomologacion = id;

            EstructuraBase<EliminarCatalogoResponse> respuesta = this.Eliminar<CatalogoTrx, EliminarCatalogoResponse, EliminarCatalogosExternosIN>(
                new EliminarCatalogosExternosIN(),
                transaccion);

            return Ok(respuesta);
        }       
    }
}
