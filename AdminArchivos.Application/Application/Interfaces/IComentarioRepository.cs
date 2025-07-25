using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.Interfaces
{
    public interface IComentarioRepository
    {
        Task<int> CrearComentarioAsync(Usuario usuario, Entrada entrada, string contenido);
        Task BorrarComentarioAsync(int idComentario);
        Task ModificarComentarioAsync(int idComentario, string nuevoContenido);
        Task<List<Comentario>> ListarComentariosPorEntradaAsync(int idEntrada);
        Task<Comentario> ObtenerComentarioPorIdAsync(int idComentario);
    }
}
