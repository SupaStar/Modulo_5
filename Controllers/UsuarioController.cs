using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modulo_5.Models;
using Modulo_5.Services;
using Microsoft.AspNetCore.Http;

namespace Modulo_5.Controllers
{
    public class UsuarioController : Controller
    {
        Encriptador enc = new Encriptador();
        UsuarioPacienteService _usuario = new UsuarioPacienteService();
        EstanciaService _paciente = new EstanciaService();
        OperacionService _operaciones = new OperacionService();
        ObservacionesService _observaciones = new ObservacionesService();
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult IniciarS(IFormCollection usuario)
        {
            UsuariosPacienteModel usu = new UsuariosPacienteModel();
            usu.usuario = usuario["usuario"];
            usu.password = enc.Hashing(usuario["password"]);
            usu = _usuario.login(usu);
            if (usu != null)
            {
                ViewBag.datos = _paciente.findEstancia(usu.id_estancia);
                ViewBag.operaciones = _operaciones.getOperaciones(usu.id_estancia);
                ViewBag.observaciones = _observaciones.getObservacionesEstancia(usu.id_estancia);
                return View("Datos");
            }
            return RedirectToAction("Login", "Usuario");
        }
    }
}
