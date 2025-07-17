using AdminArchivos.Domain.Enums;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Domain.Entidades
{
    public class Entrada
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public string NombreArchivo { get; set; }

        public DateTime FechaSubida { get; set; }
        public DateTime FechaDeActualizacion { get; set; }

        public EstadoEntrada Estado { get; set; }

        public List<Archivo> Archivos { get; set; } = new List<Archivo>();
        public List <Comentario> Comentarios { get; set; } = new List<Comentario>();

        public Entrada()
        {
            Estado = EstadoEntrada.EnEspera; // Default state
            FechaSubida = DateTime.Now;
            FechaDeActualizacion = DateTime.Now;
        }

        public Entrada(int id, int idUsuario, string nombreArchivo, EstadoEntrada estado = EstadoEntrada.EnEspera)
        {
            Id = id;
            UsuarioId = idUsuario;
            NombreArchivo = nombreArchivo;
            Estado = estado;
            FechaSubida = DateTime.Now;
            FechaDeActualizacion = DateTime.Now;

        }
        public Entrada(int id,Usuario usuario, string nombreArchivo, EstadoEntrada estado = EstadoEntrada.EnEspera)
        {
            Id = id;
            Usuario = usuario;
            UsuarioId = usuario.Id;
            NombreArchivo = nombreArchivo;
            Estado = estado;
            FechaSubida = DateTime.Now;
            FechaDeActualizacion = DateTime.Now;

        }
    } 
}
