using Microsoft.AspNetCore.Mvc;
using Modulo_5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modulo_5.Models;

namespace Modulo_5.Controllers
{
    public class OperacionController : Controller
    {
        private readonly OperacionService _operaciones = new OperacionService();
        private readonly EstanciaService _estancia = new EstanciaService();
        public IActionResult Index(int idE)
        {
            ViewBag.operaciones = _operaciones.getOperaciones(idE);
            ViewBag.estancia = _estancia.findEstancia(idE);
            return View();
        }
        public IActionResult Create(OperacionModel op)
        {
            if (ModelState.IsValid)
            {
                _operaciones.addOperacion(op);
                return RedirectToAction("Operaciones", "Admin", new { id = op.id_estancia });
            }
            return View("Index");
        }
    }
}
