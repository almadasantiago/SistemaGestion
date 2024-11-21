namespace GEST.Aplicacion
{
    public class UsuarioValidadorException : System.Exception
    {
        public UsuarioValidadorException() { }
        public UsuarioValidadorException(string message) : base(message) { }
        public UsuarioValidadorException(string message, System.Exception inner) : base(message, inner) { }
        protected UsuarioValidadorException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    public static class UsuarioValidador
    {
        public static void ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@") || !correo.Contains("."))
            {
                throw new UsuarioValidadorException("El correo electrónico no es válido.");
            }
        }
        public static void ValidarContraseña(string contr)
        {
            if (string.IsNullOrWhiteSpace(contr) || contr.Length < 5)
            {
                throw new UsuarioValidadorException("La contraseña debe contener 5 caracteres o más.");
            }
        }
        public static void Validar(Usuario usuario)
        {
            ValidarCorreo(usuario.Email);
            ValidarContraseña(usuario.Password);
        }
    }
}
