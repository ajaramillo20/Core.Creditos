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
    public class ObtenerInformacionUsuarioIN : IObtener<UsuarioTrx, ObtenerInformacionUsuarioResponse>
    {
        public void AgregarInformacion(UsuarioTrx objetoTransaccional)
        {
            UsuarioAgregarInformacionBLL.ObtenerInformacionUsuario(objetoTransaccional);
        }

        public void ValidarInformacion(UsuarioTrx objetoTransaccional)
        {
            
        }
    }
}
