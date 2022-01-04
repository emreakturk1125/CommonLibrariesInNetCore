using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using NetCoreLibraries.Hangfire.Web.Services;

namespace NetCoreLibraries.Hangfire.Web.BackgroundJobs
{
    public class FireAndForgetJobs
    {
        public static void CreateFile(string message)
        {
            BackgroundJob.Enqueue<ICreateFolder>(x => x.CreateFile(message));
        }
    }
}
