using Hangfire;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.Hangfire.Web.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string CreateFolder(string text)
        {
          return  BackgroundJob.Schedule(() => ApplyFolder(text),TimeSpan.FromSeconds(30));  // 30 saiye sonra ApplyFolder() metodu çalışacak
        }
        public static void ApplyFolder(string text) // Job içerisinde çalışacak metod public olmalıdır
        {
            File.WriteAllText(Path.Combine(@"C:\Users\emre.akturk\Desktop\Deneme_Hangfire", $"log_{Guid.NewGuid().ToString().Substring(0, 10)}.txt"), text + Guid.NewGuid());
        }
    }
}
