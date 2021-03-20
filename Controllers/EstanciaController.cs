using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modulo_5.Models;
using Modulo_5.Services;

namespace Modulo_5.Controllers
{
    public class EstanciaController : Controller
    {
        private readonly PacienteService _pacienteS = new PacienteService();
        private readonly EstanciaService _estancia = new EstanciaService();
        private readonly UsuarioPacienteService _usuario_paciente = new UsuarioPacienteService();
        public IActionResult Index(int idP)
        {
            PacienteModel paciente = _pacienteS.findPaciente(idP);
            ViewBag.paciente = paciente;
            return View();
        }
        public IActionResult Create(EstanciaModel estancia)
        {
            estancia=_estancia.addEstancia(estancia);
            _usuario_paciente.addUsuario(estancia.id);
            return RedirectToAction("CerrarPestannia", "Admin");
        }
    }
}
