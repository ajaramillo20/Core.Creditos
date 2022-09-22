using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.General
{
    /// <summary>
    /// Enumeradore para codigos de error
    /// </summary>
    public enum ErroresSolicitudCredito
    {
        FormatoIncorrectoResponse = 30010,
        NoExisteCodigoHomologacion = 30011,
        DeudorNoCumplePoliticaEdad = 30012,
        DeudorNoCumplePoliticaIngresos = 30013,
        PoliticaIngresosNoDefinida = 30014,
        PoliticaEdadNoDefinida = 30015,
        ErrorValidarEdadBaseDeDatos = 30404,
        ErrorValidarIngresosBaseDeDatos = 30405
    }

    public enum ErrorHomologacionCodigoExterno
    { 
      CodigoNacionalidadNoEncontrado = 30500,
      CodigoMarcaVehiculoNoencontado = 30501,
      CodigoModeloVehiculoNoEncontrado = 30502,
      CodigoTipoUsoNoEncontrado = 30503,
      CodigoDispositivoRastreoNoEncontrado = 30504,
      CodigoEstadoCivilNoEncontrado = 30505,
      CodigoTipoViviendaNoEncontrado = 30506,
      CodigoNivelEducacionNoEncontrado = 30507,
      CodigoSexoNoEncontrado = 30508,
      CodigoProvinciaNoEncontrado = 30509,
      CodigoCiudadNoEncontrado = 30510,
      CodigoOcupacionNoEncontrado = 30511,
      CodigoClasificacionCargoNoEncontrado = 30512,
      CodigoAseguradoraNoEncontrado = 30513,
      CodigoConcesionarioNoEncontrado = 30514,    
      CodigoTipoPersona = 30515
    }
    
    public enum CodigosSolicitudCredito
    {
        OK = 10000
    }
}
