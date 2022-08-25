using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class UsuarioVehiculo
    {
        public int UsuarioVehiculoId { get; set; }

        public int VehiculoId { get; set; }

        public Usuario Usuario { get; set; }

        public PolizaVehiculo PolizaVehiculo { get; set; }
    }
}
