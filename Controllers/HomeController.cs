using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modulo_5.Models;
using System.Diagnostics;

namespace Modulo_5.Controllers
{
    public class HomeController : Controller
    {
        public Encriptador encriptar = new Encriptador();
        public HomeController()
        {
        }

        public void Index()
        {
            
            encriptar.crearLlave();
            encriptar.Hashing("prueba pepe");
            encriptar.DeHashing("fz7ia49fifi");

            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
