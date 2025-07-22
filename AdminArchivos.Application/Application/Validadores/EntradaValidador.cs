using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;
using AdminArchivos.Domain.Enums;

namespace AdminArchivos.Application.Application.Validadores
{
    public class EntradaValidador(IEntradaRepository repo, IUsuarioRepository usuarioRepo)
    {
        public async Task<string?> Validar(Entrada entrada)
        {
            if (string.IsNullOrWhiteSpace(entrada.NombreArchivo))
                return "El nombre de la entrada no puede estar vacío.";

            if (!Regex.IsMatch(entrada.NombreArchivo, @"^[\w\-. ]+$"))
                return "El nombre de la entrada contiene caracteres no permitidos.";

            if (entrada.NombreArchivo.Length > 100)
                return "El nombre de la entrada es demasiado largo.";
            
            var entradas = await repo.ListarEntradasPorUsuarioAsync(entrada.UsuarioId);
            if (entradas.Any(e => e.NombreArchivo.Equals(entrada.NombreArchivo, StringComparison.OrdinalIgnoreCase)))
                return "Ya existe una entrada con ese nombre para este usuario.";

            var usuario = await usuarioRepo.BuscarPorIdAsync(entrada.UsuarioId);
            if (usuario == null)
                return "El usuario asociado no existe.";

            if (entrada.FechaSubida > DateTime.Now || entrada.FechaDeActualizacion > DateTime.Now)
                return "Las fechas de la entrada no pueden ser futuras.";

            return null;
        }
    }
}
