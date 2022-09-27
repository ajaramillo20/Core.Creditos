using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.SolicitudCreditos
{
    public class SolicitudCredito
    {
        [JsonPropertyName("solicitud")]
        public Solicitud Solicitud { get; set; } = new Solicitud();
    }
    public class Solicitud
    {
        [JsonPropertyName("fechaNegociacion")]
        public DateTime? FechaNegociacion { get; set; }

        [JsonPropertyName("codigoConcesionario")]
        public string? CodigoConcesionario { get; set; }

        [JsonPropertyName("cedulaVendedor")]
        public string? CedulaVendedor { get; set; }

        [JsonPropertyName("codigoProducto")]
        public string? CodigoProducto { get; set; } = "";

        [JsonPropertyName("vehiculo")]
        public Vehiculo? Vehiculo { get; set; }

        [JsonPropertyName("cliente")]
        public Cliente? Cliente { get; set; }

        [JsonPropertyName("informacionCredito")]
        public InformacionCredito? InformacionCredito { get; set; }

        [JsonPropertyName("aseguradora")]
        public Aseguradora? Aseguradora { get; set; }
    }

    public class Vehiculo
    {
        [JsonPropertyName("codigoMarca")]
        public string? CodigoMarca { get; set; }

        [JsonPropertyName("codigoModelo")]
        public string? CodigoModelo { get; set; }

        [JsonPropertyName("codigoTipoUso")]
        public string? CodigoTipoUso { get; set; }

        [JsonPropertyName("precioConIva")]
        public decimal? PrecioConIva { get; set; }

        [JsonPropertyName("dispositivoRastreo")]
        public DispositivoRastreo? DispositivoRastreo { get; set; }
    }

    public class InformacionCredito
    {
        [JsonPropertyName("tasa")]
        public decimal? Tasa { get; set; }

        [JsonPropertyName("plazoMeses")]
        public int? PlazoMeses { get; set; }

        [JsonPropertyName("montoCredito")]
        public decimal? MontoCredito { get; set; } = 0;

        [JsonPropertyName("valorEntrada")]
        public decimal? ValorEntrada { get; set; } = 0;

        [JsonPropertyName("diaPago")]
        public int? DiaPago { get; set; }

        [JsonPropertyName("tieneGarante")]
        public bool? TieneGarante { get; set; } = false;

        [JsonPropertyName("garanteIdentificacion")]
        public string? GaranteIdentificacion { get; set; }

        [JsonPropertyName("consumoTarjeta")]
        public decimal? ConsumoTarjeta { get; set; }

        [JsonPropertyName("saldoPromedioCuentas")]
        public decimal? SaldoPromedioCuentas { get; set; }

        [JsonPropertyName("ingresosDeudor")]
        public decimal? IngresosDeudor { get; set; }

        [JsonPropertyName("ingresosConyuge")]
        public decimal? IngresosConyuge { get; set; }

        [JsonPropertyName("otrosIngresosDeudor")]
        public decimal? OtrosIngresosDeudor { get; set; }

        [JsonPropertyName("otrosIngresosConyuge")]
        public decimal? OtrosIngresosConyuge { get; set; }

        [JsonPropertyName("egresosDeudor")]
        public decimal? EgresosDeudor { get; set; }

        [JsonPropertyName("egresosConyuge")]
        public decimal? EgresosConyuge { get; set; }

        [JsonPropertyName("otrosEgresosDeudor")]
        public decimal? OtrosEgresosDeudor { get; set; }

        [JsonPropertyName("otrosEgresosConyuge")]
        public decimal? OtrosEgresosConyuge { get; set; }

        [JsonPropertyName("fuenteIngresos")]
        public string? FuenteIngresos { get; set; }
    }

    public class DispositivoRastreo
    {
        [JsonPropertyName("codigoDispositivoRastreo")]       
        public string? CodigoDispositivoRastreo { get; set; }

        [JsonPropertyName("precio")]
        public decimal? Precio { get; set; }
    }

    public class Conyuge
    {
        [JsonPropertyName("identificacion")]
        public string? Identificacion { get; set; }

        [JsonPropertyName("primerNombre")]
        public string? PrimerNombre { get; set; }

        [JsonPropertyName("segundoNombre")]
        public string? SegundoNombre { get; set; }

        [JsonPropertyName("apellidoPaterno")]
        public string? ApellidoPaterno { get; set; }

        [JsonPropertyName("apellidoMaterno")]
        public string? ApellidoMaterno { get; set; }

        [JsonPropertyName("nacionalidad")]
        public string? Nacionalidad { get; set; }

        [JsonPropertyName("sexo")]
        public string? Sexo { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("fechaNacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [JsonPropertyName("profesion")]
        public string? Profesion { get; set; }

        [JsonPropertyName("AntiguedadEconomica")]
        public string? AntiguedadEconomica { get; set; }

        [JsonPropertyName("Cargo")]
        public string? Cargo { get; set; }

        [JsonPropertyName("ConyugeTelefono")]
        public string? ConyugeTelefono { get; set; }
    }

    public class Cliente
    {
        [JsonPropertyName("tipoIdentificacion")]
        public string? TipoIdentificacion { get; set; }

        [JsonPropertyName("identificacion")]
        public string? Identificacion { get; set; }

        [JsonPropertyName("institucionFinanciera")]
        public string? InstitucionFinanciera { get; set; }

        [JsonPropertyName("primerNombre")]
        public string? PrimerNombre { get; set; }

        [JsonPropertyName("segundoNombre")]
        public string? SegundoNombre { get; set; }

        [JsonPropertyName("apellidoPaterno")]
        public string? ApellidoPaterno { get; set; }

        [JsonPropertyName("apellidoMaterno")]
        public string? ApellidoMaterno { get; set; }

        [JsonPropertyName("nacionalidad")]
        public string? Nacionalidad { get; set; }

        [JsonPropertyName("codigoTipoVivienda")]
        public string? CodigoTipoVivienda { get; set; }

        [JsonPropertyName("codigoEstadoCivil")]
        public string? CodigoEstadoCivil { get; set; }

        [JsonPropertyName("codigoNivelEducacion")]
        public string? CodigoNivelEducacion { get; set; }

        [JsonPropertyName("fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [JsonPropertyName("sexo")]
        public string? Sexo { get; set; }

        [JsonPropertyName("numeroCargas")]
        public string? NumeroCargas { get; set; }

        [JsonPropertyName("codigoProvincia")]
        public string? CodigoProvincia { get; set; }

        [JsonPropertyName("codigoCiudad")]
        public string? CodigoCiudad { get; set; }

        [JsonPropertyName("direccion")]
        public string? Direccion { get; set; }

        [JsonPropertyName("nombreReferenciaFamiliar")]
        public string? NombreReferenciaFamiliar { get; set; }

        [JsonPropertyName("telefonoReferenciaFamiliar")]
        public string? TelefonoReferenciaFamiliar { get; set; }

        [JsonPropertyName("email")]
        public string?Email { get; set; }

        [JsonPropertyName("codigoOcupacion")]
        public string? CodigoOcupacion { get; set; }

        [JsonPropertyName("lugarTrabajo")]
        public string? LugarTrabajo { get; set; }

        [JsonPropertyName("telefonoEmpresa")]
        public string? TelefonoEmpresa { get; set; }

        [JsonPropertyName("direccionTrabajo")]
        public string? DireccionTrabajo { get; set; }

        [JsonPropertyName("codigoClasificacionCargo")]
        public string? CodigoClasificacionCargo { get; set; }

        [JsonPropertyName("antiguedadEconomica")]
        public string? AntiguedadEconomica { get; set; }

        [JsonPropertyName("tipoPersona")]
        public string? TipoPersona { get; set; }

        [JsonPropertyName("trabajaSector")]
        public bool? TrabajaSector { get; set; }

        [JsonPropertyName("patrimonio")]
        public string? Patrimonio { get; set; }

        [JsonPropertyName("telefonoDomicilio")]
        public string? TelefonoDomicilio { get; set; }

        [JsonPropertyName("celular")]
        public string? Celular { get; set; }

        [JsonPropertyName("conyuge")]
        public Conyuge? Conyuge { get; set; }
    }

    public class Aseguradora
    {
        [JsonPropertyName("codigoAseguradora")]
        public string? CodigoAseguradora { get; set; }
    }
}
