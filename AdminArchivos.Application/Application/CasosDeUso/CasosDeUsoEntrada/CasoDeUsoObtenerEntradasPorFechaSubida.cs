using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoEntrada
{
    public class CasoDeUsoObtenerEntradasPorFechaSubida (IEntradaRepository repo)
    {
        public async Task <List<Entrada>> Ejecutar (DateTime fechasubida)
        {
            return await repo.ObtenerEntradasPorFechaSubidaAsync(fechasubida);
        }
    }
}
