using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Application.Application.Validadores;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoEntrada
{
    public class CasoDeUsoModificarEntrada (IEntradaRepository repo, EntradaValidador validador)
    {
        public async Task Ejecutar(int idEntrada, string nombreArchivo)
        {
            var error = await validador.ValidarNombres(nombreArchivo);
            if (error != null)
            {
                throw new ArgumentException(error);
            }
            await repo.ModificarEntradaAsync(idEntrada, nombreArchivo);
        } 
    }
}
