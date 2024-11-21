namespace GEST.Aplicacion
{
   public class EntradaValidadorException : System.Exception
    {
        public EntradaValidadorException() { }
        public EntradaValidadorException(string message) : base(message) { }
        public EntradaValidadorException(string message, System.Exception inner) : base(message, inner) { }
        protected EntradaValidadorException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
     public static void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new EntradaValidadorException("El nombre no puede estar vacío.");
            }
        }
        public static void ValidarDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new EntradaValidadorException("La descripción no puede estar vacía.");
            }
        }
        public static void ValidarEmailAsociado(string emailAsociado)
        {
            if (string.IsNullOrWhiteSpace(emailAsociado) || !emailAsociado.Contains("@") || !emailAsociado.Contains("."))
            {
                throw new EntradaValidadorException("El correo asociado no es válido.");
            }
        }
        public static void ValidarFecha(DateTime fecha)
        {
            if (fecha < DateTime.Now)
            {
                throw new EntradaValidadorException("La fecha no puede ser anterior a la fecha actual.");
            }
        }
        public static void Validar(Entrada entrada)
        {
            ValidarNombre(entrada.Nombre);
            ValidarDescripcion(entrada.Descripcion);
            ValidarEmailAsociado(entrada.EmailAsociado);
            ValidarFecha(entrada.Fecha);
        }
    }
