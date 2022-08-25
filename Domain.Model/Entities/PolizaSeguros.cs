using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class PolizaSeguros : IId
    {
        [Key]
        public int Id { get; set; }

        public string NombrePoliza { get; set; }

        public DateTime FechaCompra { get; set; }

        public int TarifaPoliza { get; set; }

        public List<UsuarioPoliza> UsuarioPolizas { get; set; }
    }
}
