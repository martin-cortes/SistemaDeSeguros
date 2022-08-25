using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.DTOs
{
    public class CreacionPolizaSegurosDTO
    {
        public string NombrePoliza { get; set; }

        public DateTime FechaCompra { get; set; }

        public int TarifaPoliza { get; set; }
    }
}
