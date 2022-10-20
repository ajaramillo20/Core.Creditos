using Core.Common.Util.Helper.API;
using Core.Common.Util.Helper.Internal;
using Core.Creditos.DataAccess.Usuarios;
using Core.Creditos.Model.Entidad.Usuarios;
using Core.Creditos.Model.Transaccion.Transaccional.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.CreditosBusinessLogic.Ejecucion.Usuarios
{
    public static class UsuarioAgregarInformacionBLL
    {
        internal static void ObtenerListaDeUsuariosActivos(UsuarioTrx objetoTransaccional)
        {
            var usuariosActivos = ObtenerUsuariosActivosDAL.Execute();
            objetoTransaccional.Usuarios = AutoMapperHelper.MapeoDinamicoListasAutoMapper<Usuario, ObtenerUsuariosActivosDAL.ObtenerUsuariosActivosResult>(usuariosActivos.ToList());
        }
    }
}
