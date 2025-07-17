using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;

namespace AdminArchivos.Application.Application.CasosDeUso.CasoDeUsoArchivo
{
    public class CasoDeUsoEliminarArchivo (IArchivoRepository repo)
    {
        public async Task Ejecutar(int id)
        {
            await repo.EliminarArchivoAsync(id);
        }
    }
}
