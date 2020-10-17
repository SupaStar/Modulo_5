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
        string sesion;
        public AdminController(IConfiguration conf)
        {
            this._service = new SesionService(conf);
        }
        public void CargarSesion()
        {
            this.sesion = HttpContext.Session.GetString("_Nombre");
        }
        public IActionResult VistaLogin()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        public IActionResult VistaUrgencias()
        {
            CargarSesion();
            if (this.sesion != null)
            {
                return View("Urgencias");
            }
            return RedirectToAction("VistaLogin","Admin");
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public object IniciarS(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                bool estado = _service.IniciarSesion(usuario);
                if (estado)
                {
                    HttpContext.Session.SetString(usuario.SessionK_Name, usuario.Correo);
                    HttpContext.Session.SetInt32("_Age", 773);
                    return RedirectToAction("VistaUrgencias", "Admin");
                }
                ViewBag.error = "Datos incorrectos";
                return View("Login");
            }else{
                return View("Login");
            }
        }
        public object VerSesion()
        {
            return new { estado = true, detalle = HttpContext.Session.GetString("_Nombre") };
        }
        public object CerrarSesion()
        {
            HttpContext.Session.Clear();
            return new { estado = true, detalle = "Sesion terminada con exito." };
        }
    }
}
