using AutoMapper;
using Domain.Model.DTOs;
using Domain.Model.Entities;
using DrivenAdapters.Sql.Contexts;
using Helpers.Commons.CustomBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Logica.PolizaVehiculos
{
    public class PolizaVehiculoLogica : CustomBaseController, IPolizaVehiculoLogica
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PolizaVehiculoLogica(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<PolizaVehiculosDTO>>> GetObtenerVehiculos()
        {
            try
            {
                return await Get<PolizaVehiculo, PolizaVehiculosDTO>();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult<PolizaVehiculosDTO>> GetObtenerVehiculo(int id)
        {
            try
            {
                return await GetId<PolizaVehiculo, PolizaVehiculosDTO>(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> PostRegistrarVehiculo([FromForm] CreacionPolizaVehiculoDTO creacionPolizaVehiculoDTO)
        {
            try
            {
                return await Post<CreacionPolizaVehiculoDTO, PolizaVehiculo>(creacionPolizaVehiculoDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> PutEditarVehiculo(int id, [FromForm] PolizaVehiculosDTO polizaVehiculosDTO)
        {
            try
            {
                bool existeVehiculo = await _context.PolizaVehiculos.AnyAsync(x => x.Id == id);

                if (!existeVehiculo)
                {
                    return BadRequest($"El ID ingresado no esta registrado en la base de datos");
                }
                else
                {
                    return await Put<PolizaVehiculosDTO, PolizaVehiculo>(id, polizaVehiculosDTO);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> DeleteEliminarVehiculo(int id)
        {
            try
            {
                bool existeVehiculo = await _context.PolizaVehiculos.AnyAsync(x => x.Id == id);

                if (!existeVehiculo)
                {
                    return BadRequest($"El ID ingresado no esta registrado en la base de datos");
                }
                else
                {
                    return await Delete<PolizaVehiculo>(id);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
