using Core.Creditos.Adapters.Core.Seguridades.Models;
using Core.Creditos.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Adapters.Core.Seguridades
{
    public static class ObtenerInformacionUsuarioADP
    {       
        public static Task<InformacionBase> ObtenerInformacionBaseUsuario(string usuarioRed)
        {
            return HttpClientHelper.Post<InformacionBase>("CoreSeguridades", "/api/Usuarios/ObtenerUsuario", usuarioRed, "data.usuarioPerfil");
        }               
    }
}
