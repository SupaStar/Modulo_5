using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;

namespace Modulo_5.Models
{
    public class CorreosModel
    {
        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string Contenido { get; set; }

        private static string Correo = "pruebasmodulo5cetis@gmail.com";
        private static readonly string Password = "Ulisestortuga1";
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
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex);
            }
        }
    }
}
