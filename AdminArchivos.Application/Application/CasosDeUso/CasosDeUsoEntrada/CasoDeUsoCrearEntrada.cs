using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Application.Application.Validadores;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoEntrada
{
    public class CasoDeUsoCrearEntrada (IEntradaRepository repo, EntradaValidador validador) 
    {
        public async Task<int> Ejecutar(Usuario usuario, string nombreArchivo)
        {
            var entrada = new Entrada(usuario, nombreArchivo);
            var validacionNombre = await validador.ValidarNombres(nombreArchivo);
            var validacionUsuario = await validador.ValidarUsuario(entrada); 
            if (validacionNombre != null && validacionUsuario != null)
            {
                throw new ArgumentException(validacionUsuario);
            }
            return await repo.CrearEntradaAsync(usuario, nombreArchivo);
        }
    }
}
