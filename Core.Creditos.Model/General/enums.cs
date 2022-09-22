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
        ErrorValidarIngresosBaseDeDatos = 30405,
        ErrorHomologacionCodigo = 30511,
        ErrorCampoObligatorio = 30512
    }   
    
    public enum CodigosSolicitudCredito
    {
        OK = 10000
    }
}
