using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Creditos.DataAccess.SolicitudCreditos.ObtenerListaSolicitudCreditosDAL;

namespace Core.Creditos.DataAccess.SolicitudCreditos
{
    public static class ObtenerInformacionCreditosDAL
    {
        public static ObtenerInformacionCreditosResult Execute(string numeroSolicitud)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();


            dynamicParameters.Add(ConstantesPA.PA_CRE_CAMBIAR_ESTADO_SOLICITUD_CREDITO.PARAM_NUMERO_SOLICITUD, numeroSolicitud, System.Data.DbType.Int32);


            var informacionCredito = coneccion.ObtenerListaDatos<ObtenerInformacionCreditosResult>(ConstantesPA.PA_CRE_OBTENER_INFORMACION_CREDITO.PA_NOMBRE, dynamicParameters).FirstOrDefault();

            if (informacionCredito != null)
            {
                coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));

                var informacionCliente = coneccion.ObtenerListaDatos<InformacionCliente>(ConstantesPA.PA_CRE_OBTENER_INFORMACION_CREDITO.PA_NOMBRE_CLIENTE_INFORMACION, dynamicParameters).FirstOrDefault();
                informacionCredito.InformacionCliente = informacionCliente;

                coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));

                var informacionConyuge = coneccion.ObtenerListaDatos<InformacionConyuge>(ConstantesPA.PA_CRE_OBTENER_INFORMACION_CREDITO.PA_NOMBRE_CONYUGE_INFORMACION, dynamicParameters).FirstOrDefault();
                informacionCredito.InformacionConyuge = informacionConyuge;

                coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));

                var informacionVehiculo = coneccion.ObtenerListaDatos<InformacionVehiculo>(ConstantesPA.PA_CRE_OBTENER_INFORMACION_CREDITO.PA_NOMBRE_VEHICULO_INFORMACION, dynamicParameters).FirstOrDefault();
                informacionCredito.InformacionVehiculo = informacionVehiculo;
            }
            return informacionCredito;
        }

        public class ObtenerInformacionCreditosResult
        {
            public string NumeroSolicitud { get; set; } = "";
            public string CedulaVendedor { get; set; } = "";
            public string NombreVendedor { get; set; } = "";
            public DateTime FechaNegociacion { get; set; }
            public DateTime FechaAsignacion { get; set; }
            public string NombreConcesionario { get; set; } = "";
            public string CodigoConcesionario { get; set; } = "";
            public decimal TasaCredito { get; set; }
            public int Plazo { get; set; }
            public decimal MontoCredito { get; set; }
            public decimal ValorEntrada { get; set; }
            public int DiaPago { get; set; }
            public bool TieneGarante { get; set; }
            public string IdentificiacionGarante { get; set; } = "";
            public string FuenteIngresos { get; set; } = "";
            public string IdentificacionCliente { get; set; } = "";
            public string NombreAseguradora { get; set; } = "";
            public string NombreEstado { get; set; } = "";
            public string IdEstado { get; set; } = "";
            public string CalificacionBuro { get; set; } = "";
            public string CodigoCredencial { get; set; } = "";
            public string NombreProducto { get; set; } = "";
            public string CodigoProducto { get; set; } = "";
            public string Responsable { get; set; } = "";
            public string Reasignado { get; set; } = "";
            public InformacionCliente InformacionCliente { get; set; } = new InformacionCliente();
            public InformacionConyuge InformacionConyuge { get; set; } = new InformacionConyuge();
            public InformacionVehiculo InformacionVehiculo { get; set; } = new InformacionVehiculo();
        }
        public class InformacionCliente
        {
            //PERSONALIZADAS
            public string FechaNacimientoCliente
            {
                get
                {
                    if (!string.IsNullOrEmpty(FechaNacimiento))
                    {
                        try
                        {
                            return Convert.ToDateTime(FechaNacimiento).ToString("MM/dd/yyyy");
                        }
                        catch (Exception)
                        {

                            return "-";
                        }
                    }

                    return "";
                }
                set { }
            }

            public string Edad
            {
                get
                {

                    try
                    {
                        return (DateTime.Today.AddTicks(-Convert.ToDateTime(FechaNacimiento).Ticks).Year - 1).ToString();
                    }
                    catch (Exception)
                    {

                        return "";
                    }

                }
                set { }
            }

            public int NumeroSolicitud { get; set; }
            public string TipoIdentificacion { get; set; } = "";
            public string IdentificacionCliente { get; set; } = "";
            public string InstitucionFinanciera { get; set; } = "";
            public string PrimerNombre { get; set; } = "";
            public string SegundoNombre { get; set; } = "";
            public string PrimerApellido { get; set; } = "";
            public string SegundoApellido { get; set; } = "";
            public string Nacionalidad { get; set; } = "";
            public string TipoVivienda { get; set; } = "";
            public string EstadoCivil { get; set; } = "";
            public string NivelEducacion { get; set; } = "";
            public string FechaNacimiento { get; set; } = "";
            public string NumeroCargas { get; set; } = "";
            public string Provincia { get; set; } = "";
            public string Ciudad { get; set; } = "";
            public string Direccion { get; set; } = "";
            public string NombreReferenciaFamiliar { get; set; } = "";
            public string TelefonoReferenciaFamiliar { get; set; } = "";
            public string Correo { get; set; } = "";
            public string Ocupacion { get; set; } = "";
            public string LugarTrabajo { get; set; } = "";
            public string TelefonoTrabajo { get; set; } = "";
            public string DireccionTrabajo { get; set; } = "";
            public string Cargo { get; set; } = "";
            public string AntiguedadEconomica { get; set; } = "";
            public string TrabajaSector { get; set; } = "";
            public string Patrimonio { get; set; } = "";
            public string TelefonoCliente { get; set; } = "";
            public string CelularCliente { get; set; } = "";
            public decimal Ingresos { get; set; }
            public decimal OtrosIngresos { get; set; }
            public decimal Egresos { get; set; }
            public decimal OtrosEgresos { get; set; }
            public decimal PromedioCuentas { get; set; }

        }

        public class InformacionConyuge
        {
            //GETTERS PERSONALIZADOS
            public string NombresConyuge { get { return $"{PrimerNombre} {SegundoNombre}"; } }
            public string PrimerApellidoConyuge { get { return PrimeroApellido; } }
            public string SegundoApellidoConyuge { get { return SegundoApellido; } }
            public string IdentidicacionConyuge { get { return Identificacion; } }
            public string AntiguedadEconomicaConyuge { get { return AntiguedadEconomica; } }
            public string TelefonoConyuge { get { return Telefono; } }

            public string IngresosConyuge { get { return Ingresos; } }
            public string OtrosIngresosConyuge { get { return OtrosIngresos; } }
            public string EgresosConyuge { get { return Egresos; } }
            public string OtrosEgresosConyuge { get { return OtrosEgresos; } }


            //

            public int NumeroSolicitud { get; set; }
            public string Identificacion { get; set; } = "";
            public string PrimerNombre { get; set; } = "";
            public string SegundoNombre { get; set; } = "";
            public string PrimeroApellido { get; set; } = "";
            public string SegundoApellido { get; set; } = "";
            public string FechaNacimiento { get; set; } = "";
            public string Profesion { get; set; } = "";
            public string AntiguedadEconomica { get; set; } = "";
            public string Cargo { get; set; } = "";
            public string Telefono { get; set; } = "";
            public string Ingresos { get; set; } = "";
            public string OtrosIngresos { get; set; } = "";
            public string Egresos { get; set; } = "";
            public string OtrosEgresos { get; set; } = "";
        }

        public class InformacionVehiculo
        {
            public int NumeroSolicitud { get; set; }
            public string Anio { get; set; } = "";
            public string Marca { get; set; } = "";
            public string Modelo { get; set; } = "";
            public string Precio { get; set; } = "";
            public string DispositivoRastreo { get; set; } = "";
            public string DispositivoRastreoPrecio { get; set; } = "";
        }
    }
}
