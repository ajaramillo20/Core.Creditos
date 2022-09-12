using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.SolicitudCreditos
{
    public class SolicitudCredito
    {
        public Solicitud Solicitud { get; set; } = new Solicitud();
    }
    public class Solicitud
    {
        public string FechaNegociacion { get; set; }
        public string CodigoConcesionario { get; set; }
        public string CedulaVendedor { get; set; }
        public string CodigoProducto { get; set; }
        public Vehiculo Vehiculo { get; set; } = new Vehiculo();
        public Cliente Cliente { get; set; } = new Cliente();
        public InformacionCredito InformacionCredito { get; set; } = new InformacionCredito();
        public Aseguradora Aseguradora { get; set; } = new Aseguradora();
    }

    public class Vehiculo
    {
        public string CodigoMarca { get; set; }
        public string CodigoModelo { get; set; }
        public string CodigoTipoUso { get; set; }
        public string PrecioConIva { get; set; }
        public DispositivoRastreo DispositivoRastreo { get; set; } = new DispositivoRastreo();
    }

    public class InformacionCredito
    {
        public string Tasa { get; set; }
        public int PlazoMeses { get; set; }
        public string MontoCredito { get; set; }
        public string ValorEntrada { get; set; }
        public int DiaPago { get; set; }
        public bool TieneGarante { get; set; }
        public string GaranteIdentificacion { get; set; }
        public string ConsumoTarjeta { get; set; }
        public string SaldoPromedioCuentas { get; set; }
        public string IngresosDeudor { get; set; }
        public string IngresosConyuge { get; set; }
        public string OtrosIngresosDeudor { get; set; }
        public string OtrosIngresosConyuge { get; set; }
        public string EgresosDeudor { get; set; }
        public string EgresosConyuge { get; set; }
        public string OtrosEgresosDeudor { get; set; }
        public string OtrosEgresosConyuge { get; set; }
        public string FuenteIngresos { get; set; }
    }

    public class DispositivoRastreo
    {
        public string CodigoDispositivoRastreo { get; set; }
        public string Precio { get; set; }
    }

    public class Conyuge
    {
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nacionalidad { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string FechaNacimiento { get; set; }
        public string Profesion { get; set; }
        public string AntiguedadEconomica { get; set; }
        public string Cargo { get; set; }
        public string ConyugeTelefono { get; set; }
    }

    public class Cliente
    {
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string InstitucionFinanciera { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nacionalidad { get; set; }
        public string CodigoTipoVivienda { get; set; }
        public string CodigoEstadoCivil { get; set; }
        public string CodigoNivelEducacion { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string NumeroCargas { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoCiudad { get; set; }
        public string Direccion { get; set; }
        public string NombreReferenciaFamiliar { get; set; }
        public string TelefonoReferenciaFamiliar { get; set; }
        public string Email { get; set; }
        public string CodigoOcupacion { get; set; }
        public string LugarTrabajo { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string DireccionTrabajo { get; set; }
        public string CodigoClasificacionCargo { get; set; }
        public string AntiguedadEconomica { get; set; }
        public string TipoPersona { get; set; }
        public string TrabajaSector { get; set; }
        public string Patrimonio { get; set; }
        public string TelefonoDomicilio { get; set; }
        public string Celular { get; set; }
        public Conyuge Conyuge { get; set; } = new Conyuge();
    }

    public class Aseguradora
    {
        public string CodigoAseguradora { get; set; }
    }
}
