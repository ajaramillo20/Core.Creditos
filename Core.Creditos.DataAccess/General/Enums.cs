using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.DataAccess.General
{
    public enum TablasCatalogos
    {
        ASEGURADORAS = 1001,
        DISPOSITIVOS_DE_RASTREO = 1002,
        PROVINCIAS = 1003,
        NACIONALIDADES = 1004,
        MARCASVEHICULOS = 1005,
        MODELOSVEHICULOS = 1006,
        TIPOSDEUSO = 1007,
        ESTADOCIVIL = 1008,
        NIVELEDUACION = 1009,
        SEXO = 1010,
        CIUDADES = 1011,
        OCUPACION = 1012,
        CONCESIONARIOS = 1013,
        CLASIFICACIONCARGO = 1014
    }

    public enum ParametrizacionCreditos
    {        
        ANALIS_RAPIDO_ESTADO_PRE_APROBADO,
        ANALIS_RAPIDO_ESTADO_NEGADO,
        CODIGO_ROL_COLA_ANALISTAS,
        CODIGO_ROL_COLA_EJECUTIVOS,
        PLANTILLA_ENVIO_SOLICITUD_CREDITO,
        RUTA_ARCHIVOS_TEMPORALES
    }
}
