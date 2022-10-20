using Core.Creditos.DataAccess.SolicitudCreditos;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class SolicitudCreditoObtenerInformacionBLL
    {
        public static void ObtenerListaSolicitudCredito(SolicitudCreditoTrx objetoTransaccional)
        {
            var listaCreditos = ObtenerListaSolicitudCreditosDAL.Execute();

            foreach (var cre in listaCreditos)
            {
                var solicitud = new Solicitud()
                {
                    NumeroSolicitud = cre.NumeroSolicitud,
                    FechaNegociacion = cre.FechaNegociacion,
                    CedulaVendedor = cre.CedulaVendedor,
                    CodigoConcesionario = cre.Concesionario,
                    CodigoProducto = cre.TipoCredito,
                    Responsable = cre.Responsable,
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
                        DispositivoRastreo = new DispositivoRastreo { 
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
                        LugarTrabajo =  cre.LugarTrabajo,
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
    }
}
