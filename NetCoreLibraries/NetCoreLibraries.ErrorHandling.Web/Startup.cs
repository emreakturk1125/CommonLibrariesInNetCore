using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreLibraries.ErrorHandling.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.ErrorHandling.Web
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
            services.AddControllersWithViews();
            services.AddMvc(options =>
            {
                options.Filters.Add(new CustomHandleExceptionFilterAttribute() { ErrorPage = "Hata1" });  // Uygulama bazında hataları Hata1 sayfasında yönlendirmiş olduk
            });
        }
         
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
                // 1. Yol
                //app.UseStatusCodePages("text/plain","Bir hata var. Durum kodu : {0}");  // Olmayan sayfalara istek yapıldığında yapılacak ayarlar
                // 2. Yol
                //app.UseStatusCodePages(async context => {
                //    context.HttpContext.Response.ContentType = "text/plain";
                //    await context.HttpContext.Response.WriteAsync($"Bir hata var. Durum kodu:{context.HttpContext.Response.StatusCode}");
                //});
                // 3. Yol
                //app.UseDatabaseErrorPage();  // EntityFramework ile ilgili detaylı hataları görebilmek için
            }
            else
            {
                app.UseHsts();
            }

            //app.UseExceptionHandler(context => {                                 // Önerilen bu şekildedir. Custom yaptığımız için yorum satırı yaptık
            //    context.Run(async page =>
            //    {
            //        page.Response.StatusCode = 500;
            //        page.Response.ContentType = "text/html";
            //        await page.Response.WriteAsync($"<html><head><h1>Hata var:{page.Response.StatusCode}</h1></head></html>");
            //    });
            //}); 


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
