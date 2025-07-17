using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;

namespace AdminArchivos.Application.Application.Validadores
{
    public class UsuarioValidador (IUsuarioRepository repo) 
    {
        public async Task<bool> Validar(string email)
        {
            return await repo.EmailExisteAsync(email); 
        }
    }
}
