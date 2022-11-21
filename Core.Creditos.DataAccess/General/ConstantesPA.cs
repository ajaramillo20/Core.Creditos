using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.General
{
    public static class ConstantesPA
    {
        public const string CodigoRetorno = "@CodigoRetorno";

        /// <summary>
        /// Procedimiento almacenado para insertar una solicitud de crédito
        /// </summary>
        public static class PA_CRE_INSERTAR_SOLICITUD_CREDITO
        {
            public const string PA_NOMBRE = "PA_CRE_INSERTAR_SOLICITUD_CREDITO";
            public const string PA_FECHA_NEGOCIACION = $"@FechaNegociacion";
            public const string PA_CODIGO_CONCESIONARIO = "@CodigoConcesionario";
            public const string PARAM_CEDULA_VENDEDOR = "@CedulaVendedor";
            public const string PARAM_CODIGO_PRODUCTO = "@CodigoProducto";
            public const string PARAM_VEHICULO_CODIGO_MARCA = "@CodigoMarca";
            public const string PARAM_VEHICULO_CODIGO_MODELOS = "@CodigoModelo";
            public const string PARAM_VEHICULO_CODIGO_TIPO_USO = "@CodigoTipoUso";
            public const string PARAM_VEHICULO_ANIO = "@Anio";
            public const string PARAM_VEHICULO_PRECIO_IVA = "@PrecioIva";
            public const string PARAM_DISPOSITIVO_RASTREO_CODIGO = "@CodigoDispositivoRastreo";
            public const string PARAM_DISPOSITIVO_RASTREO_PRECIO = "@DispositivoRastreoPrecio";
            public const string PARAM_CLIENTE_TIPO_IDENTIFICACION = "@ClienteTipoIdentificacion";
            public const string PARAM_CLIENTE_IDENTIFICACION = "@ClienteIdentificacion";
            public const string PARAM_CLIENTE_INSTITUCION_FINANCIERA = "@ClienteInstitucionFinanciera";
            public const string PARAM_CLIENTE_PRIMER_NOMBRE = "@ClientePrimerNombre";
            public const string PARAM_CLIENTE_SEGUNDO_NOMBRE = "@ClienteSegundoNombre";
            public const string PARAM_CLIENTE_APELLIDO_PATERNO = "@ClienteApellidoPaterno";
            public const string PARAM_CLIENTE_APELLIDO_MATERNO = "@ClienteApellidoMaterno";
            public const string PARAM_CLIENTE_NACIONALIDAD = "@ClienteNacionalidad";
            public const string PARAM_CLIENTE_CODIGO_TIPO_VIVIENDA = "@CodigoTipoVivienda";
            public const string PARAM_CLIENTE_CODIGO_ESTADO_CIVIL = "@ClienteCodigoEstadoCivil";
            public const string PARAM_CLIENTE_CODIGO_NIVEL_EDUCACION = "@ClienteCodigoNivelEducacion";
            public const string PARAM_CLIENTE_FECHA_NACIMENTO = "@ClienteFechaNacimiento";
            public const string PARAM_CLIENTE_SEXO = "@ClienteSexo";
            public const string PARAM_CLIENTE_NUMERO_CARGAS = "@ClienteNumeroCargas";
            public const string PARAM_CLIENTE_CODIGO_PROVINCIA = "@ClienteCodigoProvincia";
            public const string PARAM_CLIENTE_CODIGO_CIUDAD = "@ClienteCodigoCiudad";
            public const string PARAM_CLIENTE_DIRECCION = "@ClienteDireccion";
            public const string PARAM_CLIENTE_REFERENCIA_FAMILIAR_NOMBRE = "@ClienteReferenciaFamiliarNombre";
            public const string PARAM_CLIENTE_REFERENCIA_FAMILIAR_TELEFONO = "@ClienteReferenciaFamiliarTelefono";
            public const string PARAM_CLIENTE_EMAIL = "@ClienteEmail";
            public const string PARAM_CLIENTE_CODIGO_OCUPACION = "@ClienteCodigoOcupacion";
            public const string PARAM_CLIENTE_LUGAR_TRABAJO = "@ClienteLugarTrabajo";
            public const string PARAM_CLIENTE_LUGAR_TRABAJO_TELEFONO = "@ClienteLugarTrabajoTelefono";
            public const string PARAM_CLIENTE_LUGAR_TRABAJO_DIRECCION = "@ClienteLugarTrabajoDireccion";
            public const string PARAM_CLIENTE_CODIGO_CALISIFICACION_CARGO = "@ClienteCodigoClasificacionCargo";
            public const string PARAM_CLIENTE_ANTIGUEDAD_ECONOMICA = "@ClienteAntiguedadEconomica";
            public const string PARAM_CLIENTE_TIPO_PERSONA = "@ClienteTipoPersona";
            public const string PARAM_CLIENTE_TRABAJA_SECTOR = "@ClienteTrabajaSector";
            public const string PARAM_CLIENTE_PATRIMONIO = "@ClientePatrimonio";
            public const string PARAM_CLIENTE_DOMICILIO_TELEFONO = "@ClienteDomicilioTelefono";
            public const string PARAM_CLIENTE_CELULAR = "@ClienteCelular";
            public const string PARAM_CLIENTE_CONYUGE_IDENTIFICACION = "@ConyugeIdentificacion";
            public const string PARAM_CLIENTE_CONYUGE_PRIMER_NOMBRE = "@ConyugePrimerNombre";
            public const string PARAM_CLIENTE_CONYUGE_SEGUNDO_NOMBRE = "@ConyugeSegundoNombre";
            public const string PARAM_CLIENTE_CONYUGE_APELLIDO_PATERNO = "@ConyugeApellidoPaterno";
            public const string PARAM_CLIENTE_CONYUGE_APELLIDO_MATERNO = "@ConyugeApellidoMaterno";
            public const string PARAM_CLIENTE_CONYUGE_NACIONALIDAD = "@ConyugeNacionalidad";
            public const string PARAM_CLIENTE_CONYUGE_SEXO = "@ConyugeSexo";
            public const string PARAM_CLIENTE_CONYUGE_EMAIL = "@ConyugeEmail";
            public const string PARAM_CLIENTE_CONYUGE_FECHA_NACIMIENTO = "@@ConyugeFechaNacimiento";
            public const string PARAM_CLIENTE_CONYUGE_PROFESION = "@ConyugeProfesion";
            public const string PARAM_CLIENTE_CONYUGE_ANTIGUEDAD_ECONOMICA = "@ConyugeAntiguedadEconomica";
            public const string PARAM_CLIENTE_CONYUGE_CARGO = "@ConyugeCargo";
            public const string PARAM_CLIENTE_CONYUGE_TELEFONO = "@ConyugeTelefono";
            public const string PARAM_CREDITO_TASA = "@CreditoTasa";
            public const string PARAM_CREDITO_PLAZO_MESES = "@CreditoPlazoMeses";
            public const string PARAM_CREDITO_MONTO = "@CreditoMonto";
            public const string PARAM_CREDITO_VALOR_ENTRADA = "@CreditoValorEntrada";
            public const string PARAM_CREDITO_DIA_PAGO = "@CreditoDiaPago";
            public const string PARAM_CREDITO_TIENE_GARANTE = "@CreditoTieneGarante";
            public const string PARAM_CREDITO_GARATE_IDENTIFICACION = "@CreditoGaranteIDentifcacion";
            public const string PARAM_CREDITO_CONSUMO_TARJETA = "@CreditoConsumoTarjeta";
            public const string PARAM_CREDITO_SALGO_PROMEDIO_CUENTAS = "@CreditoSaldoPromedioCuentas";
            public const string PARAM_CREDITO_INGRESOS_DEUDOR = "@CreditoIngresosDeudor";
            public const string PARAM_CREDITO_INGRESOS_CONYUGE = "@CreditoIngresosConyuge";
            public const string PARAM_CREDITO_OTROS_INGRESOS_DEUDOR = "@CreditoOtrosIngresosDeudor";
            public const string PARAM_CREDITO_OTROS_INGRESOS_CONYUGE = "@CreditoOtrosIngresosConyuge";
            public const string PARAM_CREDITO_EGRESOS_DEUDOR = "@CreditoEgresosDeudor";
            public const string PARAM_CREDITO_EGRESOS_CONYUGE = "@CreditoEgresosConyuge";
            public const string PARAM_CREDITO_OTROS_EGRESOS_DEUDOR = "@CreditoOtrosEgresosDeudor";
            public const string PARAM_CREDITO_OTROS_EGRESOS_CONYUGE = "@CreditoOtrosEgresosConyuge";
            public const string PARAM_CREDITO_FUENTE_INGRESOS = "@CreditoFuenteIngresos";
            public const string PARAM_ASEGURADORA_CODIGO = "@AseguradoraCodigo";
            public const string PARAM_CREDITO_JSON = "@CreditoJSON";
            public const string PARAM_CREDITO_ESTADO_SOLICITUD = "@EstadoSolicitud";
            public const string PARAM_CODIGO_CREDENCIAL = "@CodigoCredencial";
            public const string PARAM_RESPONSABLE = "@Responsable";
        }

        /// <summary>
        /// Procedimiento almacenado para homologar un código externo
        /// </summary>
        public static class PA_CRE_HOMOLOGAR_CODIGO_EXTERNO
        {
            public const string PA_NOMBRE = "PA_CRE_HOMOLOGAR_CODIGO_EXTERNO";
            public const string PARAM_CODIGO_EXTERNO = "@CodigoExterno";
            public const string PARAM_CODIGO_TABLA = "@CodigoTabla";
        }

        /// <summary>
        /// Procedimiento almacenado para obtener catalogo por código
        /// </summary>
        public static class PA_CRE_OBTENER_INFORMACION_CATALOGOS
        {
            public const string PA_NOMBRE = "PA_CRE_OBTENER_INFORMACION_CATALOGOS";
            public const string PARAM_CODIGO_CATALOGO = "@CodigoCatalogo";
        }

        /// <summary>
        /// Procedimiento almacenado para obtener parametrización del sistema
        /// </summary>
        public static class PA_CRE_OBTENER_PARAMETRIZACION
        {
            public const string PA_NOMBRE = "PA_CRE_OBTENER_PARAMETRIZACION";
            public const string PARAM_CODIGO_PARAMETRIZACION = "@CodigoParametrizacion";
            public const string PARAM_CODIGO_CREDENCIAL = "@CodigoCredencial";
        }

        /// <summary>
        /// Procedimiento almacenado para validar politica de edad
        /// </summary>
        public static class PA_CRE_POLITICA_VALIDAD_EDAD
        {
            public const string PA_NOMBRE = "PA_CRE_POLITICA_VALIDAR_EDAD";
            public const string PARAM_CODIGO_EDAD_MINIMA = "@EdadMinima";
            public const string PARAM_CODIGO_EDAD_MAXIMA = "@EdadMaxima";
            public const string PARAM_EDAD_DEUDOR = "@EdadDeudor";
        }

        /// <summary>
        /// Procedimiento almacenado para validar politica de edad
        /// </summary>
        public static class PA_CRE_POLITICA_VALIDAR_INGRESOS
        {
            public const string PA_NOMBRE = "PA_CRE_POLITICA_VALIDAR_INGRESOS";
            public const string PARAM_INGRESOS_DEUDOR = "@IngresosDeudor";
            public const string PARAM_OTROS_INGRESOS_DEUDOR = "@OtrosIngresosDeudor";
            public const string PARAM_INGRESOS_CONYUGE = "@IngresosConyuge";
            public const string PARAM_OTROS_INGRESOS_CONYUGE = "@OtrosIngresosConyuge";
            public const string PARAM_CODIGO_POLITICA_INGRESOS = "CodigoPoliticaIngresos";
        }

        /// <summary>
        /// Procedimiento almacenado para obtner las reglas de cada campo del request
        /// </summary>
        public static class PA_CRE_OBTENER_REGLAS_CAMPOS_REQUEST
        {
            public const string PA_NOMBRE = "PA_CRE_OBTENER_REGLAS_CAMPOS_REQUEST";
            public const string PARMA_CODIGO_ENTIDAD = "@CodigoEntidad";
        }

        public static class PA_CRE_OBTENER_REGLAS_SOLICITUD_CREDITO
        {
            public const string PA_NOMBRE = "PA_CRE_OBTENER_REGLAS_SOLICITUD_CREDITO";
            public const string PARAM_CODIGO_ENTIDAD = "@CodigoEntidad";
        }

        public static class PA_CRE_OBTENER_ESTADO_SOLICITUD_CREDITO
        {
            public const string PA_NOMBRE = "PA_CRE_OBTENER_ESTADO_SOLICITUD_CREDITO";
            public const string PARAM_ID_ESTADO = "@IdEstado";
            public const string PARAM_CODIGO_ESTADO = "@CodigoEstado";
            public const string PARAM_NOMBRE_ESTADO = "@NombreEstado";

        }

        /// <summary>
        ///¨Procedimiento apra obtener información básica de la solicitud de crédito
        /// </summary>
        public static class PA_CRE_OBTNER_SOLICITUD_CREDITO
        {
            public const string PA_NOMBRE = "PA_CRE_OBTENER_SOLICITUD_CREDITO";
            public const string PARAM_NUMERO_SOLICITUD_CREDITO = "@NumeroSolicitudCredito";
        }

        public static class PA_CRE_VALIDAR_CAMBIO_ESTADO_SOLICITUD_CREDITO
        {
            public const string PA_NOMBRE = "PA_CRE_VALIDAR_CAMBIO_ESTADO_SOLICITUD_CREDITO";
            public const string PARAM_ESTADO_ORIGEN_ID = "@EstadoOrigenId";
            public const string PARAM_ESTADO_DESTINO_ID = "@EstadoDestinoId";
        }

        public static class PA_CRE_CAMBIAR_ESTADO_SOLICITUD_CREDITO
        {
            public const string PA_NOMBRE = "PA_CRE_CAMBIAR_ESTADO_SOLICITUD_CREDITO";
            public const string PARAM_NUMERO_SOLICITUD = "@NumeroSolicitud";
            public const string PARAM_CODIGO_ESTADO_DESTINO = "@CodigoEstadoDestino";
        }

        public static class PA_CRE_API_OBTENER_DATOS_PETICION
        {
            public const string PARAM_CODIGO_CREDENCIAL = "@CodigoCredencial";
            public static string PA_NOMBRE = "PA_CRE_API_OBTENER_DATOS_PETICION";
            public static string PA_NOMBRE_HEADERS = "PA_CRE_API_OBTENER_HEADERS_PETICION";
            public static string PA_NOMBRE_QUERY_PARAMS = "PA_CRE_API_OBTENER_QUERY_PARAMS_PETICION";
            public static string PA_NOMBRE_CAMPOS_RESULT = "PA_CRE_API_OBTENER_CAMPOS_RESULT";
        }

        public static class PA_CRE_OBTENER_LISTA_SOLICITUD_CREDITOS
        {
            public static string PA_NOMBRE = "PA_CRE_OBTENER_LISTA_SOLICITUD_CREDITOS";
        }

        public static class PA_CRE_OBTENER_FLUJO_ESTADO_CREDITO
        {
            public static string PA_NOMBRE = "PA_CRE_OBTENER_FLUJO_ESTADO_CREDITO";
            public static string PARRAM_ESTADO_ORIGEN = "@EstadoOrigenId";
        }

        public static class PA_CRE_VALIDAR_USUARIO_RESPONSABLE
        {
            public static string PA_NOMBRE = "PA_CRE_VALIDAR_USUARIO_RESPONSABLE";
            public static string PARAM_USUARIO = "@Usuario";
        }

        public static class PA_CRE_OBTENER_USUARIOS
        {
            public static string PA_NOMBRE = "PA_CRE_OBTENER_USUARIOS_ACTIVOS";
        }

        public static class PA_CRE_OBTENER_INFORMACION_CREDITO
        {
            public const string PARAM_NUMERO_SOLICITUD = "@NumeroSolicitud";
            public const string PA_NOMBRE = "PA_CRE_OBTENER_INFORMACION_CREDITO";
            public const string PA_NOMBRE_CLIENTE_INFORMACION = "PA_CRE_OBTENER_INFORMACION_CREDITO_CLIENTE";
            public const string PA_NOMBRE_CONYUGE_INFORMACION = "PA_CRE_OBTENER_INFORMACION_CREDITO_CONYUGE";
            public const string PA_NOMBRE_VEHICULO_INFORMACION = "PA_CRE_OBTENER_INFORMACION_CREDITO_VEHICULO";
        }

        public static class PA_CRE_OBTENER_INFORMACION_USUARIO
        {
            public const string PA_NOMBRE = "PA_CRE_OBTENER_INFORMACION_USUARIO";
            public const string PA_USUARIO_RED = "@UsuarioRed";
        }

        public static class PA_CRE_ACTUALIZAR_ESTADO_USUARIO
        {
            public const string PA_NOMBRE = "PA_CRE_ACTUALIZAR_ESTADO_USUARIO";
            public const string PARAM_USUARIO_ID = "@UsuarioId";
            public const string PARAM_ESTADO = "@Estado";
        }

        public static class PA_CRE_OBTENER_CREDITO_ROL
        {
            public const string PA_NOMBRE = "PA_CRE_OBTENER_CREDITO_ROL";
        }

        public static class PA_CRE_AGREGAR_HISTORIAL_SOLICITUD_CREDITO
        {
            public const string PA_NOMBRE = "PA_CRE_AGREGAR_HISTORIAL_SOLICITUD_CREDITO";
            public const string PARAM_USUARIO_RED = "@UsuarioRed";
            public const string PARAM_ESTADO_CODIGO = "@EstadoCreditoCodigo";
            public const string PARAM_NUMERO_SOLICITUD = "@NumeroSolicitud";
            public const string PARAM_COMENTARIO = "@Comentario";
        }

        public static class PA_CRE_ACTUALIZAR_RESPONSABLE
        {
            public const string PA_NOMBRE = "PA_CRE_ACTUALIZAR_RESPONSABLE";
            public const string PARAM_NUMERO_SOLICITUD = "@NumeroSolicitud";
            public const string PARAM_RESPONSABLE_NUEVO = "@ResponsableNuevo";
            public const string PARAM_USUARIO_APLICACION = "@UsuarioAplicacion";
        }

        public static class PA_CRE_AGREGAR_USUARIO_COLA
        {
            public const string PA_NOMBRE = "PA_CRE_AGREGAR_USUARIO_COLA";
            public const string PARAM_NOMBRE_RED = "@NombreRed";
            public const string PARAM_CODIGO_ROL = "@CodigoRol";
        }

        public class PA_CRE_OBTENER_USUARIOS_COLA
        {
            public const string PA_NOMBRE = "PA_CRE_OBTENER_USUARIOS_COLA";
        }
        public class PA_CRE_ELIMINAR_USUARIO_COLA
        {
            public const string PA_NOMBRE = "PA_CRE_ELIMINAR_USUARIO_COLA";
            public const string PARAM_NOMBRE_RED = "@NombreRed";
            public const string PARAM_CODIGO_ROL = "@CodigoRol";
        }
    }
}

