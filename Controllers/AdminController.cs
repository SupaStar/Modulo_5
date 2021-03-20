using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modulo_5.Models;
using Modulo_5.Services;

namespace Modulo_5.Controllers
{
    public class AdminController : Controller
    {
        readonly SesionService _service;
        private readonly UrgenciasService _serviceUrg;
        private readonly SugerenciaService _serviceSug;
        private readonly QuejaService _serviceQue;
        private readonly PacienteService _pacientes = new PacienteService();
        private readonly EstanciaService _estancias = new EstanciaService();
        string sesion;
        public AdminController(IConfiguration conf)
        {
            this._service = new SesionService(conf);
            this._serviceUrg = new UrgenciasService(conf);
            this._serviceSug = new SugerenciaService(conf);
            this._serviceQue = new QuejaService(conf);
        }
        public void CargarSesion()
        {
            UsuarioModel usu = new UsuarioModel();
            this.sesion = HttpContext.Session.GetString(usu.SessionK_Name);
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public object IniciarS(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                bool estado = _service.IniciarSesion(usuario);
                if (estado)
                {
                    HttpContext.Session.SetString(usuario.SessionK_Name, usuario.Id.ToString());
                    HttpContext.Session.SetInt32("_Age", 773);
                    return RedirectToAction("VistaUrgencias", "Admin");
                }
                ViewBag.error = "Datos incorrectos";
                return View("Login");
            }
            else
            {
                return View("Login");
            }
        }
        public object VerSesion()
        {
            UsuarioModel usu = new UsuarioModel();
            return new { estado = true, detalle = HttpContext.Session.GetString(usu.SessionK_Name) };
        }
        public object CerrarSesion()
        {
            HttpContext.Session.Clear();
            return new { estado = true, detalle = "Sesion terminada con exito." };
        }

        //Vistas
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        public IActionResult VistaUrgencias()
        {
            CargarSesion();
            if (this.sesion != null)
            {
                ViewBag.urgencias = _serviceUrg.GetUrgencias();
                return View("Urgencias");
            }
            return RedirectToAction("Login", "Admin");
        }
        public IActionResult VistaEditarUrgencia(int id)
        {
            CargarSesion();
            if (this.sesion != null)
            {
                return RedirectToAction("Editar", "Urgencias", new { id });
            }
            return RedirectToAction("Login", "Admin");
        }
        public IActionResult VistaSugerencias()
        {
            CargarSesion();
            if (this.sesion != null)
            {
                ViewBag.sugerencias = _serviceSug.GetSugerencias();
                return View("Sugerencias");
            }
            return RedirectToAction("Login", "Admin");
        }
        public IActionResult ValidarSugerencia(int id)
        {
            CargarSesion();
            if (this.sesion != null)
            {
                return RedirectToAction("ValidarSugerencia", "QuejaSugerencia", new { idS = id, idE = sesion });
            }
            return RedirectToAction("Login", "Admin");
        }
        public IActionResult VistaQuejas()
        {
            CargarSesion();
            if (this.sesion != null)
            {
                ViewBag.quejas = _serviceQue.GetQuejas();
                return View("Quejas");
            }
            return RedirectToAction("Login", "Admin");
        }
        public IActionResult ValidarQueja(int id)
        {
            CargarSesion();
            if (this.sesion != null)
            {
                return RedirectToAction("ValidarQueja", "QuejaSugerencia", new { idQ = id, idE = sesion });
            }
            return RedirectToAction("Login", "Admin");
        }
        public IActionResult ValidarUrgencia(int id)
        {
            CargarSesion();
            if (this.sesion != null)
            {
                return RedirectToAction("ValidarUrgencia", "Urgencias", new { idU = id, idE = sesion });
            }
            return RedirectToAction("Login", "Admin");
        }
        public IActionResult CerrarPestannia()
        {
            return View("Cerrar");
        }
        public IActionResult newEstancia(int id)
        {
            CargarSesion();
            if (this.sesion != null)
            {
                return RedirectToAction("Index", "Estancia", new { idP = id });
            }
            return RedirectToAction("Login", "Admin");
        }
        public IActionResult Pacientes()
        {
            CargarSesion();
            if (this.sesion != null)
            {
                ViewBag.estancias = _estancias.getEstancias();
                return View();
            }
            return RedirectToAction("Login", "Admin");
        }
        public IActionResult Observaciones(int id)
        {
            CargarSesion();
            if (this.sesion != null)
            {
                return RedirectToAction("Index", "Observacion",new { idE = id });
            }
            return RedirectToAction("Login", "Admin");
        }
    }
}
