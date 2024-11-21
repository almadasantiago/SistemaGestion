namespace GEST.Aplicacion; 

   public static class CategoriaValidadorException : System.Exception
    {
        public CategoriaValidadorException() { }
        public CategoriaValidadorException(string message) : base(message) { }
        public CategoriaValidadorException(string message, System.Exception inner) : base(message, inner) { }
        protected CategoriaValidadorException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    
     public static void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new CategoriaValidadorException("El nombre de la categoría no puede estar vacío.");
            }
        }
        public static void ValidarDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new CategoriaValidadorException("La descripción de la categoría no puede estar vacía.");
            }
        }

        public static void ValidarFechaCreacion(DateTime fechaCreacion)
        {
            if (fechaCreacion > DateTime.Now)
            {
                throw new CategoriaValidadorException("La fecha de creación no puede ser una fecha futura.");
            }
        }
        public static void Validar(Categoria categoria)
        {
            ValidarNombre(categoria.Nombre);
            ValidarDescripcion(categoria.Descripcion);
            ValidarFechaCreacion(categoria.FechaCreacion);
        }
    }
    
    

    
    
    
    
    
    }
