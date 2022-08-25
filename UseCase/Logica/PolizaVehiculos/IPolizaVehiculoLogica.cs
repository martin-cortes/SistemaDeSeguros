using Domain.Model.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Logica.PolizaVehiculos
{
    public interface IPolizaVehiculoLogica
    {
        Task<ActionResult<List<PolizaVehiculosDTO>>> GetObtenerVehiculos();
        Task<ActionResult<PolizaVehiculosDTO>> GetObtenerVehiculo(int id);
        Task<ActionResult> PostRegistrarVehiculo([FromForm] CreacionPolizaVehiculoDTO creacionPolizaVehiculoDTO);
        Task<ActionResult> PutEditarVehiculo(int id, [FromForm] PolizaVehiculosDTO polizaVehiculosDTO);
        Task<ActionResult> DeleteEliminarVehiculo(int id);
    }
}
