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
using Core.Creditos.Adapters.Core.Originarsa.Models;

namespace Core.Creditos.Adapters
{
    /// <summary>
    /// Clase encargada de manejar las colas de responsables
    /// </summary>
    public static class QueueResponsables
    {
        public static string CODIGO_ROL_COLA_ANALISTA { get; set; } = "";
        private static string CODIGO_ROL_COLA_EJECUTIVO { get; set; } = "";
        private static List<ObtenerColaUsuariosResult> QueueUsuarios { get; set; } = new List<ObtenerColaUsuariosResult>();

        /// <summary>
        /// Inicia el servicio de cola
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void StartQueueService()
        {
            CODIGO_ROL_COLA_ANALISTA = ObtenerParametrizacionCreditosDAL.Execute(DataAccess.General.ParametrizacionCreditos.CODIGO_ROL_COLA_ANALISTAS).Valor;
            CODIGO_ROL_COLA_EJECUTIVO = ObtenerParametrizacionCreditosDAL.Execute(DataAccess.General.ParametrizacionCreditos.CODIGO_ROL_COLA_EJECUTIVOS).Valor;

            if (string.IsNullOrEmpty(CODIGO_ROL_COLA_ANALISTA) || string.IsNullOrEmpty(CODIGO_ROL_COLA_EJECUTIVO))
            {
                throw new Exception("Verificar parametrización (cola de asignación)");
            }

            ObtenerListaUsuariosCola();
        }

        /// <summary>
        /// Obtiene lista de usuarios desde BD
        /// </summary>
        public static void ObtenerListaUsuariosCola()
        {
            var usuariosCola = ObtenerColaUsuariosDAL.Execute();

            if (usuariosCola.Count == 0)
            {
                var ListaUsuarios = ObtenerUsuariosDAL.Execute();
                ListaUsuarios = ListaUsuarios.Where(w => w.UsuarioActivo).ToList();
                ListaUsuarios = ListaUsuarios.Where(w => w.Roles.Any(a => a.RolCodigo == CODIGO_ROL_COLA_EJECUTIVO) ||
                                                                          w.Roles.Any(a => a.RolCodigo == CODIGO_ROL_COLA_ANALISTA)).ToList();
                AgregarColaUsuariosDAL.Execute(ListaUsuarios);
                usuariosCola = ObtenerColaUsuariosDAL.Execute();
            }

            usuariosCola.ForEach(w => QueueUsuarios.Add(w));
        }

