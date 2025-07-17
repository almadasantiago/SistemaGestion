namespace AdminArchivos.Domain.Entidades
{
    public class Archivo
    {
        public int Id { get; set; }
        public int IdEntrada { get; set; }
        public Entrada Entrada { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public string Tipo  { get; set; }
        public double Tamaño { get; set; }

        public Archivo()
        {
        }

        }public Archivo(int id, Entrada entrada, string nombre, string ruta, double tamaño)
        {
            Id = id;
            Entrada = entrada;
            IdEntrada = entrada.Id;
            Nombre = nombre;
            Ruta = ruta;
            Tipo = System.IO.Path.GetExtension(nombre).ToLowerInvariant();
            Tamaño = tamaño;
        }
    }
}
