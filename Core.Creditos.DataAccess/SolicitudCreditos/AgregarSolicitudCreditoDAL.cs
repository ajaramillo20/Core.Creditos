using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.SolicitudCreditos
{
    /// <summary>
    /// Procedimiento almacenado para insertar una nueva
    /// solicitud de crédito
    /// </summary>
    public static class AgregarSolicitudCreditoDAL
    {
        public static AgregarSolicitudCreditoResult Execute(SolicitudCreditoTrx objetoTransaccional)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
            var dynamicParameters = new DynamicParameters();

            var solicitud = objetoTransaccional?.SolicitudCredito?.Solicitud;
            var cliente = solicitud?.Cliente;
            var vehiculo = solicitud?.Vehiculo;
            var conyuge = cliente?.Conyuge;
            var informacionCredito = solicitud?.InformacionCredito;
            var aseguradora = solicitud?.Aseguradora;

            //Información            
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PA_CODIGO_CONCESIONARIO, solicitud?.CodigoConcesionario, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CEDULA_VENDEDOR, solicitud.CedulaVendedor, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CODIGO_PRODUCTO, solicitud.CodigoProducto, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CODIGO_CREDENCIAL, objetoTransaccional?.Credenciales?.Codigo, System.Data.DbType.String);

            #region Vehiculo
            //Vehiculo
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_VEHICULO_CODIGO_MARCA, vehiculo?.CodigoMarca, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_VEHICULO_CODIGO_MODELOS, vehiculo?.CodigoModelo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_VEHICULO_CODIGO_TIPO_USO, vehiculo?.CodigoTipoUso, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_VEHICULO_PRECIO_IVA, vehiculo?.PrecioConIva, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_VEHICULO_ANIO, vehiculo?.Anio, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_DISPOSITIVO_RASTREO_CODIGO, vehiculo?.DispositivoRastreo?.CodigoDispositivoRastreo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_DISPOSITIVO_RASTREO_PRECIO, vehiculo?.DispositivoRastreo?.Precio, System.Data.DbType.Decimal);
            
            #endregion

            #region Cliente
            //Cliente
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_TIPO_IDENTIFICACION, cliente?.TipoIdentificacion, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_IDENTIFICACION, cliente?.Identificacion, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_INSTITUCION_FINANCIERA, cliente?.InstitucionFinanciera, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_PRIMER_NOMBRE, cliente?.PrimerNombre, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_SEGUNDO_NOMBRE, cliente?.SegundoNombre, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_APELLIDO_PATERNO, cliente?.ApellidoPaterno, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_APELLIDO_MATERNO, cliente?.ApellidoMaterno, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_NACIONALIDAD, cliente?.Nacionalidad, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CODIGO_TIPO_VIVIENDA, cliente?.CodigoTipoVivienda, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CODIGO_ESTADO_CIVIL, cliente?.CodigoEstadoCivil, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CODIGO_NIVEL_EDUCACION, cliente?.CodigoNivelEducacion, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_FECHA_NACIMENTO, cliente?.FechaNacimiento, System.Data.DbType.DateTime);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_SEXO, cliente?.Sexo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_NUMERO_CARGAS, cliente?.NumeroCargas, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CODIGO_PROVINCIA, cliente?.CodigoProvincia, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CODIGO_CIUDAD, cliente?.CodigoCiudad, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_DIRECCION, cliente?.Direccion, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_REFERENCIA_FAMILIAR_NOMBRE, cliente?.NombreReferenciaFamiliar, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_REFERENCIA_FAMILIAR_TELEFONO, cliente?.TelefonoReferenciaFamiliar, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_EMAIL, cliente?.Email, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CODIGO_OCUPACION, cliente?.CodigoOcupacion, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_LUGAR_TRABAJO, cliente?.LugarTrabajo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_LUGAR_TRABAJO_TELEFONO, cliente?.TelefonoEmpresa, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_LUGAR_TRABAJO_DIRECCION, cliente?.DireccionTrabajo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CODIGO_CALISIFICACION_CARGO, cliente?.CodigoClasificacionCargo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_ANTIGUEDAD_ECONOMICA, cliente?.AntiguedadEconomica, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_TIPO_PERSONA, cliente?.TipoPersona, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_TRABAJA_SECTOR, cliente?.TrabajaSector, System.Data.DbType.Boolean);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_PATRIMONIO, cliente?.Patrimonio, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_DOMICILIO_TELEFONO, cliente?.TelefonoDomicilio, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CELULAR, cliente?.Celular, System.Data.DbType.String);
            #endregion

            #region Conyuge
            ////Conyuge
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_IDENTIFICACION, conyuge?.Identificacion, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_PRIMER_NOMBRE, conyuge?.PrimerNombre, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_SEGUNDO_NOMBRE, conyuge?.SegundoNombre, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_APELLIDO_PATERNO, conyuge?.ApellidoPaterno, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_APELLIDO_MATERNO, conyuge?.ApellidoMaterno, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_NACIONALIDAD, conyuge?.Nacionalidad, System.Data.DbType.String);            
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_SEXO, conyuge?.Sexo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_EMAIL, conyuge?.Email, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_FECHA_NACIMIENTO, conyuge?.FechaNacimiento, System.Data.DbType.DateTime);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_PROFESION, conyuge?.Profesion, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_ANTIGUEDAD_ECONOMICA, conyuge?.AntiguedadEconomica, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_CARGO, conyuge?.Cargo, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CLIENTE_CONYUGE_TELEFONO, conyuge?.ConyugeTelefono, System.Data.DbType.String);
            #endregion

            #region InformacionCredito
            //Información Crédito            
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_TASA, informacionCredito?.Tasa, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_PLAZO_MESES, informacionCredito?.PlazoMeses, System.Data.DbType.Int32);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_MONTO, informacionCredito?.MontoCredito, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_VALOR_ENTRADA, informacionCredito?.ValorEntrada, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_DIA_PAGO, informacionCredito?.DiaPago, System.Data.DbType.Int32);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_TIENE_GARANTE, informacionCredito?.TieneGarante, System.Data.DbType.Boolean);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_GARATE_IDENTIFICACION, informacionCredito?.GaranteIdentificacion, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_CONSUMO_TARJETA, informacionCredito?.ConsumoTarjeta, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_SALGO_PROMEDIO_CUENTAS, informacionCredito?.SaldoPromedioCuentas, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_INGRESOS_DEUDOR, informacionCredito?.IngresosDeudor, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_INGRESOS_CONYUGE, informacionCredito?.IngresosConyuge, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_OTROS_INGRESOS_DEUDOR, informacionCredito?.OtrosIngresosDeudor, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_OTROS_INGRESOS_CONYUGE, informacionCredito?.OtrosIngresosConyuge, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_EGRESOS_DEUDOR, informacionCredito?.EgresosDeudor, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_EGRESOS_CONYUGE, informacionCredito?.EgresosConyuge, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_OTROS_EGRESOS_DEUDOR, informacionCredito?.OtrosEgresosDeudor, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_OTROS_EGRESOS_CONYUGE, informacionCredito?.OtrosEgresosConyuge, System.Data.DbType.Decimal);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_FUENTE_INGRESOS, informacionCredito?.FuenteIngresos, System.Data.DbType.String);
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_ESTADO_SOLICITUD, objetoTransaccional?.CodigoEstadoSolicitudCredito, System.Data.DbType.String);
            #endregion

            //Aseguradora
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_ASEGURADORA_CODIGO, aseguradora?.CodigoAseguradora, System.Data.DbType.String);

            //Request
            dynamicParameters.Add(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PARAM_CREDITO_JSON, objetoTransaccional?.SolicitudCreditoJsonRequest, System.Data.DbType.String);

            var resultado = coneccion.ObtenerListaDatos<AgregarSolicitudCreditoResult>(ConstantesPA.PA_CRE_INSERTAR_SOLICITUD_CREDITO.PA_NOMBRE, dynamicParameters);
            return resultado.First();
        }

        public class AgregarSolicitudCreditoResult
        {
            public int NumeroSolicitudCredito { get; set; }
            public string ClienteNombre { get; set; }

            public string CodigoEstadoSolicitudCredito { get; set; }

            public string NombreEstadoSolicitudCredito { get; set; }
        }
    }
}
