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
        ErrorCampoObligatorio = 30512,
        SolicitudNoEncontrada = 30506,
        UsuarioNoActivo = 30507,
        ErrorComunicacion = 30515,
        RegistroDuplicado = 30516
    }

    /// <summary>
    /// Enumeradores para errores de usuario, usar apartir del 30600
    /// </summary>
    public enum ErrorUsuarios
    {
        UsuarioNoEncontrado = 30604
    }

    /// <summary>
    /// enumaradores para cambio de estados de solicitud de crédito
    /// </summary>
    public enum CodigosCambioEstadoSolicitudCredito
    {
        CambioDeEstadoNoPermitido = 30513
    }

    /// <summary>
    /// Códigos solicitud
    /// </summary>
    public enum CodigosSolicitudCredito
    {
        OK = 10000,
        Error = 30404,
        ErrorControlado = 30405
    }

    /// <summary>
    /// Tipo de parametros evaluación
    /// </summary>
    public enum TipoDatoParametroEvaluacion
    {
        NUMERICO,
        ALFANUMERICO
    }
}
