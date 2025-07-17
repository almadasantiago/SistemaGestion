using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.Interfaces
{
    public interface IArchivoRepository
    {
        Task <int> GuardarArchivoAsync (Archivo archivo, Stream contenido);
        Task<Archivo> ObtenerArchivoPorId(int id);
        Task EliminarArchivoAsync(int id);
        Task<List<Archivo>> ListarArchivosPorEntradaAsync(int idEntrada);
        Task<Stream> DescargarArchivoAsync(int id);
    }
}
