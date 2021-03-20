using Microsoft.AspNetCore.Mvc;
using Modulo_5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modulo_5.Models;

namespace Modulo_5.Controllers
{
    public class ObservacionController : Controller
    {
        private readonly ObservacionesService _observaciones = new ObservacionesService();
        private readonly EstanciaService _estancia = new EstanciaService();
        public IActionResult Index(int idE)
        {
            ViewBag.observaciones = _observaciones.getObservacionesEstancia(idE);
            ViewBag.estancia = _estancia.findEstancia(idE);
            return View();
        }
        public IActionResult Create(ObservacionModel observacion)
        {
            if (ModelState.IsValid)
            {
                _observaciones.addObservacion(observacion);
                return RedirectToAction("Observaciones", "Admin", new { id = observacion.id_estancia });
            }
            return View("Nuevo");
        }
    }
}
