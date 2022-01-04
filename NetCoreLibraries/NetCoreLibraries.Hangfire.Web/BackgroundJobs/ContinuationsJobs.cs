using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;

namespace NetCoreLibraries.Hangfire.Web.BackgroundJobs
{
    public class ContinuationsJobs
    {
        public static void CreateSecondFileAfterFirstJob(string id)
        {
            BackgroundJob.ContinueJobWith(id, () => ApplyFolder());
        }

        public static void ApplyFolder() // Job içerisinde çalışacak metod public olmalıdır
        {
            File.WriteAllText(Path.Combine(@"C:\Users\emre.akturk\Desktop\Deneme_Hangfire", $"log_Second_Job{Guid.NewGuid().ToString().Substring(0, 10)}.txt"), "1. Job çalıştıktan sonra 2. JOb çalıştı" + Guid.NewGuid());
        }
    }
}
