using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.Validadores
{
    public class ComentarioValidador (IComentarioRepository repo, IEntradaRepository entradaRepo)
    {
        public async Task <string?> Validar (Usuario usuario, Entrada entrada, string contenido)
        {
            if (string.IsNullOrEmpty(contenido))
                return "El contenido del comentario no puede estar vacío.";
            if (contenido.Length > 500)
                return "El contenido del comentario es demasiado largo. Debe tener un máximo de 500 caracteres.";
            if (entradaRepo.ObtenerEntradaPorIdAsync(entrada.Id) == null)
                return "La entrada no existe.";
            return null; 
        }
    }
}