        /// <summary>
        /// OBtiene responsable en cola segun el rol
        /// </summary>
        /// <param name="codigoRol">rol de usuario</param>
        /// <param name="codigoConcesionario">Codigo interno concesionario</param>
        /// <returns></returns>
        public static ObtenerColaUsuariosResult GetResponsableEnCola(string codigoRol, string? codigoConcesionario)
        {
            if (QueueUsuarios.Count == 0)
            {
                ObtenerListaUsuariosCola();
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

        /// <summary>
        /// Obtiene ejecutivo en cola
        /// </summary>
        /// <param name="codigoRol">codigo de rol</param>
        /// <param name="codigoConcesionario">codigo interno concesionario</param>
        /// <returns></returns>
        /// <exception cref="ExcepcionServicio"></exception>
        private static ObtenerColaUsuariosResult ObtenerEjecutivoEnCola(string codigoRol, string? codigoConcesionario)
        {
            if (string.IsNullOrEmpty(codigoConcesionario))
            {
                throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorCampoObligatorio, "CodigoConcesionario");
            }

            var informacionCatalogo = ObtenerInformacionCatalogoDAL.Execute(codigoConcesionario);
            var concesionarios = CoreOriginarsaADP.ObtenerConcesionarios();
            var usuariosEjecutivos = CoreOriginarsaADP.ObtenerUsuarios();
            var usuariosConcesionarios = CoreOriginarsaADP.ObtenerUsuariosConcesionarios();

            var concesionarioDestino = concesionarios.FirstOrDefault(f => f.Id.ToString() == informacionCatalogo.ValorCatalogo);

            if (concesionarioDestino != null)
            {
                //1. Obtener Ejecutivos en Cola
                var EjecutivosCola = QueueUsuarios.Where(w => w.CodigoRol == CODIGO_ROL_COLA_EJECUTIVO);

                //2. ObtenerInformacion de los ejecutivos en Cola 
                var informacionEjecutivos = usuariosEjecutivos.Where(w => EjecutivosCola.Any(a => a.NombreRed == w.UsuarioRed));

                //3. Obtener Relación
                var usuarioConcesionarioDestino = usuariosConcesionarios.FirstOrDefault(f => f.ConcesionarioId == concesionarioDestino.Id && informacionEjecutivos.Any(a => a.Id == f.UsuarioId));


                if (usuarioConcesionarioDestino == null)
                {
                    return ObtenerAnalistaEnCola(CODIGO_ROL_COLA_ANALISTA);
                    //throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorCampoObligatorio, $"No existe un ejecutivo para el concesionario {concesionarioDestino.ToJson()}");                    
                }

                //4. Obtiene el responsable
                var usuarioResponsable = informacionEjecutivos.FirstOrDefault(w => w.Id == usuarioConcesionarioDestino.UsuarioId);

                if (usuarioResponsable == null)
                {
                    return ObtenerAnalistaEnCola(CODIGO_ROL_COLA_ANALISTA);
                    //throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorCampoObligatorio, $"No se encuentra en cola el ejecutivo {usuarioConcesionarioDestino.UsuarioId}");
                }

                return QueueUsuarios.First(f => f.NombreRed == usuarioResponsable.UsuarioRed);
            }

            throw new ExcepcionServicio((int)ErroresSolicitudCredito.ErrorHomologacionCodigo, codigoConcesionario);
        }

        /// <summary>
        /// Obtiene analista en cola
        /// </summary>
        /// <param name="codigoRol">codigo de rol de analista</param>
        /// <returns></returns>
        private static ObtenerColaUsuariosResult ObtenerAnalistaEnCola(string codigoRol)
        {
            var usuario = QueueUsuarios.FirstOrDefault(f => f.CodigoRol == codigoRol);
            if (usuario != null)
            {
                QueueUsuarios.Remove(usuario);
                EliminarColaUsuarioDAL.Execute(usuario.NombreRed, codigoRol);
            }

            if (usuario == null)
            {
                ValidarExisteUsuarioRol(codigoRol);
                return ObtenerAnalistaEnCola(codigoRol);
            }

            return usuario;
        }

        /// <summary>
        /// Verifica si existen usuarios activos con el rol
        /// </summary>
        /// <param name="codigoRol"></param>
        /// <exception cref="ExcepcionServicio"></exception>
        private static void ValidarExisteUsuarioRol(string codigoRol)
        {
            var ListaUsuarios = ObtenerUsuariosDAL.Execute();
            ListaUsuarios = ListaUsuarios.Where(w => w.UsuarioActivo).ToList();
            ListaUsuarios = ListaUsuarios.Where(w => w.Roles.Any(a => a.RolCodigo == codigoRol)).ToList();
            if (ListaUsuarios.Count == 0)
            {
                throw new ExcepcionServicio((int)ErrorUsuarios.UsuarioNoEncontrado);
            }
            else
            {
                AgregarColaUsuariosDAL.Execute(ListaUsuarios);
                var usuariosCola = ObtenerColaUsuariosDAL.Execute();
                QueueUsuarios = new List<ObtenerColaUsuariosResult>();
                usuariosCola.ForEach(w => QueueUsuarios.Add(w));
            }            
        }

        /// <summary>
        /// Actualiza el estado de un usuario en la cola
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <param name="activar"></param>
        public static void ActualizarUsuarioLista(int usuarioId, bool activar)
        {
            if (!activar)
            {
                var usrInfo = ObtenerUsuariosDAL.Execute().FirstOrDefault(f => f.UsuarioBPMId == usuarioId);

                if (usrInfo != null)
                {
                    var usrCola = QueueUsuarios.FirstOrDefault(f => f.NombreRed == usrInfo.UsuarioNombreRed);
                    if (usrCola != null)
                    {
                        QueueUsuarios.Remove(usrCola);
                        EliminarColaUsuarioDAL.Execute(usrCola.NombreRed, usrCola.CodigoRol);
                    }
                }
            }
            else
            {
                var usuario = ObtenerUsuariosDAL.Execute().FirstOrDefault(f => f.UsuarioBPMId == usuarioId);
                if (usuario != null)
                {
                    QueueUsuarios.Add(new ObtenerColaUsuariosResult { CodigoRol = usuario.Roles[0].RolCodigo, NombreRed = usuario.UsuarioNombreRed, Orden= QueueUsuarios.Count+1 });
                    AgregarColaUsuariosDAL.Execute(new List<Usuario> { usuario });
                }
            }
        }
    }
}

