using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class PolizaVehiculo : IId
    {
        [Key]
        public int Id { get; set; }

        public string MarcaVehiculo { get; set; }

        public string ColorVehiculo { get; set; }

        public string Linea { get; set; }

        public bool VehiculoActivo { get; set; }

        public List<UsuarioVehiculo> UsuarioVehiculo { get; set; }
    }
}
