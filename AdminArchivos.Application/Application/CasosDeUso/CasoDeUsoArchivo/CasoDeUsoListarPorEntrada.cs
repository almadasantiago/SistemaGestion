using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasoDeUsoArchivo
{
    public class CasoDeUsoListarPorEntrada (IArchivoRepository repo)
    {
        public async Task<List<Archivo>> Ejecutar (int idEntrada)
        {
            return await repo.ListarArchivosPorEntradaAsync(idEntrada);
        }
    }
}
