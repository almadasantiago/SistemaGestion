using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Enums;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoEntrada
{
    public class CasoDeUsoActualizarEstadoEntrada (IEntradaRepository repo)
    {
        public async Task Ejecutar(int idEntrada, EstadoEntrada nuevoEstado)
        {
            await repo.ActualizarEstadoAsync(idEntrada, nuevoEstado);
        }
    }
}
