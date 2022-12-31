using Core.Common.ProcessTemplate.InternalBusinessLogic;
using Core.Creditos.Model.Transaccion.Response.Usuarios;
using Core.Creditos.Model.Transaccion.Transaccional.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.Usuarios
{
    public class AgregarUsuarioIN : IInsertar<UsuarioTrx, UsuarioResponse>
    {
        public void AgregarInformacion(UsuarioTrx objetoTransaccional)
        {
            
        }

        public void HomologarInformacion(UsuarioTrx objetoTransaccional)
        {
            
        }

        public void InsertarInformacion(UsuarioTrx objetoTransaccional)
        {
            UsuarioInsertarInformacionBLL.Insertar(
                            objetoTransaccional.InformacionUsuario.UsuarioNombre,
                            objetoTransaccional.InformacionUsuario.UsuarioNombreRed,
                            objetoTransaccional.CodigosRoles);
        }

        public void ValidarInformacion(UsuarioTrx objetoTransaccional)
        {
            
        }
    }
}
