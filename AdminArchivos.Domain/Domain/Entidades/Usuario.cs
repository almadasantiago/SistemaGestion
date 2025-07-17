using AdminArchivos.Domain.Entidades;
using AdminArchivos.Domain.Enums; 

namespace AdminArchivos.Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public RolUsuario Rol { get; set; }

        public List<Entrada> Entradas { get; set; } = new List<Entrada>();

        public Usuario()
        {
            Rol = RolUsuario.Normal; // Default role
        }

        public Usuario(string nombre, string apellido, string email, string password, RolUsuario rol)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            Rol = rol;
        }

    }
}
