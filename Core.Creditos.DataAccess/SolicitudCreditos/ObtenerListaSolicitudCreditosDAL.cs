using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.SolicitudCreditos
{
    public static class ObtenerListaSolicitudCreditosDAL
    {
        public static List<ObtenerListaSolicitudCreditosResult> Execute()
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            var resultado = coneccion.ObtenerListaDatos<ObtenerListaSolicitudCreditosResult>(ConstantesPA.PA_CRE_OBTENER_LISTA_SOLICITUD_CREDITOS.PA_NOMBRE, dynamicParameters);
            return resultado;
        }

        public class ObtenerListaSolicitudCreditosResult
        {
            public string NumeroSolicitud { get; set; }
            public DateTime FechaNegociacion { get; set; }
            public DateTime FechaAsignacion { get; set; }
            public int TiempoTranscurrido { get; set; }
            public string CedulaVendedor { get; set; }
            public string NombreVendedor { get; set; }
            public DateTime FechaNacimientoCliente { get; set; }
            public string NombreCliente { get; set; }
            public string CedulaCliente { get; set; }
            public string ModeloVehiculo { get; set; }
            public string MarcaVehiculo { get; set; }
            public string Concesionario { get; set; }
            public decimal Tasa { get; set; }
            public decimal Monto { get; set; }
            public int PlazoMeses { get; set; }
            public decimal IngresoDeudor { get; set; }
            public decimal OtrosIngresosDeudor { get; set; }
            public string TipoCredito { get; set; }
            public string EstadoCreditoNombre { get; set; }
            public int EstadoCreditoId { get; set; }
            public string EstadoCreditoCodigo { get; set; }
            public string Responsable { get; set; }
            public string Reasignado { get; set; }
            public string Nacionalidad { get; set; }
            public string Provinvia { get; set; }
            public string Ciudad { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
            public string LugarTrabajo { get; set; }
            public string DireccionCliente { get; set; }
            public string EstadoCivil { get; set; }
            public string FuenteIngresos { get; set; }
            public string DispositivoRastreo { get; set; }
            public decimal? PrecioDispositivoRastreo { get; set; }
            public string CodigoAseguradora { get; set; }
            public string ApellidoCliente { get; set; }
            public string ResponsableUsuarioRed { get; set; }
            public string ReasignadoUsuarioRed { get; set; }
            public string CalificacionBuro { get; set; }
        }
    }
}
