﻿using System;
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
        SugerenciaService _sugServ;
        private MensajeModel mensaje = new MensajeModel();
        public QuejaSugerenciaController(IConfiguration conf)
        {
            _quejaServ = new QuejaService(conf);
            _sugServ = new SugerenciaService(conf);
        }

        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Queja()
        {
            List<TipoQueja> tipos = _quejaServ.cargarTipos();
            ViewBag.tipos = tipos.Select(x => new SelectListItem() { Text = x.Nombre, Value = x.Id.ToString() });
            return View("AgregarQueja");
        }
        public IActionResult Sugerencia()
        {
            return View("AgregarSugerencia");
        }
        public ActionResult addQueja(QuejaModel queja)
        {
            if (ModelState.IsValid)
            {
                mensaje = _quejaServ.AddQueja(queja);
                if (mensaje.Estado)
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.errores = mensaje.Detalle;
            }
            List<TipoQueja> tipos = _quejaServ.cargarTipos();
            ViewBag.tipos = tipos.Select(x => new SelectListItem() { Text = x.Nombre, Value = x.Id.ToString() });
            return View("AgregarQueja");
        }
        public ActionResult addSugerencia(SugerenciaModel sugerencia)
        {
            if (ModelState.IsValid)
            {
                _sugServ.AddSugerencia(sugerencia);
                //TODO Mandar correo con el token
                return RedirectToAction("Index", "Home");
            }
            return View("AgregarSugerencia");
        }
        public ActionResult ValidarSugerencia(int idS, int idE)
        {
            _sugServ.validateSugerencia(idS, idE);
            //TODO Mandar correo confirmacion
            return RedirectToAction("VistaSugerencias", "Admin");
        }
        public ActionResult VerSugerencia(int id)
        {
            ViewBag.sugerencia = _sugServ.FindSugerencia(id);
            return View("VerS");
        }
        public ActionResult verQueja(int id)
        {
            ViewBag.queja = _quejaServ.FindQueja(id);
            return View("VerQ");
        }
        public ActionResult ValidarQueja(int idQ, int idE)
        {
            _quejaServ.validateQueja(idQ, idE);
            //TODO Mandar correo confirmacion
            return RedirectToAction("VistaSugerencias", "Admin");
        }
    }
}
