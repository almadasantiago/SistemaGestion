using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminArchivos.Application.Application.Interfaces;
using AdminArchivos.Application.Application.Servicios;
using AdminArchivos.Domain.Enums;

namespace AdminArchivos.Application.Application.CasosDeUso.CasosDeUsoUsuario
{
    public class CasoDeUsoUsuarioModificacion (IUsuarioRepository repo)
    {
        public async Task Ejecutar(int idUsuario, string nuevoNombre, string nuevoApellido, string nuevoEmail, string nuevaPassword)
        {
            var nuevaPasswordHasheada = ServicioFuncionHash.FuncionHashSHA256(nuevaPassword);
            await repo.UsuarioModificacionAsync(idUsuario,nuevoNombre,nuevoApellido,nuevoEmail,nuevaPasswordHasheada);
        }
    }
}
