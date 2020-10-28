using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Modulo_5.Models;
using Modulo_5.Services;

namespace Modulo_5.Controllers
{
    public class UrgenciasController : Controller
    {
        private ILogger _logger;
        private UrgenciasService _service;
        private CorreosModel correo;
        public UrgenciasController(ILogger<UrgenciasController> logger, IConfiguration conf)
        {
            correo = new CorreosModel();
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
                correo.Asunto = "Registro urgencia";
                correo.Destinatario = u.Email;
                correo.Contenido = "Hola " + u.Nombre + " Se notifica su registro en la fecha: " + u.Fecha_nac + "<br><a href='https://localhost:44381/Urgencias/VerCitaPaciente/" + u.Token + "'>Ver Cita</a>";
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
            //TODO terminar formulario
            ViewBag.areas = _service.getAreas();
            ViewBag.empleados = _service.getEmpleados();

            ViewBag.urgencia = _service.FindUrgencia(id);
            return View();
        }
        public ActionResult Update(int id,UrgenciaModel u)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateUrgencia(id,u);
                return RedirectToAction("Index", "Home");
            }
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
            correo.Asunto = "Urgencia aceptada";
            correo.Destinatario = urgencia.Email;
            correo.Contenido = "Hola " + urgencia.Nombre + " Se notifica que su urgencia fue aceptada, ver en el siguiente link:<a href='https://localhost:44381/Urgencias/VerCitaPaciente/" + urgencia.Token + "'>Ver Cita</a>";
            correo.Enviar();
            return RedirectToAction("VistaSugerencias", "Admin");
        }
    }
}
