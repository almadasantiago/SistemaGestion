using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasoDeUsoEntrada
{
    public class CasoDeUsoListarEntradasPorUsuario(IEntradaRepository repo)
    {
        public async Task<List<Entrada>> Ejecutar(int idUsuario)
        {
            return await repo.ListarEntradasPorUsuarioAsync(idUsuario);
        }
    }
}

