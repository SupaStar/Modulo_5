using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using Modulo_5.Models;
using Modulo_5.Services;

namespace Modulo_5.Controllers
{
    public class UrgenciasController : Controller
    {
        private ILogger _logger;
        private UrgenciasService _service;
        public UrgenciasController(ILogger<UrgenciasController> logger, IConfiguration conf)
        {
            _logger = logger;
            _service = new UrgenciasService(conf);
        }

        public IActionResult Index()
        {
            return View("Nuevo");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UrgenciaModel u)
        {
            if (ModelState.IsValid)
            {
                _service.AddUrgencia(u);
                try
                {
                    var mensaje = new MimeMessage();
                    mensaje.To.Add(new MailboxAddress("Para: ",u.Email));
                    mensaje.From.Add(new MailboxAddress("Modulo de Urgencias", "from@domail.com"));
                    //E-mail subject 
                    mensaje.Subject = "Registro de Urgencias";
                    //E-mail message body
                    mensaje.Body = new TextPart(TextFormat.Html)
                    {
                        
                        Text = "Hola "+ u.Nombre + " Se notifica su registro en la fecha: "+u.FechaNac+" por la descripcion: "+u.Descripcion
                    };

                    //Configure the e-mail
                    using (var emailClient = new SmtpClient())
                    {
                        emailClient.Connect("smtp.gmail.com", 587, false);
                        emailClient.Authenticate("pruebasmodulo5cetis@gmail.com", "Ulisestortuga1");
                        emailClient.Send(mensaje);
                        emailClient.Disconnect(true);
                    }
                }
                catch
                {

                }
                return RedirectToAction("Index", "Home");
            }
            return View("Nuevo");
        }
        public ActionResult Administrador()
        {
            ViewBag.urgencias = _service.GetUrgencias();
            return RedirectToAction("VistaUrgencias", "Admin");
        }
        public ActionResult Editar(int id)
        {
            ViewBag.urgencia = _service.FindUrgencia(id);
            return View();
        }
        public ActionResult Update(UrgenciaModel u)
        {
            return View();
        }
    }
}
