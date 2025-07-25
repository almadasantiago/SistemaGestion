using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Domain.Entidades;
using AdminArchivos.Domain.Enums;

namespace AdminArchivos.Application.Application.Interfaces
{
    public interface IEntradaRepository
    {
        Task<int> CrearEntradaAsync(Usuario usuario, string nombreArchivo);
        Task BorrarEntradaAsync(int idEntrada);
        Task ActualizarEstadoAsync(int idEntrada, EstadoEntrada nuevoEstado);
        Task<Entrada> ObtenerEntradaPorIdAsync(int idEntrada);
        Task<List<Entrada>> ObtenerEntradasPorFechaSubidaAsync(DateTime fechaSubida);
        Task<List<Entrada>> ListarEntradasAsync();
        Task<List<Entrada>> ListarEntradasEntreFechas(DateTime fecha1, DateTime fecha2);
        Task<List<Entrada>> ListarEntradasPorFechaDecreciente(DateTime fechaSubida); 
        Task<List<Entrada>> ListarEntradasPorUsuarioAsync(int idUsuario);
        Task<List<Entrada>> ListarEntradasAprobadasAsync();
        Task<List<Entrada>> ListarEntradasAprobadasPorUsuario(int idUsuario);
        Task<List<Entrada>> ListarEntradasRechazadasAsync();
        Task<List<Entrada>> ListarEntradasRechazadasPorUsuario(int idUsuario);
        Task<List<Entrada>> ListarEntradasEnEsperaAsync();
        Task<List<Entrada>> ListarEntradasEnEsperaPorUsuario(int idUsuario);
        Task ModificarEntradaAsync(int idEntrada, string NombreArchivo);
    }
}
