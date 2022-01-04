using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.Logging.Web.Controllers
{
    //NLog Example
    public class Home2Controller : Controller
    {
        private readonly ILogger<Home2Controller> _logger;

        public Home2Controller(ILogger<Home2Controller> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            int val1 = 5;
            int val2 = 0;
            int result;

            try
            {
                result = val1 / val2;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }


            _logger.LogInformation("Index sayfası başlamıştır.");
            _logger.LogWarning("Warning Hata.");
            return View();
        }
    }
}
