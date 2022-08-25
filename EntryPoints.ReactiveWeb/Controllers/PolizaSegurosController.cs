using AutoMapper;
using Domain.Model.DTOs;
using Domain.Model.Entities;
using DrivenAdapters.Sql.Contexts;
using Helpers.Commons.CustomBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UseCase.Logica.PolizaSeguro;

namespace SistemaDeSeguros.Controllers
{
    [ApiController]
    [Route("api/polizaSeguros")]
    public class PolizaSegurosController : ControllerBase
    {
        private readonly IPolizaSegurosLogica _logica;

        public PolizaSegurosController(IPolizaSegurosLogica logica)
        {
            _logica = logica;
        }

        [HttpGet]

        public async Task<ActionResult<List<PolizaSegurosDTO>>> ObtenerSeguros()
        {
            try
            {
                return await _logica.GetObtenerSeguros();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<PolizaSegurosDTO>> ObtenerSeguro(int id)
        {
            try
            {
                return await _logica.GetObtenerSeguro(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<ActionResult> RegistrarSeguro([FromForm] CreacionPolizaSegurosDTO creacionPolizaSegurosDTO)
        {
            try
            {
                return await _logica.PostRegistrarSeguro(creacionPolizaSegurosDTO);
                 
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> EditarSeguro(int id, [FromForm] PolizaSegurosDTO polizaSegurosDTO)
        {
            try
            {
                return await _logica.PutEditarSeguro(id, polizaSegurosDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // Eliminar un seguro por Id
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> EliminarSeguro(int id)
        {
            try
            {
                return await _logica.DeleteEliminarSeguro(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
