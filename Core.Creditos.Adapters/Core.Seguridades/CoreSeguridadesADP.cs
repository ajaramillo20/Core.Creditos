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
    /// <summary>
    /// Clase para conectar micro servicio core.seguridades
    /// </summary>
    public static class CoreSeguridadesADP
    {       
        /// <summary>
        /// Obtiene información microservicio core.seguridades
        /// </summary>
        /// <param name="usuarioRed"></param>
        /// <returns></returns>
        public static Task<InformacionBase> ObtenerInformacionBaseUsuario(string usuarioRed)
        {
            return HttpClientHelper.Post<InformacionBase>("CoreSeguridades", "/api/Usuarios/ObtenerUsuario", usuarioRed, "data.usuarioPerfil");
        }               
    }
}
