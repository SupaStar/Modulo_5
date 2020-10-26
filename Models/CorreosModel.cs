using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class CorreosModel
    {
        public string Contenido;
        public string Destinatario;
        public string Asunto;
        private static string Correo= "pruebasmodulo5cetis@gmail.com";
        private static string Password= "Ulisestortuga1";
        public void Enviar()
        {
            try
            {
                var mensaje = new MimeMessage();
                mensaje.To.Add(new MailboxAddress("Para: ", Destinatario));
                mensaje.From.Add(new MailboxAddress("Modulo de Urgencias", "from@domail.com"));
                mensaje.Subject = Asunto;
                mensaje.Body = new TextPart(TextFormat.Html)
                {
                    Text = Contenido
                };
                using (var emailClient = new SmtpClient())
                {
                    emailClient.Connect("smtp.gmail.com", 587, false);
                    emailClient.Authenticate(Correo, Password);
                    emailClient.Send(mensaje);
                    emailClient.Disconnect(true);
                }
            }
            catch
            {

            }
        }
    }
}
