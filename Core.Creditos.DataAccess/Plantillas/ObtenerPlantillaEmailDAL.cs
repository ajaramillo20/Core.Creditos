using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad.HistorialSolicitudCreditos;
using Core.Creditos.Model.Entidad.Plantilla;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Creditos.DataAccess.HistorialSolicitud.ObtenerHistorialSolicitudCreditoDAL;

namespace Core.Creditos.DataAccess.Plantillas
{
    public static class ObtenerPlantillaEmailDAL
    {
        public static Plantilla Execute(string codigoPlantilla)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_PLANTILLA_EMAIL.PARAM_CODIGO_PLANTILLA, codigoPlantilla, System.Data.DbType.String);

            var result = coneccion.ObtenerListaDatos<ObtenerPlantillaEmailResult>(ConstantesPA.PA_CRE_OBTENER_PLANTILLA_EMAIL.PA_NOMBRE, dynamicParameters);
            return AutoMapperHelper.MapeoDinamicoSimpleAutoMapper<Plantilla, ObtenerPlantillaEmailResult>(result.FirstOrDefault());
        }        
    }

    public class ObtenerPlantillaEmailResult
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
    }

}
