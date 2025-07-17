using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.Validadores
{
    public class ArchivoValidador (IArchivoRepository repo) 
    {
        private static readonly string[] tiposPermitidos = { ".jpg", ".jpeg", ".png", ".pdf", ".docx", ".xlsx", ".txt",".dwg" };
        
        public async Task <string?> Validar(Archivo archivo)
        {
            var extension = Path.GetExtension(archivo.Nombre).ToLowerInvariant();
            if (!tiposPermitidos.Contains(extension))
                return "Tipo de archivo no permitido.";

            if (string.IsNullOrWhiteSpace(archivo.Nombre))
                return "El nombre del archivo no puede estar vacío.";

            if (!Regex.IsMatch(archivo.Nombre, @"^[\w\-. ]+$"))
                return "El nombre del archivo contiene caracteres no permitidos.";

            var archivos = await repo.ListarArchivosPorEntradaAsync(archivo.IdEntrada);
            if (archivos.Any(a => a.Nombre.Equals(archivo.Nombre, StringComparison.OrdinalIgnoreCase)))
                return "Ya existe un archivo con ese nombre en la entrada.";

            // Si todo está bien, retorna null (sin error)
            return null;

        }
    }
}
