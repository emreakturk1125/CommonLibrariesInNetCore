using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smidge;
using Smidge.Options;
using Smidge.Cache;

namespace NetCoreLibraries.Smidge.Web
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
            services.AddSmidge(Configuration.GetSection("smidge"));
            services.AddControllersWithViews();
        }
         
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); 
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Smide Kütüphanesi için üst sıralara koyarsan hata verebilir aklında olsun 
            app.UseSmidge(bundle =>
            {
                //bundle.CreateJs("my-js-bundle", "~/js/site.js", "~/js/site2.js");

                // js ya da css dosyaları aynı klasörde ise bu şekilde de yapabilirsin
                bundle.CreateJs("my-js-bundle", "~/js/")
                .WithEnvironmentOptions(BundleEnvironmentOptions.Create()
                .ForDebug(builder => builder.EnableCompositeProcessing()  
                .EnableFileWatcher()  // Dosyada değişiklik var mı diye izler
                .SetCacheBusterType<AppDomainLifetimeCacheBuster>()    // Uygulama her ayağa kalktığında cache sıfırlamak içindir
                .CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0)).Build());

                bundle.CreateCss("my-css-bundle", "~/css/site.css", "~/lib/bootstrap/dist/css/bootstrap.min.css");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
