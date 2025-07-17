using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArchivos.Infrastructure.Infrastructure.Services
{
    public interface IS3Service
    {
        Task SubirArchivoAsync(string key, Stream contenido);
        Task<Stream> DescargarArchivoAsync(string key); 
        Task EliminarArchivoAsync (string key);
        Task <List<string>> ListarArchivosAsync(string prefix = "");
    }
}
