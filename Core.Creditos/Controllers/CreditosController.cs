using Core.Common.Model.Transaccion.Respuesta;
using Core.Common.ProcessTemplate.Helper;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Request.SolicitudCredito;
using Core.Creditos.Model.Transaccion.Response.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Core.CreditosBusinessLogic.Interna.SolicitudCreditos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Creditos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditosController : ControllerBase
    {
        [HttpPost]
        [Route("SolicitudCredito")]
        [Produces(typeof(EstructuraBase<SolicitudCreditoResponse>))]
        public IActionResult SolicitudCredito([FromBody] SolicitudCreditoRequest request)
        {
            SolicitudCreditoTrx transaccion = this.GenerarTransaccion<SolicitudCreditoTrx>();
            transaccion.SolicitudCredito = new SolicitudCredito();
            transaccion.SolicitudCredito.Solicitud.CedulaVendedor = request.Solicitud.CedulaVendedor;
            transaccion.SolicitudCredito.Solicitud.CodigoProducto = request.Solicitud.CodigoProducto;
            transaccion.SolicitudCredito.Solicitud.CedulaVendedor = request.Solicitud.CedulaVendedor;
            transaccion.SolicitudCredito.Solicitud.FechaNegociacion = DateTime.Now.ToShortDateString();
            transaccion.SolicitudCredito.Solicitud.CedulaVendedor = request.Solicitud.CedulaVendedor;
            transaccion.SolicitudCredito.Solicitud.CodigoConcesionario = request.Solicitud.CodigoConcesionario;

            transaccion.SolicitudCredito.Solicitud.Vehiculo.CodigoTipoUso = request.Solicitud.Vehiculo.CodigoTipoUso;
            transaccion.SolicitudCredito.Solicitud.Vehiculo.CodigoModelo = request.Solicitud.Vehiculo.CodigoModelo;
            transaccion.SolicitudCredito.Solicitud.Vehiculo.CodigoMarca = request.Solicitud.Vehiculo.CodigoMarca;
            transaccion.SolicitudCredito.Solicitud.Vehiculo.PrecioConIva = request.Solicitud.Vehiculo.PrecioConIva;
            transaccion.SolicitudCredito.Solicitud.Vehiculo.DispositivoRastreo.CodigoDispositivoRastreo = request.Solicitud.Vehiculo.DispositivoRastreo.CodigoDispositivoRastreo;
            transaccion.SolicitudCredito.Solicitud.Vehiculo.DispositivoRastreo.Precio = request.Solicitud.Vehiculo.DispositivoRastreo.Precio;

            transaccion.SolicitudCredito.Solicitud.Aseguradora.CodigoAseguradora = request.Solicitud.Aseguradora.CodigoAseguradora;

            transaccion.SolicitudCredito.Solicitud.Cliente.CodigoTipoVivienda = request.Solicitud.Cliente.CodigoTipoVivienda;
            transaccion.SolicitudCredito.Solicitud.Cliente.CodigoCiudad = request.Solicitud.Cliente.CodigoCiudad;
            transaccion.SolicitudCredito.Solicitud.Cliente.AntiguedadEconomica = request.Solicitud.Cliente.AntiguedadEconomica;
            transaccion.SolicitudCredito.Solicitud.Cliente.CodigoCiudad = request.Solicitud.Cliente.CodigoCiudad;
            transaccion.SolicitudCredito.Solicitud.Cliente.Nacionalidad = request.Solicitud.Cliente.Nacionalidad;
            transaccion.SolicitudCredito.Solicitud.Cliente.TipoIdentificacion = request.Solicitud.Cliente.TipoIdentificacion;
            transaccion.SolicitudCredito.Solicitud.Cliente.CodigoClasificacionCargo = request.Solicitud.Cliente.CodigoClasificacionCargo;
            transaccion.SolicitudCredito.Solicitud.Cliente.CodigoEstadoCivil = request.Solicitud.Cliente.CodigoEstadoCivil;
            transaccion.SolicitudCredito.Solicitud.Cliente.CodigoNivelEducacion = request.Solicitud.Cliente.CodigoNivelEducacion;
            transaccion.SolicitudCredito.Solicitud.Cliente.CodigoOcupacion = request.Solicitud.Cliente.CodigoOcupacion;
            transaccion.SolicitudCredito.Solicitud.Cliente.CodigoProvincia = request.Solicitud.Cliente.CodigoProvincia;
            transaccion.SolicitudCredito.Solicitud.Cliente.PrimerNombre = request.Solicitud.Cliente.PrimerNombre;
            transaccion.SolicitudCredito.Solicitud.Cliente.SegundoNombre = request.Solicitud.Cliente.SegundoNombre;
            transaccion.SolicitudCredito.Solicitud.Cliente.ApellidoPaterno = request.Solicitud.Cliente.ApellidoPaterno;
            transaccion.SolicitudCredito.Solicitud.Cliente.ApellidoMaterno = request.Solicitud.Cliente.ApellidoMaterno;
            transaccion.SolicitudCredito.Solicitud.Cliente.Celular = request.Solicitud.Cliente.Celular;
            transaccion.SolicitudCredito.Solicitud.Cliente.Direccion = request.Solicitud.Cliente.Direccion;
            transaccion.SolicitudCredito.Solicitud.Cliente.DireccionTrabajo = request.Solicitud.Cliente.DireccionTrabajo;
            transaccion.SolicitudCredito.Solicitud.Cliente.Email = request.Solicitud.Cliente.Email;
            transaccion.SolicitudCredito.Solicitud.Cliente.FechaNacimiento = request.Solicitud.Cliente.FechaNacimiento;
            transaccion.SolicitudCredito.Solicitud.Cliente.Identificacion = request.Solicitud.Cliente.Identificacion;
            transaccion.SolicitudCredito.Solicitud.Cliente.InstitucionFinanciera = request.Solicitud.Cliente.InstitucionFinanciera;
            transaccion.SolicitudCredito.Solicitud.Cliente.LugarTrabajo = request.Solicitud.Cliente.LugarTrabajo;
            transaccion.SolicitudCredito.Solicitud.Cliente.NombreReferenciaFamiliar = request.Solicitud.Cliente.NombreReferenciaFamiliar;
            transaccion.SolicitudCredito.Solicitud.Cliente.NumeroCargas = request.Solicitud.Cliente.NumeroCargas;
            transaccion.SolicitudCredito.Solicitud.Cliente.Patrimonio = request.Solicitud.Cliente.Patrimonio;
            transaccion.SolicitudCredito.Solicitud.Cliente.Sexo = request.Solicitud.Cliente.Sexo;
            transaccion.SolicitudCredito.Solicitud.Cliente.TelefonoDomicilio = request.Solicitud.Cliente.TelefonoDomicilio;
            transaccion.SolicitudCredito.Solicitud.Cliente.TelefonoEmpresa = request.Solicitud.Cliente.TelefonoEmpresa;
            transaccion.SolicitudCredito.Solicitud.Cliente.TelefonoReferenciaFamiliar = request.Solicitud.Cliente.TelefonoReferenciaFamiliar;
            transaccion.SolicitudCredito.Solicitud.Cliente.TipoPersona = request.Solicitud.Cliente.TipoPersona;
            transaccion.SolicitudCredito.Solicitud.Cliente.TrabajaSector = request.Solicitud.Cliente.TrabajaSector;

            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.AntiguedadEconomica = request.Solicitud.Cliente.Conyuge.AntiguedadEconomica;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.ApellidoMaterno = request.Solicitud.Cliente.Conyuge.ApellidoMaterno;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.ApellidoPaterno = request.Solicitud.Cliente.Conyuge.ApellidoPaterno;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.Cargo = request.Solicitud.Cliente.Conyuge.Cargo;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.ConyugeTelefono = request.Solicitud.Cliente.Conyuge.ConyugeTelefono;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.Email=request.Solicitud.Cliente.Conyuge.Email;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.FechaNacimiento = request.Solicitud.Cliente.Conyuge.FechaNacimiento;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.Identificacion = request.Solicitud.Cliente.Conyuge.Identificacion;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.Nacionalidad = request.Solicitud.Cliente.Conyuge.Nacionalidad;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.PrimerNombre=request.Solicitud.Cliente.Conyuge.PrimerNombre;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.Profesion=request.Solicitud.Cliente.Conyuge.Profesion;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.SegundoNombre= request.Solicitud.Cliente.Conyuge.SegundoNombre;
            transaccion.SolicitudCredito.Solicitud.Cliente.Conyuge.Sexo=request.Solicitud.Cliente.Conyuge.Sexo;            

            transaccion.SolicitudCredito.Solicitud.InformacionCredito.ConsumoTarjeta = request.Solicitud.InformacionCredito.ConsumoTarjeta;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.DiaPago = request.Solicitud.InformacionCredito.DiaPago;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.EgresosConyuge = request.Solicitud.InformacionCredito.EgresosConyuge;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.EgresosDeudor = request.Solicitud.InformacionCredito.EgresosDeudor;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.FuenteIngresos = request.Solicitud.InformacionCredito.FuenteIngresos;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.GaranteIdentificacion = request.Solicitud.InformacionCredito.GaranteIdentificacion;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.IngresosConyuge = request.Solicitud.InformacionCredito.IngresosConyuge;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.IngresosDeudor = request.Solicitud.InformacionCredito.IngresosDeudor;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.MontoCredito = request.Solicitud.InformacionCredito.MontoCredito;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.OtrosEgresosConyuge = request.Solicitud.InformacionCredito.OtrosEgresosConyuge;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.OtrosEgresosDeudor = request.Solicitud.InformacionCredito.OtrosEgresosDeudor;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.OtrosIngresosConyuge = request.Solicitud.InformacionCredito.OtrosIngresosConyuge;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.OtrosIngresosDeudor = request.Solicitud.InformacionCredito.OtrosIngresosDeudor;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.PlazoMeses = request.Solicitud.InformacionCredito.PlazoMeses;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.SaldoPromedioCuentas = request.Solicitud.InformacionCredito.SaldoPromedioCuentas;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.Tasa = request.Solicitud.InformacionCredito.Tasa;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.TieneGarante = request.Solicitud.InformacionCredito.TieneGarante;
            transaccion.SolicitudCredito.Solicitud.InformacionCredito.ValorEntrada = request.Solicitud.InformacionCredito.ValorEntrada;


            EstructuraBase<SolicitudCreditoResponse> respuesta = this.Insertar<SolicitudCreditoTrx, SolicitudCreditoResponse, SolicitudCreditoIN>(
                new SolicitudCreditoIN(),
                transaccion);

            return Ok(respuesta);
        }
    }
}
