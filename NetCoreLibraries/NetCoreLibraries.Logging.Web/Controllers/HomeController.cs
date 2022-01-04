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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;   // 1.Log Örneğidir. ILogger da hangi controller da olduğu belirtilir

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogTrace("Index sayfasına girildi");    // Output da görünecektir.
            _logger.LogDebug("Index sayfasına girildi");    // Output da görünecektir.
            _logger.LogInformation("Index sayfasına girildi");    // Output da görünecektir.
            _logger.LogWarning("Index sayfasına girildi");    // Output da görünecektir.
            _logger.LogError("Index sayfasına girildi");    // Output da görünecektir.
            _logger.LogCritical("Index sayfasına girildi");    // Output da görünecektir.
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
