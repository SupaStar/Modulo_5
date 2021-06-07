using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Modulo_5.Models;
using System.Diagnostics;

namespace Modulo_5.Controllers
{
    public class HomeController : Controller
    {
        public Rot13 encriptar = new Rot13();
        public HomeController()
        {
        }

        public void Index()
        {
            encriptar.imprimir();
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
