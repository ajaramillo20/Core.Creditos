﻿using Core.Common.DataAccess.Helper;
using Core.Common.Util.Helper.API;
using Core.Common.Util.Helper.Internal;
using Core.Creditos.DataAccess.General;
using Core.Creditos.Model.Entidad;
using Core.Creditos.Model.Entidad.Catalogos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Creditos.DataAccess.Catalogos.HomologarCatalogoExternoDAL;

namespace Core.Creditos.DataAccess.Catalogos
{
    public static class ObtenerInformacionCatalogoDAL
    {
        /// <summary>
        /// sp para obtener inforamcion de un catalogo
        /// </summary>
        /// <param name="codigoCatalogo"></param>
        /// <returns></returns>
        public static Catalogo Execute(string codigoCatalogo)
        {
            DBConnectionHelper coneccion = new DBConnectionHelper(Common.Model.General.EnumDBConnection.SqlConnection, SettingsHelper.ObtenerConnectionString("BD_CREDITOS"));
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add(ConstantesPA.PA_CRE_OBTENER_INFORMACION_CATALOGOS.PARAM_CODIGO_CATALOGO, codigoCatalogo, System.Data.DbType.String);

            var resultado = coneccion.ObtenerListaDatos<ObtenerInformacionCatalogoResult>(ConstantesPA.PA_CRE_OBTENER_INFORMACION_CATALOGOS.PA_NOMBRE, dynamicParameters);
            var catalogo = resultado.FirstOrDefault();

            if (catalogo!=null)
            {
                return new Catalogo()
                {
                    CodigoCatalogo = catalogo.Codigo,
                    CodigoTabla = catalogo.Tablacodigo,
                    DescripcionCatalogo = catalogo.Descripcion,
                    NombreCatalogo = catalogo.Nombre,
                    ValorCatalogo = catalogo.Valor,                    
                };
            }
            return null;
        }

        public class ObtenerInformacionCatalogoResult
        {
            public string Codigo { get; set; }
            public string Tablacodigo { get; set; }
            public string Valor { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
        }
    }
}
