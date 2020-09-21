using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Modulo_5.Controllers
{
    public class QuejasController : Controller
    {
        // GET: QuejasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuejasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuejasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuejasController/Create
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

        // GET: QuejasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuejasController/Edit/5
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

        // GET: QuejasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuejasController/Delete/5
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
