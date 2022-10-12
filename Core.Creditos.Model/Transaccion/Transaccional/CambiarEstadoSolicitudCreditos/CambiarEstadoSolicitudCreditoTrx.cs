﻿using Core.Common.Model.Transaccion;
using Core.Creditos.Model.Entidad.SolicitudCreditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Model.Transaccion.Transaccional.CambiarEstadoSolicitudCreditos
{
    public class CambiarEstadoSolicitudCreditoTrx : TransaccionBase
    {
        public string NumeroSolicitudCredito { get; set; }
        public string CredencialCodigoSolicitudCredito { get; set; }        
        public int IdEstadoSolicitudCredito { get; set; }
        public string NombreEstadoSolicitud { get; set; }
        public string CodigoEstadoSolicitudCredito { get; set; }
        public DateTime FechaProcesoSolicitud { get; set; }

        public int IdEstadoSolicitudCreditoDestino { get; set; }
        public string NombreEstadoSolicitudCreditoDestino { get; set; }
        public string CodigoEstadoSolicitudCreditoDestino { get; set; }
    }
}
