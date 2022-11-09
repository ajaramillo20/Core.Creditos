using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Entidad.InformacionSolicitudCreditos
{
    public class InformacionSolicitudCredito
    {
        public string NumeroSolicitud { get; set; }
        public string CedulaVendedor { get; set; }
        public DateTime FechaNegociacion { get; set; }
        public string NombreConcesionario { get; set; }
        public string CodigoConcesionario { get; set; }
        public decimal TasaCredito { get; set; }
        public int Plazo { get; set; }
        public decimal MontoCredito { get; set; }
        public decimal ValorEntrada { get; set; }
        public int DiaPago { get; set; }
        public bool TieneGarante { get; set; }
        public string IdentificiacionGarante { get; set; }
        public string FuenteIngresos { get; set; }
        public string IdentificacionCliente { get; set; }
        public string NombreAseguradora { get; set; }
        public string NombreEstado { get; set; }
        public string IdEstado { get; set; }
        public string CodigoCredencial { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string Responsable { get; set; }
        public string Reasignado { get; set; }
        public InformacionCliente InformacionCliente { get; set; } = new InformacionCliente();
        public InformacionConyuge InformacionConyuge { get; set; } = new InformacionConyuge();
        public InformacionVehiculo InformacionVehiculo { get; set; } = new InformacionVehiculo();

    }
    public class InformacionCliente
    {
        public int NumeroSolicitud { get; set; }
        public string TipoIdentificacion { get; set; }
        public string IdentificacionCliente { get; set; }
        public string InstitucionFinanciera { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nacionalidad { get; set; }
        public string TipoVivienda { get; set; }
        public string EstadoCivil { get; set; }
        public string NivelEducacion { get; set; }
        public string FechaNacimiento { get; set; }
        public string NumeroCargas { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string NombreReferenciaFamiliar { get; set; }
        public string TelefonoReferenciaFamiliar { get; set; }
        public string Correo { get; set; }
        public string Ocupacion { get; set; }
        public string LugarTrabajo { get; set; }
        public string TelefonoTrabajo { get; set; }
        public string DireccionTrabajo { get; set; }
        public string Cargo { get; set; }
        public string AntiguedadEconomica { get; set; }
        public string TrabajaSector { get; set; }
        public string Patrimonio { get; set; }
        public string TelefonoCliente { get; set; }
        public string CelularCliente { get; set; }
        public decimal Ingresos { get; set; }
        public decimal OtrosIngresos { get; set; }
        public decimal Egresos { get; set; }
        public decimal OtrosEgresos { get; set; }
        public decimal PromedioCuentas { get; set; }

    }
    public class InformacionConyuge
    {
        public int NumeroSolicitud { get; set; }
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimeroApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Profesion { get; set; }
        public string AntiguedadEconomica { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public string Ingresos { get; set; }
        public string OtrosIngresos { get; set; }
        public string Egresos { get; set; }
        public string OtrosEgresos { get; set; }
    }
    public class InformacionVehiculo
    {
        public int NumeroSolicitud { get; set; }
        public string Anio { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Precio { get; set; }
        public string DispositivoRastreo { get; set; }
        public string DispositivoRastreoPrecio { get; set; }
    }
}
