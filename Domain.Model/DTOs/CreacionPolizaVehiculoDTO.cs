using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.DTOs
{
    public class CreacionPolizaVehiculoDTO
    {
        public string MarcaVehiculo { get; set; }

        public string ColorVehiculo { get; set; }

        public string Linea { get; set; }

        public bool VehiculoActivo { get; set; }
    }
}
