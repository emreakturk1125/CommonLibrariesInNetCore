using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.RateLimit.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
         
        public void ConfigureServices(IServiceCollection services)
        {

            // *************** RATE LIMIT - START *******************

            #region IP Rate Limit için

            //services.AddOptions();
            //services.AddMemoryCache(); // Hangi endpoint'e kaç istek yapılmış bunu okuyabilmek için
            //services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            //services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));
            //services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();  //Monolitic uygulamalarda cache memory üzerinden yapabilirsin.  Fakat microseris mimarisi olan yerlerde Distributed cache üzerinden yapılmalıdır.
            //services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();  // Gelen istekler ile alakalı header bilgileri almak için
            //services.AddSingleton<IRateLimitConfiguration,RateLimitConfiguration>();
            //services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

            #endregion

            #region CLient Rate Limit için

            services.AddOptions();
            services.AddMemoryCache(); // Hangi endpoint'e kaç istek yapılmış bunu okuyabilmek için
            services.Configure<ClientRateLimitOptions>(Configuration.GetSection("ClientRateLimiting"));
            services.Configure<ClientRateLimitPolicies>(Configuration.GetSection("ClientRateLimitPolicies"));
            services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();  //Monolitic uygulamalarda cache memory üzerinden yapabilirsin.  Fakat microseris mimarisi olan yerlerde Distributed cache üzerinden yapılmalıdır.
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();  // Gelen istekler ile alakalı header bilgileri almak için
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

            #endregion

            // *************** RATE LIMIT - END *******************

            services.AddControllers();
        }
         
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseIpRateLimiting();   // IP RateLimit için

            app.UseClientRateLimiting(); // Client RateLimit için

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
