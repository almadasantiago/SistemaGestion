using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;
using AdminArchivos.Domain.Enums;

namespace AdminArchivos.Application.Application.Validadores
{
    public class EntradaValidador(IEntradaRepository repo, IUsuarioRepository usuarioRepo)
    {
        public async Task<string?> ValidarNombres(string nombreArchivo)
        {
            if (string.IsNullOrWhiteSpace(nombreArchivo))
                return "El nombre de la entrada no puede estar vacío.";

            if (nombreArchivo.Length > 100)
                return "El nombre de la entrada es demasiado largo.";
           
            return null; 
        }
        public async Task<string?> ValidarUsuario(Entrada entrada) {
            var entradas = await repo.ListarEntradasPorUsuarioAsync(entrada.UsuarioId);
            if (entradas.Any(e => e.NombreArchivo.Equals(entrada.NombreArchivo, StringComparison.OrdinalIgnoreCase)))
                return "Ya existe una entrada con ese nombre para este usuario.";

            var usuario = await usuarioRepo.BuscarPorIdAsync(entrada.UsuarioId);
            if (usuario == null)
                return "El usuario asociado no existe.";
            
            return null; 
        }
        public async Task <string?> ValidarFechas(Entrada entrada)
        {
            if (entrada.FechaSubida > DateTime.Now || entrada.FechaDeActualizacion > DateTime.Now)
                return "Las fechas de la entrada no pueden ser futuras.";

            return null;
        }
    
    }
}
