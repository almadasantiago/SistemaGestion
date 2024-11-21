namespace GEST.Aplicacion;
public class Entrada { 
    public string? Nombre {get; set;}
    public string? Descripcion {get; set;}
    public string? EmailAsociado {get; set;}
    public DateTime Fecha {get; set;}
    public int? IdEntrada {get; set;} 
    public int? IdCategoria {get; set;}

    public Entrada() {
    }
    public Entrada(string nombre, string descripcion, string emailasociado, DateTime fecha, int IdEntrada, int IdCategoria) { 
        this.Nombre= nombre; 
        this.Descripcion = descripcion; 
        this.EmailAsociado =emailasociado; 
        this.Fecha = fecha; 
        this.IdEntrada = IdEntrada; 
        this.IdCategoria = IdCategoria;
        EntradaValidador.Validar(this); 
    } 
   public Entrada(string nombre, string descripcion, string emailasociado, DateTime fecha,int IdEntrada) { 
        this.Nombre= nombre; 
        this.Descripcion = descripcion; 
        this.EmailAsociado =emailasociado; 
        this.Fecha = fecha; 
        this.IdEntrada = IdEntrada;
        this.IdCategoria=0;
        EntradaValidador.Validar(this); 
   }

}
