using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public UrgenciasController(ILogger<UrgenciasController> logger, IConfiguration conf)
        {
            _logger = logger;
            _service = new UrgenciasService(conf);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UrgenciaModel u)
        {
            if (ModelState.IsValid)
            {
                _service.AddUrgencia(u);
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }
        public ActionResult Administrador()
        {
            ViewBag.urgencias = _service.GetUrgencias();
            return RedirectToAction("VistaUrgencias", "Admin");
        }
        public ActionResult Editar(int id)
        {
            ViewBag.urgencia = _service.FindUrgencia(id);
            return View();
        }
        public ActionResult Update(UrgenciaModel u)
        {
            return View();
        }
    }
}
