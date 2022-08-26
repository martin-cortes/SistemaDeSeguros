using AutoMapper;
using Domain.Model.DTOs;
using Domain.Model.Entities;
using Domain.Model.General;
using DrivenAdapters.Sql.Contexts;
using Helpers.Commons;
using Helpers.Commons.CustomBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Logica.Usuarios
{
    public class UsuariosLogica : CustomBaseController, IUsuariosLogica
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuariosLogica(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<UsuarioDTO>>> GetObtenerUsuarios()
        {
            try
            {
                return await Get<Usuario, UsuarioDTO>();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult<UsuarioDTO>> GetObtenerUsuario(int id)
        {
            try
            {
                return await GetId<Usuario, UsuarioDTO>(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> PostAgregarUsuario(CreacionUsuarioDTO creacionUsuarioDTO)
        {
            try
            {

                DateTime fecha1 = new DateTime(2000, 1, 1);
                DateTime fecha2 = new DateTime(2018, 1, 1);
                TimeSpan edad = fecha2 - fecha1;
                DateTime hoy = DateTime.Today;
                var edadUsuario = hoy - creacionUsuarioDTO.FechaNacimineto;
                bool existeUsuario = await _context.Usuarios.AnyAsync(x => x.Cedula == creacionUsuarioDTO.Cedula);
                bool existeEmail = await _context.Usuarios.AnyAsync(x => x.Email == creacionUsuarioDTO.Email);
                string emailOrigen = "";
                string pass = "";
                string asunto = "Registro Exitoso";
                string cuerpo = "Gracias por registrarse en Sistema De Seguros ;)";


                RemitenteCorreo enviarCorreo = new RemitenteCorreo(emailOrigen, creacionUsuarioDTO.Email, pass, asunto, cuerpo);

                if (existeUsuario)
                {
                    return BadRequest($"El usuario con la Cedula {creacionUsuarioDTO.Cedula}. Ya existe");
                }
                else if (existeEmail)
                {
                    return BadRequest($"El usuario con el Email {creacionUsuarioDTO.Email}. Ya existe");
                }
                else if (edadUsuario < edad)
                {
                    return BadRequest($"El usuario es menor de edad, no se puede registrar");
                }
                else
                {
                    enviarCorreo.EnviarCorreo();
                    return await Post<CreacionUsuarioDTO, Usuario>(creacionUsuarioDTO); 
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> PutEditarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            try
            {
                bool existeUsuario = await _context.Usuarios.AnyAsync(x => x.Id == id);

                if (!existeUsuario)
                {
                    return BadRequest($"El ID ingresado no esta registrado en la base de datos");
                }
                else
                {
                    return await Put<UsuarioDTO, Usuario>(id, usuarioDTO);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> DeleteEliminarUsuario(int id)
        {
            try
            {
                bool existeUsuario = await _context.Usuarios.AnyAsync(x => x.Id == id);

                if (!existeUsuario)
                {
                    return BadRequest($"El ID ingresado no esta registrado en la base de datos");
                }
                else
                {
                    return await Delete<Usuario>(id);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
