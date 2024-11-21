namespace GEST.Aplicacion;
public class Categoria { 
    public string? Nombre {get; set;}
    public string? Descripcion {get; set;}
    public DateTime FechaCreacion {get; set;}
    public int? IdCategoria {get; set;}

    public Categoria() {
    }
    public Categoria(string nombre, string descripcion,DateTime fechaCreacion,int IdCategoria) { 
        this.Nombre= nombre; 
        this.Descripcion = descripcion; 
        this.FechaCreacion = fechaCreacion; 
        this.IdCategoria = IdCategoria; 
    } 
    public Categoria(string nombre, string descripcion,DateTime fechaCreacion) { 
        this.Nombre= nombre; 
        this.Descripcion = descripcion; 
        this.FechaCreacion = fechaCreacion; 
        this.IdCategoria =0; 
    } 

}
