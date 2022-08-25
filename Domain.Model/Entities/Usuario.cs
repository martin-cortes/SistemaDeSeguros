using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Usuario : IId
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaNacimineto { get; set; }

        [Required]
        public int Celular { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool UsuarioActivo { get; set; }

        public List<UsuarioPoliza> UsuarioPolizas { get; set; }

        public List<UsuarioVehiculo> UsuarioVehiculo { get; set; }
    }
}
