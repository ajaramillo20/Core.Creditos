using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Model.Transaccion.Response.Usuarios;
using Core.Creditos.Model.Transaccion.Transaccional.Usuarios;
using Core.CreditosBusinessLogic.Ejecucion.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.Usuarios
{
    public class ActualizarUsuarioCreditManagerIN : IActualizar<UsuarioTrx, UsuarioResponse>
    {
        public void ActualizarInformacion(UsuarioTrx objetoTransaccional)
        {
            UsuarioActualizarInformacionBLL.Actualizar(objetoTransaccional.InformacionUsuario.UsuarioNombreRed, objetoTransaccional.InformacionUsuario.UsuarioNombre, objetoTransaccional.CodigosRoles);
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
