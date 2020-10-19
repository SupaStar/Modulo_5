using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Modulo_5.Controllers
{
    public class QuejaSugerenciaController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Queja()
        {
            //TODO Rehacer formulario con modelbinding
            return View("AgregarQueja");
        }
        public IActionResult Sugerencia()
        {
            //TODO Hacer formulario y vista
            return View("AgregarQueja");
        }
    }
}
