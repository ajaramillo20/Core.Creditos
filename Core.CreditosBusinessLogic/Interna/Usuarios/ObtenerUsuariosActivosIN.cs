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
    public class ObtenerUsuariosActivosIN : IObtenerTodos<UsuarioTrx, ObtenerUsuariosActivosResponse>
    {
        public void AgregarInformacion(UsuarioTrx objetoTransaccional)
        {
            UsuarioAgregarInformacionBLL.ObtenerListaDeUsuariosActivos(objetoTransaccional);
        }

        public void ValidarInformacion(UsuarioTrx objetoTransaccional)
        {
            //throw new NotImplementedException();
        }
    }
}
