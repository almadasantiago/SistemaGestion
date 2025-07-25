using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoEntrada
{
    public class CasoDeUsoListarEntradaEntreFechas (IEntradaRepository repo)
    {
        public async Task <List <Entrada>> Ejecutar(DateTime fecha1, DateTime fecha2)
        {
            return await repo.ListarEntradasEntreFechas(fecha1, fecha2);
        }
    }
}
