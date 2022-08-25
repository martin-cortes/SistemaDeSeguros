using AutoMapper;
using Domain.Model.DTOs;
using Domain.Model.Entities;
using DrivenAdapters.Sql.Contexts;
using Helpers.Commons.CustomBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UseCase.Logica.PolizaVehiculos;

namespace SistemaDeSeguros.Controllers
{
    [Route("api/polizaVehiculo")]
    [ApiController]
    public class PolizaVehiculosController : ControllerBase
    {
        private readonly IPolizaVehiculoLogica _logica;

        public PolizaVehiculosController(IPolizaVehiculoLogica logica)
        {
            _logica = logica;
        }

        [HttpGet]

        public async Task<ActionResult<List<PolizaVehiculosDTO>>> ObtenerVehiculos()
        {
            try
            {
                return await _logica.GetObtenerVehiculos();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<PolizaVehiculosDTO>> ObtenerVehiculo(int id)
        {
            try
            {
                return await _logica.GetObtenerVehiculo(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<ActionResult> RegistrarVehiculo([FromForm] CreacionPolizaVehiculoDTO creacionPolizaVehiculoDTO)
        {
            try
            {
                return await _logica.PostRegistrarVehiculo(creacionPolizaVehiculoDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> EditarVehiculo(int id, [FromForm] PolizaVehiculosDTO polizaVehiculosDTO)
        {
            try
            {
                return await _logica.PutEditarVehiculo(id, polizaVehiculosDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // Eliminar un seguro por Id
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> EliminarVehiculo(int id)
        {
            try
            {
                return await _logica.DeleteEliminarVehiculo(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
