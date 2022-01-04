using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreLibraries.Logging.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.Logging.Web.Controllers
{
    public class Home1Controller : Controller
    {
        private readonly ILoggerFactory _loggerFactory;   // 1.Log Örneğidir. ILogger da hangi controller da olduğu belirtilir

        public Home1Controller(ILoggerFactory logger)
        {
            _loggerFactory = logger;
        }
        public IActionResult Index()
        {
            var logger = _loggerFactory.CreateLogger("Home Sınıfı");

            logger.LogTrace("Index sayfasına girildi");    // Output da görünecektir.
            logger.LogDebug("Index sayfasına girildi");    // Output da görünecektir.
            logger.LogInformation("Index sayfasına girildi");    // Output da görünecektir.
            logger.LogWarning("Index sayfasına girildi");    // Output da görünecektir.
            logger.LogError("Index sayfasına girildi");    // Output da görünecektir.
            logger.LogCritical("Index sayfasına girildi");    // Output da görünecektir.

            return View();
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
    }
}
