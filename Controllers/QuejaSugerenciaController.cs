using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Modulo_5.Models;
using Modulo_5.Services;

namespace Modulo_5.Controllers
{
    public class QuejaSugerenciaController : Controller
    {
        QuejaService _quejaServ;
        SugerenciaService _sugServ;
        private CorreosModel correo;
        private MensajeModel mensaje = new MensajeModel();
        public QuejaSugerenciaController(IConfiguration conf)
        {
            correo = new CorreosModel();
            _quejaServ = new QuejaService(conf);
            _sugServ = new SugerenciaService(conf);
        }

        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Queja()
        {
            List<TipoQueja> tipos = _quejaServ.cargarTipos();
            ViewBag.tipos = tipos.Select(x => new SelectListItem() { Text = x.Nombre, Value = x.Id.ToString() });
            return View("AgregarQueja");
        }
        public IActionResult Sugerencia()
        {
            return View("AgregarSugerencia");
        }
        public ActionResult addQueja(QuejaModel queja)
        {
            if (ModelState.IsValid)
            {
                mensaje = _quejaServ.AddQueja(queja);
                if (mensaje.Estado)
                {
                    correo.Asunto = "Registro de su Queja";
                    correo.Destinatario = queja.Email;
                    correo.Contenido = "Gracias por su queja, puede consultarla en el siguiente link <a href='https://localhost:44381/QuejaSugerencia/VerQuejaUsuario/" + queja.Token + "'>Ver queja</a>";
                    correo.Enviar();
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.errores = mensaje.Detalle;
            }
            List<TipoQueja> tipos = _quejaServ.cargarTipos();
            ViewBag.tipos = tipos.Select(x => new SelectListItem() { Text = x.Nombre, Value = x.Id.ToString() });
            return View("AgregarQueja");
        }
        public ActionResult addSugerencia(SugerenciaModel sugerencia)
        {
            if (ModelState.IsValid)
            {
                _sugServ.AddSugerencia(sugerencia);
                correo.Asunto = "Registro de su Sugerencia";
                correo.Destinatario = sugerencia.Email;
                correo.Contenido = "Gracias por su sugerencia, puede consultarla en el siguiente link <a href='https://localhost:44381/QuejaSugerencia/VerSugerenciaUsuario/" + sugerencia.Token + "'>Ver sugerencia</a>";
                correo.Enviar();
                return RedirectToAction("Index", "Home");
            }
            return View("AgregarSugerencia");
        }
        public ActionResult ValidarSugerencia(int idS, int idE)
        {
            SugerenciaModel sugerencia = _sugServ.validateSugerencia(idS, idE);
            correo.Asunto = "Sugerencia validada";
            correo.Destinatario = sugerencia.Email;
            correo.Contenido = "Gracias por su sugerencia, esta ya fue procesada, puedes verla en el siguiente link <a href='https://localhost:44381/QuejaSugerencia/VerSugerenciaUsuario/" + sugerencia.Token + "'>Ver sugerencia</a>";
            correo.Enviar();
            return RedirectToAction("CerrarPestaña", "Admin");
        }
        public ActionResult VerSugerencia(int id)
        {
            ViewBag.sugerencia = _sugServ.FindSugerencia(id);
            return View("VerS");
        }

        public ActionResult verQueja(int id)
        {
            ViewBag.queja = _quejaServ.FindQueja(id);
            return View("VerQ");
        }
        public ActionResult ValidarQueja(int idQ, int idE)
        {
            QuejaModel queja = _quejaServ.validateQueja(idQ, idE);
            correo.Asunto = "Queja validada";
            correo.Destinatario = queja.Email;
            correo.Contenido = "Gracias por su queja, esta ya fue procesada, puedes verla en el siguiente link <a href='https://localhost:44381/QuejaSugerencia/VerQuejaUsuario/" + queja.Token + "'>Ver queja</a>";
            correo.Enviar();
            return RedirectToAction("CerrarPestaña", "Admin");
        }
        public ActionResult VerSugerenciaUsuario(string id)
        {
            ViewBag.sugerencia = _sugServ.FindSugerenciaByToken(id);
            return View("Usuario/VerSugerencia");
        }
        public ActionResult VerQuejaUsuario(string id)
        {
            ViewBag.queja = _quejaServ.FindQuejaByToken(id);
            return View("Usuario/VerQueja");
        }
    }
}
