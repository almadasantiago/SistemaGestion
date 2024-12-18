namespace GEST.Aplicacion;
public class Usuario { 
    public string? Nombre {get; set;}
    public string? Apellido {get; set;} 
    public string? Email {get; set;}
    public string? Password {get; set;}
    public List <String> Permisos {get; set;}
    public int? IdUsuario {get; set;} 

    public Usuario() { 
        Permisos = new List<string>();
    }
    public Usuario(string nombre, string apellido, string email, string password) { 
            this.Permisos = new List<string> {"Lectura"};
            this.Nombre= nombre; 
            this.Apellido = apellido;
            this.Email=email;
            this.Password= password; 
            
            UsuarioValidador.Validar(this);
    } 
    public Usuario(string nombre, string apellido, string email, string password, int IdUsuario, List<string>? permisos) { 
            this.Nombre= nombre; 
            this.Apellido = apellido;
            this.Email=email;
            this.Password= password; 
            this.IdUsuario= IdUsuario;

            this.Permisos= permisos ?? new List<string> <string> {"Lectura"};
            UsuarioValidador.Validar(this); 
    } 



}