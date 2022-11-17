using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Creditos.Adapters.Api.Aval
{
    public class ResultadoBuro
    {
        public string time { get; set; }
        public string responseCode { get; set; }
        public string message { get; set; }
        public string transactionNumber { get; set; }
        public Result result { get; set; }
    }

    public class AnalisisCreditosAprobadosReguladoMy
    {
        public int MCAMontoOriginal { get; set; }
        public object MCAFecConcesion { get; set; }
        public int CMRMontoOriginal { get; set; }
        public object CMRFecConcesion { get; set; }
        public int CMAMontoOriginal { get; set; }
        public object CMAFecConcesion { get; set; }
        public int MMRMontoMora { get; set; }
        public object MMRFecMora { get; set; }
        public int MMAMontoMora { get; set; }
        public object MMAFecMora { get; set; }
        public int MMVMontoMora { get; set; }
        public object MMVFecMora { get; set; }
        public int PCTotalAdeudado { get; set; }
        public int PCNumIfisActuales { get; set; }
        public int PCNumOperacionesVencidas { get; set; }
        public int PCMontoOperacionesVencidas { get; set; }
        public int PCPorcentajeDeudaVencida { get; set; }
        public int RECACreditosAprobados { get; set; }
        public int RECAValCreditosAprobados { get; set; }
        public int RECAcreditosCancelados { get; set; }
        public int RECAvalCreditosCancelados { get; set; }
        public int RECASaldosVigentes { get; set; }
        public int RECAValSaldosVigentes { get; set; }
        public int RECAcreditosCastigados { get; set; }
        public int RECAvalCreditosCastigados { get; set; }
        public int TDeudaHace3Meses { get; set; }
        public int TDeudaActual { get; set; }
        public int TVariacion { get; set; }
        public int TPorcentaje { get; set; }
    }

    public class AnalisisCreditoSectorFinanciero
    {
        public int MCAMontoOriginal { get; set; }
        public object MCAFecConcesion { get; set; }
        public int CMRMontoOriginal { get; set; }
        public object CMRFecConcesion { get; set; }
        public int CMAMontoOriginal { get; set; }
        public object CMAFecConcesion { get; set; }
        public int MMRMontoMora { get; set; }
        public object MMRFecMora { get; set; }
        public int MMAMontoMora { get; set; }
        public object MMAFecMora { get; set; }
        public int MMVMontoMora { get; set; }
        public object MMVFecMora { get; set; }
        public string CMACODIGO { get; set; }
        public string CMAAENTIDAD { get; set; }
        public string CMAAFecha { get; set; }
        public int CMAADeudaTotal { get; set; }
        public string CMBCODIGO { get; set; }
        public string CMBEEntidad { get; set; }
        public string CMBEFecha { get; set; }
        public int CMBEDeudaTotal { get; set; }
        public int PCTotalAdeudado { get; set; }
        public int PCNumIfisActuales { get; set; }
        public int PCNumOperacionesVencidas { get; set; }
        public int PCMontoOperacionesVencidas { get; set; }
        public int PCPorcentajeDeudaVencida { get; set; }
        public int RECACreditosAprobados { get; set; }
        public int RECAValCreditosAprobados { get; set; }
        public int RECAcreditosCancelados { get; set; }
        public int RECAvalCreditosCancelados { get; set; }
        public int RECASaldosVigentes { get; set; }
        public int RECAValSaldosVigentes { get; set; }
        public int RECAcreditosCastigados { get; set; }
        public int RECAvalCreditosCastigados { get; set; }
        public int TDeudaHace3Meses { get; set; }
        public int TDeudaActual { get; set; }
        public int TVariacion { get; set; }
        public int TPorcentaje { get; set; }
    }

    public class AnalisisMontosSectorComercial
    {
        public int MCAMontoOriginal { get; set; }
        public object MCAFecConcesion { get; set; }
        public int CMRMontoOriginal { get; set; }
        public object CMRFecConcesion { get; set; }
        public int CMAMontoOriginal { get; set; }
        public object CMAFecConcesion { get; set; }
        public int MMRMontoMora { get; set; }
        public object MMRFecMora { get; set; }
        public int MMAMontoMora { get; set; }
        public object MMAFecMora { get; set; }
        public int MMVMontoMora { get; set; }
        public object MMVFecMora { get; set; }
        public int PCTotalAdeudado { get; set; }
        public int PCNumIfisActuales { get; set; }
        public int PCNumOperacionesVencidas { get; set; }
        public int PCMontoOperacionesVencidas { get; set; }
        public int PCPorcentajeDeudaVencida { get; set; }
        public int RECACreditosAprobados { get; set; }
        public int RECAValCreditosAprobados { get; set; }
        public int RECAcreditosCancelados { get; set; }
        public int RECAvalCreditosCancelados { get; set; }
        public int RECASaldosVigentes { get; set; }
        public int RECAValSaldosVigentes { get; set; }
        public int RECAcreditosCastigados { get; set; }
        public int RECAvalCreditosCastigados { get; set; }
        public int TDeudaHace3Meses { get; set; }
        public int TDeudaActual { get; set; }
        public int TVariacion { get; set; }
        public int TPorcentaje { get; set; }
    }

    public class CuotaEstimadaMensual
    {
        public int Pago { get; set; }
        public string NumeroCreditosComercial { get; set; }
        public int TotalVencido { get; set; }
        public int TotalDemanda { get; set; }
        public int TotalCartera { get; set; }
        public string NumeroCreditosIece { get; set; }
        public int NumeroOperacionesExcluidas { get; set; }
    }

    public class DeudaRefinanciadaInfocom
    {
        public string Institucion { get; set; }
        public string Fecha { get; set; }
        public string Observacion { get; set; }
    }

    public class DeudaReportadaPorSeguridadSocial
    {
        public string Institucion { get; set; }
        public string FechaCorte { get; set; }
        public string TipoDeudor { get; set; }
        public string TipoCredito { get; set; }
        public int CupoMontoOriginal { get; set; }
        public string FechaApertura { get; set; }
        public string FechaVencimiento { get; set; }
        public string CausalVinculacion { get; set; }
        public string Calificacion { get; set; }
        public string CalificacionHomologada { get; set; }
        public int TotalVencer { get; set; }
        public int NoDevengaInt { get; set; }
        public int TotalVencido { get; set; }
        public int DemandaJudicial { get; set; }
        public int CarteraCastigada { get; set; }
        public int SaldoDeuda { get; set; }
        public string AcuerdoConcordato { get; set; }
        public int CuotaMensual { get; set; }
    }

    public class EntidadesQueHanConsultado
    {
        public string NombreCliente { get; set; }
        public string Mes1 { get; set; }
        public string Mes2 { get; set; }
        public string Mes3 { get; set; }
        public string Mes4 { get; set; }
        public string Mes5 { get; set; }
        public string Mes6 { get; set; }
        public string Mes7 { get; set; }
        public string Mes8 { get; set; }
        public string Mes9 { get; set; }
        public string Mes10 { get; set; }
        public string Mes11 { get; set; }
        public string Mes12 { get; set; }
        public string ResaltadaInv { get; set; }
    }

    public class IdentificacionConsultadum
    {
        public string NombreSujeto { get; set; }
        public string TipoDocumentoDobleInfo { get; set; }
        public string NumeroDocumentoDobleInfo { get; set; }
    }

    public class InformacionBiessHistorium
    {
        public string TipoDeudaParam { get; set; }
        public int MesesAtrasParam { get; set; }
    }

    public class InformacionSbsBiess
    {
        public string NoOperacion { get; set; }
        public string Acreedor { get; set; }
        public string FechaDeCorte { get; set; }
        public string TipoDeudor { get; set; }
        public string TipoCredito { get; set; }
        public int SaldoDeuda { get; set; }
        public int ValorPorVencer { get; set; }
        public int ValorVencido { get; set; }
        public int VencidoCuotaVigente { get; set; }
    }

    public class MensajeValorComprometido
    {
        [JsonPropertyName("MensajeValorComprometido")]
        public string MensajeValorComprometidoResult { get; set; }
        public string MensajeAnalisisCapacidadPago { get; set; }
    }

    public class OfertaSugeridum
    {
        public string Detalle { get; set; }
        public int MontoSugerido { get; set; }
        public int CuotaMensual { get; set; }
        public int Plazo { get; set; }
    }

    public class ParametrizadorGenerico
    {
        public int puntaje { get; set; }
        public string decision { get; set; }
        public string rutas { get; set; }
    }

    public class Result
    {
        public List<IdentificacionConsultadum> IdentificacionConsultada { get; set; }
        public List<ResultadoSegmentacion> ResultadoSegmentacion { get; set; }
        public List<OfertaSugeridum> OfertaSugerida { get; set; }
        public List<MensajeValorComprometido> MensajeValorComprometido { get; set; }
        public List<ResultadoPolitica> ResultadoPoliticas { get; set; }
        public List<object> PersonasInhabilitadas { get; set; }
        public List<object> ScorePuntajeYGraficoV3 { get; set; }
        public List<ParametrizadorGenerico> ParametrizadorGenerico { get; set; }
        public List<object> PuntajeGraficoIndexPymes { get; set; }
        public List<object> estadoCartera { get; set; }
        public List<ScoreIndicadoresV3> ScoreIndicadoresV3 { get; set; }
        public List<object> DetalleDeudaActualReportadaSICOMSBS { get; set; }
        public List<DeudaRefinanciadaInfocom> DeudaRefinanciadaInfocom { get; set; }
        public List<SujetoAlDiaInfocom> SujetoAlDiaInfocom { get; set; }
        public List<object> EvolucionHistoricaDistEndeudamientoSICOM { get; set; }
        public List<object> DetalleDeudaActualReportadaRFRSBS { get; set; }
        public List<object> EvolucionHistoricaDistEndeudamientoRFR { get; set; }
        public List<DeudaReportadaPorSeguridadSocial> DeudaReportadaPorSeguridadSocial { get; set; }
        public List<InformacionBiessHistorium> InformacionBiessHistoria { get; set; }
        public List<InformacionSbsBiess> InformacionSbsBiess { get; set; }
        public List<object> OperacionesVigentesSCE { get; set; }
        public List<object> DetalleDeudaActualReportadaSBSSBSEducativo { get; set; }
        public List<object> ValorDeudaTotalEnLos3SegmentosSinIess { get; set; }
        public List<CuotaEstimadaMensual> CuotaEstimadaMensual { get; set; }
        public List<object> RecursivoDeudaHistorica { get; set; }
        public List<object> CalificaDetalleTarjetas { get; set; }
        public List<object> MantieneHistorialCrediticioDesdeCG { get; set; }
        public List<object> IdentificadorPerfilRiesgoDirectoUltimos12Meses { get; set; }
        public List<object> IdentificadorPerfilRiesgoDirecto6Meses { get; set; }
        public List<object> DetalleOperacionesVencidas { get; set; }
        public List<object> ComposicionDeudaActual { get; set; }
        public List<object> Ultimas10OperacionesCanceladas { get; set; }
        public List<object> GraficoEvolucionDeudaYVencido { get; set; }
        public List<object> MoraSectorComercial { get; set; }
        public List<object> MoraSectorFinancieroNoRegulado { get; set; }
        public List<object> HabitoPago { get; set; }
        public List<object> ObligacionesAdquiridasSector { get; set; }
        public List<AnalisisCreditoSectorFinanciero> AnalisisCreditoSectorFinanciero { get; set; }
        public List<object> PorcentajeCreditoPorAcreedorSFR { get; set; }
        public List<AnalisisMontosSectorComercial> analisisMontosSectorComercial { get; set; }
        public List<object> PorcentajeCreditoPorAcreedorSICOM { get; set; }
        public List<AnalisisCreditosAprobadosReguladoMy> AnalisisCreditosAprobadosReguladoMIES { get; set; }
        public List<object> PorcentajeCreditoPorAcreedorMIES { get; set; }
        public List<EntidadesQueHanConsultado> EntidadesQueHanConsultado { get; set; }
    }

    public class ResultadoPolitica
    {
        public string PoliticaEvaluada { get; set; }
        public string Valor { get; set; }
        public string Resultado { get; set; }
    }

    public class ResultadoSegmentacion
    {
        public int ResultadoEvaluacion { get; set; }

        [JsonProperty("SegmentacionCliente ")]
        public string SegmentacionCliente { get; set; }
        public string ModeloUtilizado { get; set; }
        public double GastoFinanciero { get; set; }
        public double GastoHogar { get; set; }
        public string ScoreDeudor { get; set; }
        public string ScoreSobreendeudamiento { get; set; }
        public string ScoreSociodemografico { get; set; }
        public string IndexPymes { get; set; }
        public string RangodeIngreso { get; set; }

        [JsonProperty("Monto ")]
        public double Monto { get; set; }

        [JsonProperty("MontoAprobado ")]
        public int MontoAprobado { get; set; }

        [JsonProperty("Plazo ")]
        public double Plazo { get; set; }

        [JsonProperty("Tasa ")]
        public int Tasa { get; set; }

        [JsonProperty("CapacidadPago ")]
        public int CapacidadPago { get; set; }
        public string IngresoValidado { get; set; }
        public double Ingresos { get; set; }
        public string TipoCredito { get; set; }
        public int RestaGastoFinanciero { get; set; }
        public string NivelIngresos { get; set; }
    }
   
    public class ScoreIndicadoresV3
    {
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public double Valor { get; set; }
        public string PintarInv { get; set; }
    }

    public class SujetoAlDiaInfocom
    {
        public string Institucion { get; set; }
        public object Fecha { get; set; }
        public string Mensaje { get; set; }
    }
}
