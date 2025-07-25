using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoEntrada
{
    public class CasoDeUsoListarEntradasEnEsperaPorUsuario (IEntradaRepository repo)
    {
        public async Task<List<Entrada>> Ejecutar(int usuarioId)
        {
            return await repo.ListarEntradasEnEsperaPorUsuario(usuarioId);
        }
    }
}
