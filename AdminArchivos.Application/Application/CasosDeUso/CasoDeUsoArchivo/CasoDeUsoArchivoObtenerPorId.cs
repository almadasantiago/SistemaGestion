using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasoDeUsoArchivo
{
    public class CasoDeUsoArchivoObtenerPorId (IArchivoRepository repo)
    {
        public async Task<Archivo> Ejecutar (int idArchivo)
        {
            return await repo.ObtenerArchivoPorId(idArchivo); 
        }
    }
}
