using Domain.Model.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Logica.Usuarios
{
    public interface IUsuariosLogica 
    {
        Task<ActionResult<List<UsuarioDTO>>> GetObtenerUsuarios();
        Task<ActionResult<UsuarioDTO>> GetObtenerUsuario(int id);
        Task<ActionResult> PostAgregarUsuario(CreacionUsuarioDTO creacionUsuarioDTO);
        Task<ActionResult> PutEditarUsuario(int id, UsuarioDTO usuarioDTO);
        Task<ActionResult> DeleteEliminarUsuario(int id);
    }
}
