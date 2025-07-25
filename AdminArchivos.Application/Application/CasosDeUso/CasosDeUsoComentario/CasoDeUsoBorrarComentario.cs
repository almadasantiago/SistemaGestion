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
    public class CasoDeUsoBorrarComentario (IComentarioRepository repo)
    {
        public async Task Ejecutar (int idComentario, Usuario usuarioActual)
        {
            var comentario = await repo.ObtenerComentarioPorIdAsync (idComentario);
            if (usuarioActual.Rol == RolUsuario.Admin || comentario.IdUsuario == usuarioActual.Id)
            {
                await repo.BorrarComentarioAsync(idComentario);
            }
            else throw new UnauthorizedAccessException ();
        }
    }
}
