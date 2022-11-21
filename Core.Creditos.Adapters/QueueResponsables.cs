using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Core.Creditos.DataAccess.Usuarios;
using Core.Creditos.Model.Entidad.Usuarios;
using Core.Creditos.Model.Entidad.Roles;
using Core.Common.Model.ExcepcionServicio;
using Core.Creditos.Model.General;
using Core.Creditos.DataAccess.Parametrizacion;
using Core.Creditos.Adapters.Core.Originarsa;
using Core.Creditos.DataAccess.Catalogos;
using Core.Common.Util.Helper.Datos;

namespace Core.Creditos.Adapters
{
    public static class QueueResponsables
    {
        public static string CODIGO_ROL_COLA_ANALISTA { get; set; } = "";
        private static string CODIGO_ROL_COLA_EJECUTIVO { get; set; } = "";
        private static List<Usuario> QueueUsuarios { get; set; }
        public static void StartQueueService()
        {
            CODIGO_ROL_COLA_ANALISTA = ObtenerParametrizacionCreditosDAL.Execute(DataAccess.General.ParametrizacionCreditos.CODIGO_ROL_COLA_ANALISTAS).Valor;
            CODIGO_ROL_COLA_EJECUTIVO = ObtenerParametrizacionCreditosDAL.Execute(DataAccess.General.ParametrizacionCreditos.CODIGO_ROL_COLA_EJECUTIVOS).Valor;

            if (string.IsNullOrEmpty(CODIGO_ROL_COLA_ANALISTA) || string.IsNullOrEmpty(CODIGO_ROL_COLA_EJECUTIVO))
            {
                throw new Exception("Verificar parametrización (cola de asignación)");
            }

            QueueUsuarios = new List<Usuario>();
        }
        public static void ObtenerListaUsuarios()
        {

            var usuariosCola = ObtenerColaUsuariosDAL.Execute();
            var ListaUsuarios = ObtenerUsuariosDAL.Execute();

            if (usuariosCola.Count > 0)
            {
                ListaUsuarios = ListaUsuarios.Where(w => usuariosCola.Any(a => a.NombreRed == w.UsuarioNombreRed)).ToList();
            }

            ListaUsuarios = ListaUsuarios.Where(w => w.UsuarioActivo).ToList();
            ListaUsuarios = ListaUsuarios.Where(w => w.Roles.Any(a => a.RolCodigo == CODIGO_ROL_COLA_EJECUTIVO) ||
                                                                      w.Roles.Any(a => a.RolCodigo == CODIGO_ROL_COLA_ANALISTA)).ToList();

            AgregarColaUsuariosDAL.Execute(ListaUsuarios);

            ListaUsuarios.ForEach(w => QueueUsuarios.Add(w));
        }
        public static Usuario GetResponsableEnCola(string codigoRol, string? codigoConcesionario)
        {
            if (QueueUsuarios.Count == 0)
            {
                ObtenerListaUsuarios();
            }

            if (codigoRol == CODIGO_ROL_COLA_ANALISTA)
            {
                return ObtenerAnalistaEnCola(codigoRol);
            }

            if (codigoRol == CODIGO_ROL_COLA_EJECUTIVO)
            {
                return ObtenerEjecutivoEnCola(codigoRol, codigoConcesionario);
            }

            return null;
        }
        private static Usuario ObtenerEjecutivoEnCola(string codigoRol, string? codigoConcesionario)
        {
            if (string.IsNullOrEmpty(codigoConcesionario))
            {
                throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorCampoObligatorio, "CodigoConcesionario");
            }

            var informacionCatalogo = ObtenerInformacionCatalogoDAL.Execute(codigoConcesionario);
            var concesionarios = CoreOriginarsaADP.ObtenerConcesionarios();
            var usuariosEjecutivos = CoreOriginarsaADP.ObtenerUsuarios();
            var usuariosConcesionarios = CoreOriginarsaADP.ObtenerUsuariosConcesionarios();

            var concesionarioDestino = concesionarios.FirstOrDefault(f => f.Id.ToString() == informacionCatalogo.Valor);

            if (concesionarioDestino != null)
            {
                //1. Obtener Ejecutivos en Cola
                var EjecutivosCola = QueueUsuarios.Where(w => w.Roles.Any(a => a.RolCodigo == CODIGO_ROL_COLA_EJECUTIVO));

                //2. ObtenerInformacion de los ejecutivos en Cola 
                var informacionEjecutivos = usuariosEjecutivos.Where(w => EjecutivosCola.Any(a => a.UsuarioNombreRed == w.UsuarioRed));

                //3. Obtener Relación
                var usuarioConcesionarioDestino = usuariosConcesionarios.FirstOrDefault(f => f.ConcesionarioId == concesionarioDestino.Id && informacionEjecutivos.Any(a => a.Id == f.UsuarioId));


                if (usuarioConcesionarioDestino == null)
                {
                    throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorCampoObligatorio, $"No existe un ejecutivo para el concesionario {concesionarioDestino.ToJson()}");
                }

                //4. Obtiene el responsable
                var usuarioResponsable = informacionEjecutivos.FirstOrDefault(w => w.Id == usuarioConcesionarioDestino.UsuarioId);

                if (usuarioResponsable == null)
                {
                    throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorCampoObligatorio, $"No se encuentra en cola el ejecutivo {usuarioConcesionarioDestino.UsuarioId}");
                }

                return QueueUsuarios.First(f => f.UsuarioNombreRed == usuarioResponsable.UsuarioRed);
            }

            throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorHomologacionCodigo, codigoConcesionario);
        }
        private static Usuario ObtenerAnalistaEnCola(string codigoRol)
        {
            var usuario = (Usuario)QueueUsuarios.FirstOrDefault(f => f.Roles.Any(a => a.RolCodigo == codigoRol));
            if (usuario != null)
            {
                QueueUsuarios.Remove(usuario);
                EliminarColaUsuarioDAL.Execute(usuario.UsuarioNombreRed,codigoRol);
            }

            if (usuario == null)
            {
                ValidarExisteUsuarioRol(codigoRol);
                return ObtenerAnalistaEnCola(codigoRol);
            }

            return usuario;
        }
        private static void ValidarExisteUsuarioRol(string codigoRol)
        {
            var ListaUsuarios = ObtenerUsuariosDAL.Execute();

            ListaUsuarios = ListaUsuarios.Where(w => w.Roles.Any(a => a.RolCodigo == codigoRol) && w.UsuarioActivo).ToList();
            if (ListaUsuarios.Count == 0)
            {
                throw new ExcepcionServicio((int)ErrorUsuarios.UsuarioNoEncontrado);
            }
            ListaUsuarios.ForEach(w => QueueUsuarios.Add(w));
        }
        public static void ActualizarUsuarioLista(int usuarioId, bool activar)
        {
            if (!activar)
            {
                var usr = QueueUsuarios.FirstOrDefault(f => f.UsuarioBPMId == usuarioId);
                if (usr != null)
                {
                    QueueUsuarios.Remove(usr);
                    EliminarColaUsuarioDAL.Execute(usr.UsuarioNombreRed, usr.Roles[0].RolCodigo);
                }
            }
            else
            {
                var usuario = ObtenerUsuariosDAL.Execute().FirstOrDefault(f => f.UsuarioBPMId == usuarioId);
                if (usuario != null)
                {
                    QueueUsuarios.Add(usuario);
                    AgregarColaUsuariosDAL.Execute(new List<Usuario> { usuario });
                }

            }
        }
    }
}

