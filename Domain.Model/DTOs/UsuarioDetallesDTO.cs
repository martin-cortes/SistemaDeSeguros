using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.DTOs
{
    public class UsuarioDetallesDTO : UsuarioDTO
    {
        public List<PolizaSegurosDTO> PolizaSeguros { get; set; }

        public List<PolizaVehiculosDTO> polizaVehiculosDTO { get; set; }
    }
}
