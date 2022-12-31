using Core.Creditos.DataAccess.EstadoSolicitudCreditos;
using Core.Creditos.Model.Entidad.EstadoCredito;
using Core.Creditos.Model.Transaccion.Transaccional.EstadosCreditos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.CreditosBusinessLogic.Ejecucion.EstadoSolicitudCreditos
{
    public static class EstadoCreditoAgregarInformacionBLL
    {
        /// <summary>
        /// Busca por el Id
        /// </summary>
        /// <param name="objetoTransaccional"></param>
        public static void ObtenerEstadoCredito(EstadoCreditoTrx objetoTransaccional)
        {
            var estado = ObtenerEstadoSolicitudCreditoDAL.Execute(objetoTransaccional.EstadoCredito.Id).First();

            objetoTransaccional.EstadoCredito.Nombre = estado.NombreEstado;
            objetoTransaccional.EstadoCredito.Codigo = estado.CodigoEstado;
        }

        /// <summary>
        /// Busca por el código del estado
        /// </summary>
        /// <param name="codigoEstado"></param>
        public static EstadoCredito ObtenerEstadoCredito(string codigoEstado="", int? idEstado=null)
        {
            var estado = ObtenerEstadoSolicitudCreditoDAL.Execute( idEstado:idEstado ,codigoEstado:codigoEstado).FirstOrDefault();
            if (estado!=null)
            {
                return new EstadoCredito
                {
                    Id = estado.IdEstado,
                    Codigo = estado.CodigoEstado,
                    Nombre = estado.NombreEstado,
                    RequiereComentario = estado.RequiereComentario,
                    RequiereEnvioEmail = estado.RequiereEnvioEmail
                };
            }
            return null;
        }

        /// <summary>
        /// Obtener Lista Estados 
        /// </summary>
        /// <param name="codigoEstado"></param>
        /// <param name="idEstado"></param>
        /// <returns></returns>
        public static List<EstadoCredito> ObtenerEstadoCreditoList(string codigoEstado = "", int? idEstado = null)
        {
            var estado = ObtenerEstadoSolicitudCreditoDAL.Execute(idEstado: idEstado, codigoEstado: codigoEstado);

            return (from est in estado
                    select new EstadoCredito
                    {
                        Id = est.IdEstado,
                        Codigo = est.CodigoEstado,
                        Nombre = est.NombreEstado,
                        RequiereComentario = est.RequiereComentario,
                        RequiereEnvioEmail = est.RequiereEnvioEmail
                    }).ToList();            
        }

        internal static void ObtenerFlujoEstadoCredito(EstadoCreditoTrx objetoTransaccional)
        {
            var flujos = ObtenerFlujoEstadoCreditoDAL.Execute(objetoTransaccional.EstadoCredito.Id);
            flujos.ForEach(f => objetoTransaccional.FlujosEstadoCredito.Add(new EstadoCredito
            {
                Id = f.EstadoId,
                Nombre = f.EstadoNombre,
                Codigo = f.EstadoCodigo,
            }));
        }
    }
}
