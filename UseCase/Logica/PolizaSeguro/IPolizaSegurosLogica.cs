using Domain.Model.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Logica.PolizaSeguro
{
    public interface IPolizaSegurosLogica
    {
        Task<ActionResult<List<PolizaSegurosDTO>>> GetObtenerSeguros();
        Task<ActionResult<PolizaSegurosDTO>> GetObtenerSeguro(int id);
        Task<ActionResult> PostRegistrarSeguro(CreacionPolizaSegurosDTO creacionPolizaSegurosDTO);
        Task<ActionResult> PutEditarSeguro(int id, PolizaSegurosDTO polizaSegurosDTO);
        Task<ActionResult> DeleteEliminarSeguro(int id);
    }
}
