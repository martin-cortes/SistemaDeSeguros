using AutoMapper;
using Domain.Model.Entities;
using DrivenAdapters.Sql.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helpers.Commons.CustomBase
{
    public class CustomBaseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomBaseController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // Obtiene una lista de todos los elemnetos regsitrados en la base de datos usuarios 
        protected async Task<List<TDTO>> Get<TEntidad, TDTO>() where TEntidad : class
        {
            List<TEntidad> entidades = await _context.Set<TEntidad>().AsNoTracking().ToListAsync();
            List<TDTO> dto = _mapper.Map<List<TDTO>>(entidades);

            return dto;
        }


        // Obtiene un elemento buscado por el Id
        protected async Task<ActionResult<TDTO>> GetId<TEntidad, TDTO>(int id) where TEntidad : class, IId
        {
            TEntidad entidad = await _context.Set<TEntidad>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (entidad == null)
            {
                return NotFound();
            }

            return _mapper.Map<TDTO>(entidad);
        }

        // nos regitra un elemento en la base de datos 
        public async Task<ActionResult> Post<TCreacionDTO, TEntidad>(TCreacionDTO creacionDTO) where TEntidad : class
        {
            TEntidad entidad = _mapper.Map<TEntidad>(creacionDTO);
            _context.Add(entidad);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Actualiza todos los campos de un elemento en la base de datos 
        protected async Task<ActionResult> Put<TCreacionDTO, TEntidad>(int id, TCreacionDTO creacionDTO) where TEntidad : class, IId
        {
            TEntidad entidad = _mapper.Map<TEntidad>(creacionDTO);
            entidad.Id = id;
            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // nos elimina un elemnto buscandolo por el id 
        protected async Task<ActionResult> Delete<TEntidad>(int id) where TEntidad : class, IId, new()
        {
            bool existeUsuario = await _context.Set<TEntidad>().AnyAsync(x => x.Id == id);

            if (!existeUsuario) { return NotFound("El Id ingresado no se encuentra registrado en la base de datos del sistema"); }

            _context.Remove(new TEntidad() { Id = id });
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //protected async Task<ActionResult> Patch<TEntidad, >
    }
}
