using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modulo_5.Models;
using Modulo_5.Services;

namespace Modulo_5.Controllers
{
    public class ObservacionModelsController : Controller
    {
        private readonly ObservacionesService _service;

        public ObservacionModelsController(ObservacionesService service)
        {
            _service = service;
        }

        // GET: ObservacionModels
        public async Task<IActionResult> Index()
        {
            return View(_service.getObservaciones());
        }

        // GET: ObservacionModels/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var observacionModel = _service.findObservacion(id);
            if (observacionModel == null)
            {
                return NotFound();
            }

            return View(observacionModel);
        }

        // GET: ObservacionModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObservacionModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,id_estancia,diagnostico,observaciones,receta")] ObservacionModel observacionModel)
        {
            if (ModelState.IsValid)
            {
                _service.addObservacion(observacionModel);
                return RedirectToAction(nameof(Index));
            }
            return View(observacionModel);
        }

        // GET: ObservacionModels/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var observacionModel = _service.findObservacion(id);
            if (observacionModel == null)
            {
                return NotFound();
            }
            return View(observacionModel);
        }

        // POST: ObservacionModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,id_estancia,diagnostico,observaciones,receta")] ObservacionModel observacionModel)
        {
            if (id != observacionModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.updateObservacion(observacionModel);
                return RedirectToAction(nameof(Index));
            }
            return View(observacionModel);
        }
    }
}
