using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasoDeUsoEntrada
{
    public class CasoDeUsoObtenerEntradaPorId(IEntradaRepository repo)
    {
        public async Task<Entrada> Ejecutar(int idEntrada)
        {
            return await repo.ObtenerEntradaPorIdAsync(idEntrada);
        }
    }
}

