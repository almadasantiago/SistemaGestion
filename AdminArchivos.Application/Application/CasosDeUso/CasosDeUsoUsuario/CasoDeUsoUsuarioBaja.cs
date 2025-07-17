using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Application.Application.Validadores;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoUsuario
{
    public class CasoDeUsoUsuarioBaja (IUsuarioRepository repo) 
    {
        public async Task Ejecutar(int idUsuario)
        {   
            await repo.UsuarioBajaAsync(idUsuario);
        }
    }
}
