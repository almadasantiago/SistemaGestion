using System.Threading.Tasks;
using AdminArchivos.Application.Application.Excepciones;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;
using AdminArchivos.Infraestructure.BaseDeDatos;
using Microsoft.EntityFrameworkCore;

namespace AdminArchivos.Infrastructure.Infrastructure.BaseDeDatos
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly ApplicationDbContext context;

        public ComentarioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CrearComentarioAsync(Usuario usuario, Entrada entrada, string contenido)
        {
            var comentario = new Comentario(usuario, entrada, contenido);
            context.Comentarios.Add(comentario);
            await context.SaveChangesAsync();
            return comentario.Id;
        }
        public async Task BorrarComentarioAsync(int idComentario)
        {
            var comentario = await context.Comentarios.FindAsync(idComentario);
            if (comentario == null)
                throw new RepositorioException();

            context.Comentarios.Remove(comentario);
            await context.SaveChangesAsync();
        }

        public async Task<List<Comentario>> ListarComentariosPorEntradaAsync(int idEntrada)
        {
            return await context.Comentarios
                .Where(c => c.IdEntrada == idEntrada)
                .OrderByDescending(c => c.FechaComentario)
                .Include(c => c.Usuario)
                .ToListAsync(); 
        }

        public async Task ModificarComentarioAsync(int idComentario, string nuevoContenido)
        {
            var comentario = await context.Comentarios.FindAsync(idComentario);
            if (comentario == null)
                throw new RepositorioException(); 
            comentario.Contenido= nuevoContenido;
            comentario.FechaComentario = DateTime.Now; 
            await context.SaveChangesAsync();
        }

        public async Task<Comentario> ObtenerComentarioPorIdAsync(int idComentario)
        {
            var comentario = await context.Comentarios
                .Include(c => c.Usuario)
                .Include(c => c.Entrada)
                .FirstOrDefaultAsync(c => c.Id == idComentario);

            if (comentario == null)
                throw new RepositorioException();

            return comentario;
        }
    }
}