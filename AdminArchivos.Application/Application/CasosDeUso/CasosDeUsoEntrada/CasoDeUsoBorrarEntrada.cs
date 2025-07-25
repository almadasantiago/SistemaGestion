using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoEntrada
{
    public class CasoDeUsoBorrarEntrada (IEntradaRepository repo)
    {
        public async Task Ejecutar (int idEntrada)
        {
           await repo.BorrarEntradaAsync (idEntrada);
        }
    }
}
