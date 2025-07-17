using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;

namespace AdminArchivos.Application.Application.CasosDeUso.CasoDeUsoArchivo
{
    public class CasoDeUsoDescargarArchivo (IArchivoRepository repo)
    {
        public async Task<Stream> Ejecutar(int id)
        {
            return await repo.DescargarArchivoAsync(id); 
        }
    }
}
