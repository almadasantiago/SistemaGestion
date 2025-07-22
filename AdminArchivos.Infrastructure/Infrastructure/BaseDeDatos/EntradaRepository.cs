using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Excepciones;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;
using AdminArchivos.Domain.Enums;
using AdminArchivos.Infraestructure.BaseDeDatos;
using Microsoft.EntityFrameworkCore;

namespace AdminArchivos.Infrastructure.Infrastructure.BaseDeDatos
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly ApplicationDbContext context;
        public async Task ActualizarEstadoAsync(int idEntrada, EstadoEntrada nuevoEstado)
        {
            var entrada = await context.Entradas.FindAsync(idEntrada);
            if (entrada == null)
            {
                throw new RepositorioException(); 
            }
            entrada.Estado = nuevoEstado;
            entrada.FechaDeActualizacion = DateTime.Now;
            await context.SaveChangesAsync();
        }

        public async Task BorrarEntradaAsync(int idEntrada)
        {
            var entrada = await context.Entradas.FindAsync(idEntrada);
            if (entrada != null)
            {
                context.Entradas.Remove(entrada);
                await context.SaveChangesAsync();
            }
            else throw new RepositorioException();
        }

        public async Task<int> CrearEntradaAsync(Usuario usuario, string nombreArchivo)
        {
            var entrada = new Entrada(usuario, nombreArchivo);
            context.Entradas.Add(entrada);
            await context.SaveChangesAsync();
            return entrada.Id;
        }

        public async Task<List<Entrada>> ListarEntradasAsync()
        {
            return await context.Entradas
                .Include(e => e.Archivos)
                .Include(e => e.Comentarios)
                .ToListAsync();
        }
        public async Task<List<Entrada>> ListarEntradasPorUsuarioAsync(int idUsuario)
        {
            return await context.Entradas
                .Where(e => e.UsuarioId == idUsuario)
                .Include(e => e.Archivos)
                .Include(e => e.Comentarios)
                .ToListAsync();
        }

        public async Task<List<Entrada>> ListarEntradasAprobadasAsync()
        {
            return await context.Entradas
                .Where(e => e.Estado == EstadoEntrada.Aprobada)
                .Include(e => e.Archivos)
                .Include(e => e.Comentarios)
                .ToListAsync(); 
        }

        public async Task<List<Entrada>> ListarEntradasAprobadasPorUsuario(int idUsuario)
        {
            return await context.Entradas
            .Where(e => e.Estado == EstadoEntrada.Aprobada && e.UsuarioId == idUsuario)
            .Include(e => e.Archivos)
            .Include(e => e.Comentarios)
            .ToListAsync(); 
        }


        public async Task<List<Entrada>> ListarEntradasEnEsperaAsync()
        {
            return await context.Entradas
                .Where(e => e.Estado == EstadoEntrada.EnEspera)
                .Include(e => e.Archivos)
                .Include(e => e.Comentarios)
                .ToListAsync();
        }

        public async Task<List<Entrada>> ListarEntradasEnEsperaPorUsuario(int idUsuario)
        {
            return await context.Entradas
                .Where(e => e.Estado == EstadoEntrada.EnEspera && e.UsuarioId == idUsuario)
                .Include(e => e.Archivos)
                .Include(e => e.Comentarios)
                .ToListAsync();
        }

        public async Task<List<Entrada>> ListarEntradasRechazadasAsync()
        {
            return await context.Entradas
                .Where(e => e.Estado == EstadoEntrada.Rechazada)
                .Include(e => e.Archivos)
                .Include(e => e.Comentarios)
                .ToListAsync();
        }


        public async Task<List<Entrada>> ListarEntradasRechazadasPorUsuario(int idUsuario)
        {
            return await context.Entradas
                    .Where(e => e.Estado == EstadoEntrada.Rechazada && e.UsuarioId == idUsuario)
                    .Include (e => e.Archivos)
                    .Include(e => e.Comentarios)
                    .ToListAsync();
        }


        public async Task<List<Entrada>> ListarEntradasEntreFechas(DateTime fecha1, DateTime fecha2)
        {
            return await context.Entradas
                .Where(e => e.FechaSubida >= fecha1 && e.FechaSubida <= fecha2)
                .Include(e => e.Archivos)
                .Include(e => e.Comentarios)
                .ToListAsync();
        }

        public async Task<List<Entrada>> ListarEntradasPorFechaDecreciente(DateTime fechaSubida)
        {
            return await context.Entradas
                .Where(e => e.FechaSubida <= fechaSubida)
                .OrderByDescending(e => e.FechaSubida)
                .Include(e => e.Archivos)
                .Include(e => e.Comentarios)
                .ToListAsync();
        }

        public async Task ModificarEntradaAsync(int idEntrada, string NombreArchivo)
        {
            var entrada = await context.Entradas.FindAsync(idEntrada);
            if (entrada == null)
            {
                throw new RepositorioException();
            }
            entrada.NombreArchivo = NombreArchivo;
            entrada.FechaDeActualizacion = DateTime.Now;

            await context.SaveChangesAsync();
        }

        public async Task<Entrada> ObtenerEntradaPorFechaSubidaAsync(DateTime fechaSubida)
        {
            var entrada = await context.Entradas.
                 Include(e => e.Archivos)
                 .Include(e => e.Comentarios)
                 .FirstOrDefaultAsync(e => e.FechaSubida == fechaSubida); 
            if (entrada == null)
            {
                throw new RepositorioException();
            }
            return entrada;
        }

        public async Task<Entrada> ObtenerEntradaPorIdAsync(int idEntrada)
        {
            var entrada = await context.Entradas
                .Include(e => e.Archivos)
                .Include(e => e.Comentarios)
                .FirstOrDefaultAsync(e => e.Id == idEntrada);
            if (entrada == null)
            {
                throw new RepositorioException();
            }
            return entrada;
        }
    }
} 
