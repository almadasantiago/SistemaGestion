using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application;
using AdminArchivos.Application.Application.Interfaces;

namespace AdminArchivos.Application.Application.Servicios
{
    public class ServicioAutorizacion(IUsuarioRepository repo) 
    {
        public async Task<bool> UsuarioAutorizadoAsync(int idUsuario) 
        {
            return await repo.ConsultarRolUsuarioAsync(idUsuario);
        }
    }
}
