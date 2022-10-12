using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Creditos.DataAccess.Catalogos.HomologarCatalogoExternoDAL;

namespace Core.Creditos.DataAccess.SolicitudCreditos
{
    public static class ObtenerSolicitudCreditoPorNumeroDAL
    {
        public static ObtenerSolicitudCreditoPorNumeroResult Execute(string numeroSolicitud)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("LocalCon"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTNER_SOLICITUD_CREDITO.PARAM_NUMERO_SOLICITUD_CREDITO, numeroSolicitud, System.Data.DbType.String);

            var resultado = coneccion.ObtenerListaDatos<ObtenerSolicitudCreditoPorNumeroResult>(ConstantesPA.PA_CRE_OBTNER_SOLICITUD_CREDITO.PA_NOMBRE, dynamicParameters);
            return resultado.FirstOrDefault();
        }
    }

    public class ObtenerSolicitudCreditoPorNumeroResult
    {
        public int NumeroSolicitud { get; set; }
        public DateTime FechaProceso { get; set; }
        public string CodigoCredencial { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
        public string EstadoCodigo { get; set; }        
    }
}
