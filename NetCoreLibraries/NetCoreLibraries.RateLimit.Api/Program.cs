using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.RateLimit.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Ip Rate Limit için 
            //var webhost = CreateHostBuilder(args).Build();

            //var IpPolicy = webhost.Services.GetRequiredService<IIpPolicyStore>();

            //IpPolicy.SeedAsync().Wait(); // appsetting.json içindeki kuralları uygulayacak

            //webhost.Run(); 
            #endregion

            #region Client Rate Limit için 

            CreateHostBuilder(args).Build().Run();

            #endregion
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
