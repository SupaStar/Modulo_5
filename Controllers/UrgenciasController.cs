using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modulo_5.Models;
using Modulo_5.Services;

namespace Modulo_5.Controllers
{
    public class UrgenciasController : Controller
    {

#pragma warning disable S125 // Sections of code should not be commented out
        //private static string url = "https://localhost:44381";
        private static string url = "https://webappm5.azurewebsites.net";
#pragma warning restore S125 // Sections of code should not be commented out
        private readonly UrgenciasService _service;
        private readonly CorreosModel correo;
        private readonly PacienteService _pacienteS = new PacienteService();
        public UrgenciasController(IConfiguration conf)
        {
            correo = new CorreosModel();
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
                correo.Asunto = "Registro urgencia";
                correo.Destinatario = u.Email;
                correo.Contenido = "Hola " + u.Nombre + " Se notifica su registro en la fecha: " + u.FechaCita + "<br><a href='" + url + "/Urgencias/VerCitaPaciente/" + u.Token + "'>Ver Cita</a>";
                correo.Enviar();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.areas = _service.getAreas();
            return View("Nuevo");
        }
        public ActionResult Administrador()
        {
            return RedirectToAction("VistaUrgencias", "Admin");
        }
        public ActionResult Editar(int id)
        {
            ViewBag.areas = _service.getAreas();
            ViewBag.empleados = _service.getEmpleados();
            ViewBag.urgencia = _service.FindUrgencia(id);
            return View();
        }
        public ActionResult Update(UrgenciaModel u)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateUrgencia(u.Id, u);
                _service.validateUrgencia(u.Id, u.IdMedico);
                return RedirectToAction("ValidarUrgencia", "Urgencias", new { idU = u.Id, idE = u.IdMedico });
            }
            ViewBag.areas = _service.getAreas();
            ViewBag.empleados = _service.getEmpleados();
            ViewBag.urgencia = _service.FindUrgencia(u.Id);
            return View("Editar");
        }
        public ActionResult Eliminar(int id)
        {
            _service.DeleteUrgencia(id);
            return RedirectToAction("VistaUrgencias", "Admin");
        }
        public ActionResult VerCitaPaciente(string id)
        {
            ViewBag.urgencia = _service.ViewUrgencia(id);
            return View();
        }
        public ActionResult ValidarUrgencia(int idU, int idE)
        {
            UrgenciaModel urgencia = _service.validateUrgencia(idU, idE);
            //correo.Asunto = "Urgencia aceptada";
            //correo.Destinatario = urgencia.Email;
            //correo.Contenido = "Hola " + urgencia.Nombre + " Se notifica que su urgencia fue aceptada, ver en el siguiente link:<a href='" + url + "/Urgencias/VerCitaPaciente/" + urgencia.Token + "'>Ver Cita</a>";
            //correo.Enviar();
            PacienteModel paciente = _pacienteS.addPaciente(urgencia.Id);
            return RedirectToAction("newEstancia", "Admin", new { id = paciente.id });
        }
    }
}
