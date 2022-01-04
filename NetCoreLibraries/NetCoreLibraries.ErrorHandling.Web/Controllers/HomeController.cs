using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreLibraries.ErrorHandling.Web.Filter;
using NetCoreLibraries.ErrorHandling.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.ErrorHandling.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[CustomHandleExceptionFilter(ErrorPage = "Hata1")]  -> Uygulama bazında hataya çevirdik
        public IActionResult Index()
        {
            int val1 = 5;
            int val2 = 0;

            int result = val1 / val2;

            return View();
        }

        //[CustomHandleExceptionFilter(ErrorPage = "Hata2")] -> Uygulama bazında hataya çevirdik
        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();   // Uygulamanın herhangibir yerinde meydana gelen hatayı yakaladık
            ViewBag.Path = exception.Path;
            ViewBag.Message = exception.Error.Message;
            return View();
        }

        public IActionResult Hata1()
        { 
            return View();
        }

        public IActionResult Hata2()
        {
            return View();
        }
    }
}
