using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Adapters;
using Core.Creditos.Model.Transaccion.Response.Usuarios;
using Core.Creditos.Model.Transaccion.Transaccional.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.Usuarios
{
    public class CambiarEstadoUsuarioResponseIN : IActualizar<UsuarioTrx, CambiarEstadoUsuarioResponse>
    {
        public void ActualizarInformacion(UsuarioTrx objetoTransaccional)
        {
            ActualizarInformacionUsuarioBLL.ActualizarEstadoUsuario(objetoTransaccional);
            QueueResponsables.ActualizarUsuarioLista(objetoTransaccional.InformacionUsuario.UsuarioBPMId, objetoTransaccional.InformacionUsuario.UsuarioActivo);
        }

        public void AgregarInformacion(UsuarioTrx objetoTransaccional)
        {
            
        }

        public void HomologarInformacion(UsuarioTrx objetoTransaccional)
        {
            
        }

        public void ValidarInformacion(UsuarioTrx objetoTransaccional)
        {
            
        }
    }
}
