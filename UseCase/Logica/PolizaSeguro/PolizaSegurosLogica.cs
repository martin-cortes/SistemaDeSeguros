using AutoMapper;
using Domain.Model.DTOs;
using Domain.Model.Entities;
using DrivenAdapters.Sql.Contexts;
using Helpers.Commons.CustomBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Logica.PolizaSeguro
{
    public class PolizaSegurosLogica : CustomBaseController, IPolizaSegurosLogica
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PolizaSegurosLogica(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ActionResult<List<PolizaSegurosDTO>>> GetObtenerSeguros()
        {
            try
            {
                return await Get<PolizaSeguros, PolizaSegurosDTO>();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        
        public async Task<ActionResult<PolizaSegurosDTO>> GetObtenerSeguro(int id)
        {
            try
            {
                return await GetId<PolizaSeguros, PolizaSegurosDTO>(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        
        public async Task<ActionResult> PostRegistrarSeguro([FromForm] CreacionPolizaSegurosDTO creacionPolizaSegurosDTO)
        {
            try
            {
                return await Post<CreacionPolizaSegurosDTO, PolizaSeguros>(creacionPolizaSegurosDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

       
        public async Task<ActionResult> PutEditarSeguro(int id, [FromForm] PolizaSegurosDTO polizaSegurosDTO)
        {
            try
            {
                bool existeSeguro = await context.PolizaSeguros.AnyAsync(x => x.Id == id);

                if (!existeSeguro)
                {
                    return BadRequest($"El ID ingresado no esta registrado en la base de datos");
                }
                else
                {
                    return await Put<PolizaSegurosDTO, PolizaSeguros>(id, polizaSegurosDTO);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        public async Task<ActionResult> DeleteEliminarSeguro(int id)
        {
            try
            {
                bool existeSeguro = await context.PolizaSeguros.AnyAsync(x => x.Id == id);

                if (!existeSeguro)
                {
                    return BadRequest($"El ID ingresado no esta registrado en la base de datos");
                }
                else
                {
                    return await Delete<PolizaSeguros>(id);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}

