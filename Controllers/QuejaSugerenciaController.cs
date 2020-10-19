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

        public QuejaSugerenciaController(IConfiguration conf)
        {
            _quejaServ = new QuejaService(conf);
        }

        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Queja()
        {
            //TODO Rehacer formulario con modelbinding
            List<TipoQueja> tipos = _quejaServ.cargarTipos();
            ViewBag.tipos = tipos.Select(x => new SelectListItem() { Text = x.Nombre, Value = x.Id.ToString() });
            return View("AgregarQueja");
        }
        public IActionResult Sugerencia()
        {
            //TODO Hacer formulario y vista
            return View("AgregarQueja");
        }
        public ActionResult addQueja(QuejaModel queja)
        {
            if (ModelState.IsValid)
            {
                _quejaServ.AddQueja(queja);
            }
            List<TipoQueja> tipos = _quejaServ.cargarTipos();
            ViewBag.tipos = tipos.Select(x => new SelectListItem() { Text = x.Nombre, Value = x.Id.ToString() });
            return View("AgregarQueja");
        }
    }
}
