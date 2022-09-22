using Core.Common.Model.ExcepcionServicio;
using Core.Common.Model.Transaccion.Base;
using Core.Creditos.DataAccess.Catalogos;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.General;
using Core.Creditos.Model.Transaccion.Transaccional.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Ejecucion.SolicitudCreditos
{
    public static class SolicitudCreditoHomologarInformacionBLL
    {
        public static void HomologarCodigosExternos(SolicitudCreditoTrx objetoTransaccional)
        {
            //var solicitud = objetoTransaccional.SolicitudCredito.Solicitud;
            //var cliente = solicitud.Cliente;
            //var vehiculo = solicitud.Vehiculo;

            ////List<string> listaHomologacion;
            ////foreach (var item in listaHomologacion)
            ////{
            ////    HomologarCatalogoExternoDAL.Execute(item.jsorequestName, TablasCatalogos.CONCESIONARIOS)
            ////}

            //var catalogoConcesionario = HomologarCatalogoExternoDAL.Execute(solicitud.CodigoConcesionario, TablasCatalogos.CONCESIONARIOS);
            //solicitud.CodigoConcesionario = catalogoConcesionario!=null?catalogoConcesionario.CodigoInterno:
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoConcesionarioNoEncontrado);



            //var catalogoNacionalidad = HomologarCatalogoExternoDAL.Execute(cliente.Nacionalidad, TablasCatalogos.NACIONALIDADES);
            //cliente.Nacionalidad = (catalogoNacionalidad != null) ? catalogoNacionalidad.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoNacionalidadNoEncontrado);

            //var catalogoMarcaVehiculo = HomologarCatalogoExternoDAL.Execute(vehiculo.CodigoMarca, TablasCatalogos.MARCASVEHICULOS);
            //vehiculo.CodigoMarca = catalogoMarcaVehiculo != null ? catalogoMarcaVehiculo.CodigoInterno :
            //                       throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoMarcaVehiculoNoencontado);

            //var catalogoModeloVehiculo = HomologarCatalogoExternoDAL.Execute(vehiculo.CodigoModelo, TablasCatalogos.MODELOSVEHICULOS);
            //vehiculo.CodigoModelo = catalogoModeloVehiculo != null ? catalogoModeloVehiculo.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoModeloVehiculoNoEncontrado);

            //if (!string.IsNullOrEmpty(vehiculo.CodigoTipoUso))
            //{
            //    var catalogoTipoUso = HomologarCatalogoExternoDAL.Execute(vehiculo.CodigoTipoUso, TablasCatalogos.TIPOSDEUSO);
            //    vehiculo.CodigoTipoUso = catalogoTipoUso != null ? catalogoTipoUso.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoTipoUsoNoEncontrado);
            //}

            //if (vehiculo.DispositivoRastreo != null)
            //{
            //    var dispositivoRastreo = vehiculo.DispositivoRastreo;
            //    var catalogoDispositivoRastreo = HomologarCatalogoExternoDAL.Execute(dispositivoRastreo.CodigoDispositivoRastreo, TablasCatalogos.DISPOSITIVOS_DE_RASTREO);
            //    dispositivoRastreo.CodigoDispositivoRastreo = catalogoDispositivoRastreo != null ? catalogoDispositivoRastreo.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoDispositivoRastreoNoEncontrado);
            //}

            //var catalogoEstadoCivil = HomologarCatalogoExternoDAL.Execute(cliente.CodigoEstadoCivil, TablasCatalogos.ESTADOCIVIL);
            //cliente.CodigoEstadoCivil = catalogoEstadoCivil != null ? catalogoEstadoCivil.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoEstadoCivilNoEncontrado);

            //if (!string.IsNullOrEmpty(cliente.CodigoTipoVivienda))
            //{
            //    var catalogoCodigoTipoVivienda = HomologarCatalogoExternoDAL.Execute(cliente.CodigoTipoVivienda, TablasCatalogos.PROVINCIAS);
            //    cliente.CodigoTipoVivienda = catalogoCodigoTipoVivienda != null ? catalogoCodigoTipoVivienda.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoTipoViviendaNoEncontrado);
            //}

            //var codigoNivelEducacion = HomologarCatalogoExternoDAL.Execute(cliente.CodigoNivelEducacion, TablasCatalogos.NIVELEDUACION);
            //cliente.CodigoNivelEducacion = codigoNivelEducacion != null ? codigoNivelEducacion.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoNivelEducacionNoEncontrado);

            //if (!string.IsNullOrEmpty(cliente.Sexo))
            //{
            //    var codigoSexo = HomologarCatalogoExternoDAL.Execute(cliente.Sexo, TablasCatalogos.SEXO);
            //    cliente.Sexo = codigoSexo != null ? codigoSexo.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoSexoNoEncontrado);
            //}

            //var codigoProvincia = HomologarCatalogoExternoDAL.Execute(cliente.CodigoProvincia, TablasCatalogos.PROVINCIAS);
            //cliente.CodigoProvincia = codigoProvincia != null ? codigoProvincia.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoProvinciaNoEncontrado);

            //var codigoCiudad = HomologarCatalogoExternoDAL.Execute(cliente.CodigoCiudad, TablasCatalogos.CIUDADES);
            //cliente.CodigoCiudad = codigoCiudad != null ? codigoCiudad.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoCiudadNoEncontrado);

            //var codigoOcupacion = HomologarCatalogoExternoDAL.Execute(cliente.CodigoOcupacion, TablasCatalogos.OCUPACION);
            //cliente.CodigoOcupacion = codigoOcupacion != null ? codigoOcupacion.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoOcupacionNoEncontrado);

            //var codigoClasificacionCargo = HomologarCatalogoExternoDAL.Execute(cliente.CodigoClasificacionCargo, TablasCatalogos.CLASIFICACIONCARGO);
            //cliente.CodigoClasificacionCargo = codigoClasificacionCargo != null ? codigoClasificacionCargo.CodigoInterno :
            //                          throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoClasificacionCargoNoEncontrado);

            //if (solicitud.Aseguradora != null)
            //{
            //    var codigoAseguradora = HomologarCatalogoExternoDAL.Execute(solicitud.Aseguradora.CodigoAseguradora, TablasCatalogos.ASEGURADORAS);
            //    solicitud.Aseguradora.CodigoAseguradora = codigoAseguradora != null ? codigoAseguradora.CodigoInterno :
            //                        throw new ExcepcionServicio((int)ErrorHomologacionCodigoExterno.CodigoAseguradoraNoEncontrado);
            //}
        }
    }
}

