using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoComentario
{
    public class CasoDeUsoObtenerComentarioPorId(IComentarioRepository repo)
    {
        public async Task<Comentario> Ejecutar(int idComentario)
        {
            return await repo.ObtenerComentarioPorIdAsync(idComentario);  
        }
    }
}

