using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;
using AdminArchivos.Domain.Enums;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoComentario
{
    public class CasoDeUsoModificarComentario (IComentarioRepository repo)
    {
        public async Task Ejecutar(int idComentario, string nuevoContenido, Usuario usuarioActual)
        {
            var comentario = await repo.ObtenerComentarioPorIdAsync(idComentario);
            if (comentario == null)
            {
                throw new ArgumentException("El comentario no existe.");
            }
            if (usuarioActual.Rol == RolUsuario.Admin || comentario.IdUsuario == usuarioActual.Id)
            {
                await repo.ModificarComentarioAsync(idComentario, nuevoContenido);
            }
            else
            {
                throw new UnauthorizedAccessException("No tienes permiso para modificar este comentario.");
            }
        }
    }
}
