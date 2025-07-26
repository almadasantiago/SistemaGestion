using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Application.Application.Validadores;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoComentario
{
    public class CasoDeUsoCrearComentario(IComentarioRepository repo, ComentarioValidador validador)
    {
        public async Task<int> Ejecutar(Usuario usuario, Entrada entrada, string contenido)
        {
            var error = await validador.Validar(usuario, entrada, contenido);
            if (error != null)
            {
                throw new ArgumentException(error);
            }
            return await repo.CrearComentarioAsync(usuario, entrada, contenido);
        }
    }
}