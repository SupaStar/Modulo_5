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
            ViewBag.areas = _service.getAreas();
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
                    //TODO Mandar boton con token para ver una vista
                    var mensaje = new MimeMessage();
                    mensaje.To.Add(new MailboxAddress("Para: ",u.Email));
                    mensaje.From.Add(new MailboxAddress("Modulo de Urgencias", "from@domail.com"));
                    mensaje.Subject = "Registro de Urgencias";
                    string token = u.Token;
                    mensaje.Body = new TextPart(TextFormat.Html)
                    {
                        //Text = "Hola " + u.Nombre + " Se notifica su registro en la fecha: " + u.Fecha_nac + "<br> <a asp-route-token="+ string.Format(@""+ u.Token + "")+" asp-action='VerCitaPaciente' asp-controller='Urgencias' href=" + string.Format(@"https://localhost:44381/Urgencias/VerCitaPaciente/")+">"+ "Ver Cita"+"</a>"
                        Text = "Hola " + u.Nombre + " Se notifica su registro en la fecha: " + u.Fecha_nac + "<br> <a asp-route-token=" + "31e27d67c1fc0f8d0622f78a5354d175f75844267330d518987d8186da2d0d06" + " asp-action='VerCitaPaciente' asp-controller ='Urgencias'href=" + string.Format(@"https://localhost:44381/Urgencias/VerCitaPaciente/" + u.Token)+">" + "Ver Cita" + "</a>"
                    };
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
            return RedirectToAction("VistaUrgencias", "Admin");
        }
        public ActionResult Editar(int id)
        {
            //TODO terminar formulario
            ViewBag.areas = _service.getAreas();
            ViewBag.urgencia = _service.FindUrgencia(id);
            return View();
        }
        public ActionResult Update(UrgenciaModel u)
        {
            if (ModelState.IsValid)
            {

            }
            return View("Editar");
        }
        public ActionResult Eliminar(int id)
        {
            _service.DeleteUrgencia(id);
            return RedirectToAction("VistaUrgencias", "Admin");
        }
        public ActionResult VerCitaPaciente (string token)
        {
           ViewBag.urgencia = _service.ViewUrgencia(token);
            
            return View();
             
        }
        
    }
}
