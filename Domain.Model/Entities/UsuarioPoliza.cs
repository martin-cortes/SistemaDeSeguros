using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class UsuarioPoliza
    {
        public int UsuarioPolizaId { get; set; }

        public int PolizaId { get; set; }

        public Usuario Usuario { get; set; }

        public PolizaSeguros PolizaSeguros { get; set; }
    }
}
