using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Application.Application.Servicios;
using AdminArchivos.Application.Application.Validadores;
using AdminArchivos.Domain.Enums;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoUsuario
{
    public class CasoDeUsoUsuarioAlta(IUsuarioRepository usuarioRepository, UsuarioValidador usuarioValidador)
    {
        public async Task Ejecutar(string nombre, string apellido, string email, string password, RolUsuario rol)
        {
            if (await usuarioValidador.Validar(email))
            {
                throw new Exception("El email ya existe.");
            }
            else
            {   
                string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password); 
                int id = await usuarioRepository.UsuarioAltaAsync(nombre, apellido, email, passwordPasadaPorHash, rol);
                
            }
        } 
      
    }
}
