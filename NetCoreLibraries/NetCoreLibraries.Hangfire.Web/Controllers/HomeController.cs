using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreLibraries.Hangfire.Web.BackgroundJobs;
using NetCoreLibraries.Hangfire.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.Hangfire.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        // *********** FireAndForget job **********     
        //  Mesaj kuyruk sistemi gibi çalışıyor
        public IActionResult SignUp()
        {
            // Üye kayıt metodu
            // Yeni üye olan kullanıcının user Id sini al
            // kayıttan sonra mail atmak istersen uygulayabilirsin, ben burada klasör oluşturdum

            FireAndForgetJobs.CreateFile("(FireAndForgetJob) www.mysite.com ");
            return View();
        }

        public IActionResult PictureSave()
        {
            return View();
        }

        // *********** Delayed job **********
        //  Mesaj kuyruk sistemi gibi çalışıyor
        [HttpPost]
        public IActionResult  PictureSave(IFormFile picture)
        {

            // Resim kayıt ettikten sonra hangfire ile oluşturacağın bir job ile ileri zamanlı olarak resimler üzerinde değişiklik yapıp farklı bir klasöre kaydedebilirsin, ben burada klasör oluşturdum
            // Avantajı belki resimde yapılacak değişikilkler uzun sürebilir, kullanıcıyı bekletmemek adına arka tarafta otomatik yapsın demektir.
            // Daha kısa süre de cevap dönmek için

            string jobId = DelayedJobs.CreateFolder("(DelayedJobs) www.mysite.com ");
            return View();
        }

        // *********** Reccuring job **********
        //  Windows task scheduler gibi çalışır. Belli aralıklarla çalışmasını istediğin durumlar için 
        public IActionResult CreateFolder()
        { 
            ReccuringJobs.CreateFolder("(Reccuring) www.mysite.com ");
            return View();
        }

        // *********** Continuations job **********
        //  Windows task scheduler gibi çalışır. Herhangbir job çalıştıktan sonra 2. bir job çalışmasını istiyorsan eğer bunu kullanırsın
        public IActionResult CreateFolderWithSecondJob()
        {
            string jobId = DelayedJobs.CreateFolder("(DelayedJobs) www.mysite.com ");  //  CreateFolderWithSecondJob() metodu çalıştıktan 30 saniye sonra CreateFolder() metodu çalışacak
            ContinuationsJobs.CreateSecondFileAfterFirstJob(jobId);                    // Ardından üstten gelen job id'ye göre CreateSecondFileAfterFirstJob() job ı çalışacak
            return View();
        }
    }
}
