using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdminArchivos.Application.Application.Excepciones;
public class RepositorioException : Exception
{
    public RepositorioException() : base("RepositorioException: El ID o la entidad no existe en el repositorio.") { }

    public RepositorioException(string mensaje) : base(mensaje) { }

    public RepositorioException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
}