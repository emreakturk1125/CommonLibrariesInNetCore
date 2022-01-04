using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;

namespace NetCoreLibraries.Hangfire.Web.BackgroundJobs
{
    public class ReccuringJobs
    {
        public static void CreateFolder(string text)
        {
            RecurringJob.AddOrUpdate("reposrtJob1", () => ApplyFolder(text), Cron.Minutely);   // Cron formatı tarihi * lı şekilde yazmaya yarar, burada ApplyFolder() metodunun hangi sıklıkla çalışacağını belirttik
        }
        public static void ApplyFolder(string text)  // Job içerisinde çalışacak metod public olmalıdır
        {
            File.WriteAllText(Path.Combine(@"C:\Users\emre.akturk\Desktop\Deneme_Hangfire", $"log_{Guid.NewGuid().ToString().Substring(0, 10)}.txt"), text + Guid.NewGuid());
        }
    }
}
