namespace AdminArchivos.Domain.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IdEntrada { get; set; }
        public Entrada Entrada { get; set; }    
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaComentario { get; set; }
        public Comentario()
        {
            FechaComentario = DateTime.Now;
        }
        public Comentario(int id, Usuario usuario, Entrada entrada, string contenido)
        {
            Id = id;
            Usuario = usuario;
            Entrada = entrada;
            IdEntrada = entrada.Id;
            IdUsuario = usuario.Id;
            Contenido = contenido;
            FechaComentario = DateTime.Now;
        }

        public Comentario(Usuario usuario, Entrada entrada, string contenido)
        {
            IdUsuario = usuario.Id;
            Usuario = usuario; 
            IdEntrada = entrada.Id; 
            Entrada = entrada;
            Contenido = contenido; 
            FechaComentario= DateTime.Now;
        } 

    }
}
