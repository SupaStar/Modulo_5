﻿using Microsoft.AspNetCore.Mvc;

namespace Modulo_5.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/handle/{errorCode}")]
        public IActionResult Handle(int errorCode)
        {
            ViewBag.error = errorCode.ToString();
            return View("~/Views/Shared/ErrorO.cshtml");
        }
    }
}
