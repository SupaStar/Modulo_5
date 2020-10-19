using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modulo_5.Services;
using Modulo_5.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Modulo_5.Controllers
{
    public class AdminController : Controller
    {
        SesionService _service;
        private UrgenciasService _serviceUrg;
        string sesion;
        public AdminController(IConfiguration conf)
        {
            this._service = new SesionService(conf);
            this._serviceUrg = new UrgenciasService(conf);
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
        
        //TODO hacer vistas para las sugerencias
    }
}
