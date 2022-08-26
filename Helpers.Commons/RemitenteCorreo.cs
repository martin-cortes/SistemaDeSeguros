using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Commons
{
    public class RemitenteCorreo
    {
        protected string _emailOrigen { get; set; }

        protected string _emailDestino { get; set; }

        protected string _contraseña { get; set; }

        protected string _asunto { get; set; }

        protected string _cuerpo { get; set; }

        public RemitenteCorreo(string emailOrigen, string emailDestino, string contraseña, string asunto, string cuerpo)
        {
            _emailOrigen = emailOrigen;
            _emailDestino = emailDestino;
            _contraseña = contraseña;
            _asunto = asunto;
            _cuerpo = cuerpo;
        }

        public void EnviarCorreo()
        {
            try
            {
                MailMessage mailMessage = new MailMessage(_emailOrigen, _emailDestino, _asunto, _cuerpo);

                mailMessage.IsBodyHtml = false;

                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");

                smtpClient.EnableSsl = true;

                smtpClient.UseDefaultCredentials = false;

                //smtpClient.Host = "smtp.gmail.com";

                smtpClient.Port = 587;

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.Credentials = new System.Net.NetworkCredential(_emailOrigen, _contraseña);

                smtpClient.Send(mailMessage);

                //smtpClient.Dispose();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
