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
        PoliticaIngresosNoDefinida = 30014,
        PoliticaEdadNoDefinida = 30015,
        ErrorValidarEdadBaseDeDatos = 30404,
        ErrorValidarIngresosBaseDeDatos = 30405,
        ErrorHomologacionCodigo = 30511,
        ErrorCampoObligatorio = 30512
    }

    /// <summary>
    /// enumaradores para cambio de estados de solicitud de crédito
    /// </summary>
    public enum CodigosCambioEstadoSolicitudCredito
    {
        CambioDeEstadoNoPermitido = 30513
    }

    /// <summary>
    /// 
    /// </summary>
    public enum CodigosSolicitudCredito
    {
        OK = 10000
    }

    public enum TipoDatoParametroEvaluacion
    {
        NUMERICO,
        ALFANUMERICO
    }
}
