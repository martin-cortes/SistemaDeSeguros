using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.General
{
    public class Message
    {
        private string _cuerpo { get; set; } = "Gracias por registrarse en Sistema De Seguros ;)";

        private string _asunto { get; set; } = "Reguistro Exitoso";

        public Message(string cuerpo, string asunto)
        {
            _cuerpo = cuerpo;
            _asunto = asunto;   
            
        }

        public string Cuerpo(string respuesta)
        {
            respuesta = _cuerpo;
            return respuesta;
        }




    }
}
