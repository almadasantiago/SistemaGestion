using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;
using AdminArchivos.Infraestructure.BaseDeDatos;
using AdminArchivos.Infrastructure.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace AdminArchivos.Infrastructure.Infrastructure.BaseDeDatos
{
    public class ArchivoRepository : IArchivoRepository
    {
        private readonly IS3Service s3Service; 
        private readonly ApplicationDbContext context; 


        public async Task<Stream> DescargarArchivoAsync(int id)
        {
            var archivo = await context.Archivos.FindAsync(id);
            if (archivo != null)
            {
                return await s3Service.DescargarArchivoAsync(archivo.Nombre);
            }
            else throw new Exception($" El archivo de ID = {id} no existe en el servidor ");
        }

        public async Task EliminarArchivoAsync(int id)
        {
            var archivo = await context.Archivos.FindAsync(id);
            if (archivo != null)
            {
                await s3Service.EliminarArchivoAsync(archivo.Nombre);
                context.Archivos.Remove(archivo);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> GuardarArchivoAsync(Archivo archivo, Stream contenido)
        {
            await s3Service.SubirArchivoAsync(archivo.Nombre, contenido);
            context.Archivos.Add(archivo);
            await context.SaveChangesAsync();
            return archivo.Id;
        }

        public async Task<List<Archivo>> ListarArchivosPorEntradaAsync(int idEntrada)
        {
            return await context.Archivos.Where (a => a.IdEntrada == idEntrada).ToListAsync();
        }

        public async Task<Archivo> ObtenerArchivoPorId(int id)
        {
            var archivo = await context.Archivos.FindAsync(id);
            if (archivo != null)
            {
                return archivo;
            }
            else
            {
                throw new Exception($" El archivo de ID = {id} no existe en la base de datos ");
            }
        }

    }
}
