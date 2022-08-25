using AutoMapper;
using Domain.Model.DTOs;
using Domain.Model.Entities;
using DrivenAdapters.Sql.Contexts;
using Helpers.Commons.CustomBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UseCase.Logica.Usuarios;

namespace SistemaDeSeguros.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : CustomBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUsuariosLogica _logica;

        public UsuariosController(ApplicationDbContext context, IMapper mapper, IUsuariosLogica logica) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _logica = logica;
        }

        // Obtener un listado de todos los clientes registrados
        [HttpGet]

        public async Task<ActionResult<List<UsuarioDTO>>> ObtenerUsuarios()
        {
            try
            {
                return await _logica.GetObtenerUsuarios();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //Obtener un cliente por Id

        [HttpGet("{id:int}")]

        public async Task<ActionResult<UsuarioDTO>> ObtenerUsuario(int id)
        {
            try
            {
                return await _logica.GetObtenerUsuario(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // Registrar un cliente en la base de datos
        [HttpPost]

        public async Task<ActionResult> AgregarUsuario([FromForm] CreacionUsuarioDTO creacionUsuarioDTO)
        {
            try
            {
               return await _logica.PostAgregarUsuario(creacionUsuarioDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // Actualizar todos los campos de un cliente ya registrado
        [HttpPut("{id:int}")]

        public async Task<ActionResult> EditarUsuario(int id, [FromForm] UsuarioDTO usuarioDTO)
        {
            try
            {
                return await _logica.PutEditarUsuario(id, usuarioDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // Eliminar un cliente por Id
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> EliminarUsuario(int id)
        {
            try
            {
                return await _logica.DeleteEliminarUsuario(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }





    }
}
