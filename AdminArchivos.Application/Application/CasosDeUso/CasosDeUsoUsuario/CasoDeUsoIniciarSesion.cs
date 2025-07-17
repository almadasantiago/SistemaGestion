using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Application.Application.Servicios;
using AdminArchivos.Domain.Entidades;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoUsuario
{
    public class CasoDeUsoIniciarSesion (IUsuarioRepository repo)
    {
        public Usuario Ejecutar(string email, string password)
        {
            string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
            return repo.UsuarioInicioSesion(email, passwordPasadaPorHash); 
        }
    }
}
