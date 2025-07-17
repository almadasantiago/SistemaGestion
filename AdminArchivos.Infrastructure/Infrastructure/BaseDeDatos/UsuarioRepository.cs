using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Domain.Entidades;
using AdminArchivos.Domain.Enums;
using AdminArchivos.Infraestructure.BaseDeDatos;
using Microsoft.EntityFrameworkCore;

namespace AdminArchivos.Infrastructure.Infrastructure.BaseDeDatos
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> UsuarioAltaAsync(string nombre, string apellido, string email, string password, RolUsuario rol)
        {
            var usuario = new Usuario(nombre, apellido, email, password, rol);
            await context.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario.Id;
        }

        public async Task UsuarioBajaAsync(int idUsuario)
        {
            var usuarioABorrar = await context.Usuarios.FirstOrDefaultAsync(u => u.Id == idUsuario);
            if (usuarioABorrar != null)
            {
                context.Remove(usuarioABorrar);
                await context.SaveChangesAsync();
            }
        }

        public async Task UsuarioModificacionAsync(int idUsuario, string nombre, string apellido, string email, string password, RolUsuario rol)
        {
            var usuarioModificacion = await context.Usuarios.FindAsync(idUsuario);
            if (usuarioModificacion != null)
            {
                usuarioModificacion.Nombre = nombre;
                usuarioModificacion.Apellido = apellido;
                usuarioModificacion.Email = email;
                usuarioModificacion.Password = password;
                usuarioModificacion.Rol = rol;
                context.Update(usuarioModificacion);
                await context.SaveChangesAsync();
            }

        }

        public async Task<Usuario> BuscarPorIdAsync(int id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null)
            {
                throw new Exception("El usuario no existe en el repositorio");
            }
            return usuario;
        }

        public async Task<List<Usuario>> ListarUsuariosAsync()
        {
            return await context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> BuscarPorNombreAsync(string nombre, string apellido)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Nombre.ToLower() == nombre.ToLower() && u.Apellido.ToLower() == apellido.ToLower());
            if (usuario == null)
            {
                throw new Exception("El usuario no existe en el repositorio");
            }
            return usuario;
        }

        public Usuario UsuarioInicioSesion(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Email y contraseña no pueden ser vacíos.");

            var usuario = context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if (usuario != null)
            {
                if (usuario.Password == password)
                {
                    return usuario;
                }
                else
                {
                    throw new Exception("La contraseña ingresada no corresponde con el correo ingresado");
                }
            }
            else
            {
                throw new Exception("El correo ingresado no existe en el repositorio");
            }
        }

        public async Task<bool> EmailExisteAsync(string email)
        {
            return await context.Usuarios.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<bool> ConsultarRolUsuarioAsync(int idUsuario)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Id == idUsuario);
            return (usuario != null) && (usuario.Rol == RolUsuario.Admin);
        }
    }
}
