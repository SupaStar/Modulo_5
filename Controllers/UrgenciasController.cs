using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Modulo_5.Controllers
{
    public class UrgenciasController : Controller
    {
        // GET: UrgenciasFormularioController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: UrgenciasFormularioController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UrgenciasFormularioController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrgenciasFormularioController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UrgenciasFormularioController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UrgenciasFormularioController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UrgenciasFormularioController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UrgenciasFormularioController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
