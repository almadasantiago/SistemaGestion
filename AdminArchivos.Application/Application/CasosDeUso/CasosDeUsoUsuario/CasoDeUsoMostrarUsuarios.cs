using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoUsuario
{
    public class CasoDeUsoMostrarUsuarios (IUsuarioRepository repo)
    {
        public async Task<List<Usuario>> Ejecutar()
        {
            return await repo.ListarUsuariosAsync(); 
        } 
    }
}
