using Core.Creditos.DataAccess.Usuarios;
using Core.Creditos.Model.Transaccion.Transaccional.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CreditosBusinessLogic.Interna.Usuarios
{
    public static  class ActualizarInformacionUsuarioBLL
    {
        public static void ActualizarEstadoUsuario(UsuarioTrx objetoTransaccional)
        {
            objetoTransaccional.Respuesta.CodigoInternoRespuesta = ActualizarEstadoUsuarioDAL.Execute(objetoTransaccional.InformacionUsuario.UsuarioBPMId,objetoTransaccional.InformacionUsuario.UsuarioActivo);
        }

    }
}
