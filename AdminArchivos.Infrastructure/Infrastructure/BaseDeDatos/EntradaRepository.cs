using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;
using AdminArchivos.Infraestructure.BaseDeDatos;

namespace AdminArchivos.Infrastructure.Infrastructure.BaseDeDatos
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly ApplicationDbContext context;
        public Task ActualizarEstadoAsync(int idEntrada)
        {
            throw new NotImplementedException();
        }

        public async Task BorrarEntradaAsync(int idEntrada)
        {
           var entrada = await context.Entradas.FindAsync(idEntrada);
            if (idEntrada != null)
            {
                context.Entradas.Remove(entrada);
                await context.SaveChangesAsync(); 
            }
            else throw new Exception ($" LA ENTRADA CON ID {idEntrada} NO EXISTE EN EL REPOSITORIO ");
        }

        public async Task<int> CrearEntradaAsync(Usuario usuario, string nombreArchivo)
        {
            var entrada = new Entrada(usuario, nombreArchivo); 
            context.Entradas.Add(entrada);
            await context.SaveChangesAsync();
            return entrada.Id; 
        }

        public Task<List<Entrada>> ListarEntradasAprobadasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Entrada>> ListarEntradasAprobadasPorUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entrada>> ListarEntradasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Entrada>> ListarEntradasEnEsperaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Entrada>> ListarEntradasEnEsperaPorUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entrada>> ListarEntradasEntreFechas(DateTime fecha1, DateTime fecha2)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entrada>> ListarEntradasPorFechaDecreciente(DateTime fechaSubida)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entrada>> ListarEntradasPorUsuarioAsync(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entrada>> ListarEntradasRechazadasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Entrada>> ListarEntradasRechazadasPorUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task ModificarEntradaAsync(int idEntrada, string NombreArchivo)
        {
            var entrada = await context.Entradas.FindAsync(idEntrada);
            if (entrada == null)
            {
                throw new Exception($" La entrada con ID {idEntrada} no existe en el repositorio ");
            }
            entrada.NombreArchivo = NombreArchivo;
            entrada.FechaDeActualizacion = DateTime.Now;

            await context.SaveChangesAsync();
        }

        public Task<Entrada> ObtenerEntradaPorFechaSubidaAsync(DateTime fechaSubida)
        {
            throw new NotImplementedException();
        }

        public Task<Entrada> ObtenerEntradaPorIdAsync(int idEntrada)
        {
            throw new NotImplementedException();
        }
    }
}
