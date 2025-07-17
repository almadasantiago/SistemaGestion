using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Application.Application.Validadores;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasoDeUsoArchivo
{
    public class CasoDeUsoSubirArchivo (IArchivoRepository repo, ArchivoValidador validador)
    {
        public async Task <int> Ejecutar (Archivo archivo, Stream contenido)
        {
            var error = await validador.Validar(archivo);
            if (error != null)
            {
                throw new ArgumentException(error);
            }
            return await repo.GuardarArchivoAsync(archivo, contenido);
        }
    }
}
