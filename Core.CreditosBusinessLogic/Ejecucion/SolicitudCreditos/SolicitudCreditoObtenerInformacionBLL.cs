using AutoMapper;
using Core.Common.Model.ExcepcionServicio;
using Core.Common.Util.Helper.Internal;
using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.Entidad.InformacionSolicitudCreditos;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Core.Creditos.DataAccess.SolicitudCreditos.ObtenerInformacionCreditosDAL;

namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class SolicitudCreditoObtenerInformacionBLL
    {
        /// <summary>
        /// Obtiene listado de solicitudes de credito
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ObtenerListaSolicitudCredito(SolicitudCreditoTrx objetoTransaccional)
        {
            var listaCreditos = ObtenerListaSolicitudCreditosDAL.Execute();

            foreach (var cre in listaCreditos)
            {
                var solicitud = new Solicitud()
                {
                    NumeroSolicitud = cre.NumeroSolicitud,
                    TiempoTranscurrido = cre.TiempoTranscurrido,
                    FechaNegociacion = cre.FechaNegociacion,
                    FechaAsignacion = cre.FechaAsignacion,
                    CedulaVendedor = cre.CedulaVendedor,
                    NombreVendedor = cre.NombreVendedor,
                    CodigoConcesionario = cre.Concesionario,
                    CodigoProducto = cre.TipoCredito,
                    Responsable = cre.Responsable,
                    ResponsableUsuarioRed = cre.ResponsableUsuarioRed,
                    Reasignado = cre.Reasignado,
                    ReasignadoUsuarioRed = cre.ReasignadoUsuarioRed,     
                    CalificacionBuro = cre.CalificacionBuro,
                    Aseguradora = new Aseguradora
                    {
                        CodigoAseguradora = cre.CodigoAseguradora,
                    },
                    EstadoSolicitud = new EstadoSolicitudCredito()
                    {
                        EstadoId = cre.EstadoCreditoId,
                        CodigoNombre = cre.EstadoCreditoNombre,
                        EstadoNombre = cre.EstadoCreditoNombre
                    },
                    Vehiculo = new Vehiculo()
                    {
                        CodigoMarca = cre.MarcaVehiculo,
                        CodigoModelo = cre.ModeloVehiculo,
                        DispositivoRastreo = new DispositivoRastreo
                        {
                            CodigoDispositivoRastreo = cre.DispositivoRastreo,
                            Precio = cre.PrecioDispositivoRastreo
                        }
                    },
                    Cliente = new Cliente()
                    {
                        PrimerNombre = cre.NombreCliente,
                        FechaNacimiento = cre.FechaNacimientoCliente,
                        Identificacion = cre.CedulaCliente,
                        CodigoCiudad = cre.Ciudad,
                        CodigoProvincia = cre.Provinvia,
                        Nacionalidad = cre.Nacionalidad,
                        ApellidoPaterno = cre.ApellidoCliente,
                        TelefonoDomicilio = cre.Telefono,
                        LugarTrabajo = cre.LugarTrabajo,
                        Direccion = cre.DireccionCliente,
                        CodigoEstadoCivil = cre.EstadoCivil
                    },
                    InformacionCredito = new InformacionCredito()
                    {
                        Tasa = cre.Tasa,
                        IngresosDeudor = cre.IngresoDeudor,
                        OtrosIngresosDeudor = cre.OtrosIngresosDeudor,
                        PlazoMeses = cre.PlazoMeses,
                        MontoCredito = cre.Monto,
                        FuenteIngresos = cre.FuenteIngresos
                    }
                };
                objetoTransaccional.SolicitudCreditoList.Add(solicitud);
            }
        }

        /// <summary>
        /// OBtiene información solicitud crédito
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        public static void ObtenerInformacionSolicitudCredito(SolicitudCreditoTrx objetoTransaccional)
        {
            var solicitud = ObtenerInformacionCreditosDAL.Execute(objetoTransaccional.NumeroSolicitudCredito.ToString() ?? "");
            if (solicitud == null)
            {
                throw new ExcepcionServicio((int)ErroresSolicitudCredito.SolicitudNoEncontrada);
            }

            objetoTransaccional.InformacionSolicitudCredito = new InformacionSolicitudCredito
            {
                NumeroSolicitud = solicitud.NumeroSolicitud,
                CedulaVendedor = solicitud.CedulaVendedor, 
                NombreVendedor = solicitud.NombreVendedor,
                FechaNegociacion = solicitud.FechaNegociacion,
                FechaAsignacion = solicitud.FechaAsignacion,
                NombreConcesionario = solicitud.NombreConcesionario,
                CodigoConcesionario = solicitud.CodigoConcesionario,
                TasaCredito = solicitud.TasaCredito,
                Plazo = solicitud.Plazo,
                MontoCredito = solicitud.MontoCredito,
                ValorEntrada = solicitud.ValorEntrada,
                DiaPago = solicitud.DiaPago,
                TieneGarante = solicitud.TieneGarante,
                IdentificiacionGarante = solicitud.IdentificiacionGarante,
                CalificacionBuro = solicitud.CalificacionBuro,
                FuenteIngresos = solicitud.FuenteIngresos,
                IdentificacionCliente = solicitud.IdentificacionCliente,
                NombreAseguradora = solicitud.NombreAseguradora,
                NombreEstado = solicitud.NombreEstado,
                IdEstado = solicitud.IdEstado,
                CodigoCredencial = solicitud.CodigoCredencial,
                NombreProducto = solicitud.NombreProducto,
                CodigoProducto = solicitud.CodigoProducto,
                Reasignado = solicitud.Reasignado,
                Responsable = solicitud.Responsable,

                InformacionCliente = new Creditos.Model.Entidad.InformacionSolicitudCreditos.InformacionCliente()
                {
                    NumeroSolicitud = solicitud.InformacionCliente.NumeroSolicitud,
                    TipoIdentificacion = solicitud.InformacionCliente.TipoIdentificacion,
                    InstitucionFinanciera = solicitud.InformacionCliente.InstitucionFinanciera,
                    PrimerNombre = solicitud.InformacionCliente.PrimerNombre,
                    SegundoNombre = solicitud.InformacionCliente.SegundoNombre,
                    PrimerApellido = solicitud.InformacionCliente.PrimerApellido,
                    SegundoApellido = solicitud.InformacionCliente.SegundoApellido,
                    Nacionalidad = solicitud.InformacionCliente.Nacionalidad,
                    TipoVivienda = solicitud.InformacionCliente.TipoVivienda,
                    EstadoCivil = solicitud.InformacionCliente.EstadoCivil,
                    NivelEducacion = solicitud.InformacionCliente.NivelEducacion,
                    FechaNacimiento = solicitud.InformacionCliente.FechaNacimiento,
                    NumeroCargas = solicitud.InformacionCliente.NumeroCargas,
                    Provincia = solicitud.InformacionCliente.Provincia,
                    Ciudad = solicitud.InformacionCliente.Ciudad,
                    Direccion = solicitud.InformacionCliente.Direccion,
                    NombreReferenciaFamiliar = solicitud.InformacionCliente.NombreReferenciaFamiliar,
                    TelefonoReferenciaFamiliar = solicitud.InformacionCliente.TelefonoReferenciaFamiliar,
                    Correo = solicitud.InformacionCliente.Correo,
                    Ocupacion = solicitud.InformacionCliente.Ocupacion,
                    LugarTrabajo = solicitud.InformacionCliente.LugarTrabajo,
                    TelefonoTrabajo = solicitud.InformacionCliente.TelefonoTrabajo,
                    DireccionTrabajo = solicitud.InformacionCliente.DireccionTrabajo,
                    Cargo = solicitud.InformacionCliente.Cargo,
                    AntiguedadEconomica = solicitud.InformacionCliente.AntiguedadEconomica,
                    TrabajaSector = solicitud.InformacionCliente.TrabajaSector,
                    Patrimonio = solicitud.InformacionCliente.Patrimonio,
                    TelefonoCliente = solicitud.InformacionCliente.TelefonoCliente,
                    CelularCliente = solicitud.InformacionCliente.CelularCliente,
                    Ingresos = solicitud.InformacionCliente.Ingresos,
                    OtrosIngresos = solicitud.InformacionCliente.OtrosIngresos,
                    Egresos = solicitud.InformacionCliente.Egresos,
                    OtrosEgresos = solicitud.InformacionCliente.OtrosEgresos,
                    PromedioCuentas = solicitud.InformacionCliente.PromedioCuentas
                },
                InformacionVehiculo = new Creditos.Model.Entidad.InformacionSolicitudCreditos.InformacionVehiculo()
                {
                    Anio = solicitud.InformacionVehiculo.Anio,
                    Marca = solicitud.InformacionVehiculo.Marca,
                    Modelo = solicitud.InformacionVehiculo.Modelo,
                    Precio = solicitud.InformacionVehiculo.Precio,
                    DispositivoRastreo = solicitud.InformacionVehiculo.DispositivoRastreo,
                    DispositivoRastreoPrecio = solicitud.InformacionVehiculo.DispositivoRastreoPrecio
                }
            };

            if (solicitud.InformacionConyuge != null)
            {
                objetoTransaccional.InformacionSolicitudCredito.InformacionConyuge = new Creditos.Model.Entidad.InformacionSolicitudCreditos.InformacionConyuge()
                {
                    NumeroSolicitud = solicitud.InformacionConyuge.NumeroSolicitud,
                    Identificacion = solicitud.InformacionConyuge.Identificacion,
                    PrimerNombre = solicitud.InformacionConyuge.PrimerNombre,
                    SegundoNombre = solicitud.InformacionConyuge.SegundoNombre,
                    PrimeroApellido = solicitud.InformacionConyuge.PrimeroApellido,
                    SegundoApellido = solicitud.InformacionConyuge.SegundoApellido,
                    FechaNacimiento = solicitud.InformacionConyuge.FechaNacimiento,
                    Profesion = solicitud.InformacionConyuge.Profesion,
                    AntiguedadEconomica = solicitud.InformacionConyuge.AntiguedadEconomica,
                    Cargo = solicitud.InformacionConyuge.Cargo,
                    Telefono = solicitud.InformacionConyuge.Telefono,
                    Ingresos = solicitud.InformacionConyuge.Ingresos,
                    OtrosIngresos = solicitud.InformacionConyuge.OtrosIngresos,
                    Egresos = solicitud.InformacionConyuge.Egresos,
                    OtrosEgresos = solicitud.InformacionConyuge.OtrosEgresos
                };
            }

        }
    }
}
