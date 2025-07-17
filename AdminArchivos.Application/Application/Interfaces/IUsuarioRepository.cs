using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Domain.Entidades;
using AdminArchivos.Domain.Enums;

namespace AdminArchivos.Application.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task <int> UsuarioAltaAsync(string nombre, string apellido, string email, string password, RolUsuario rol);
        Task UsuarioBajaAsync(int idUsuario);
        Task UsuarioModificacionAsync(int idUsuario, string nombre, string apellido, string email, string password, RolUsuario rol);
        Task<List<Usuario>> ListarUsuariosAsync();
        Task<Usuario> BuscarPorIdAsync(int id);
        Task<Usuario> BuscarPorNombreAsync(string nombre, string apellido);
        Usuario UsuarioInicioSesion(string email, string password);
        Task <bool> EmailExisteAsync(string email); 
        Task<bool> ConsultarRolUsuarioAsync(int idUsuario);
    }
}
