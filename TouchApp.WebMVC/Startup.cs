using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TouchApp.WebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<RazorViewEngineOptions>(options =>
            //{
            //    options.AreaViewLocationFormats.Clear();
            //    options.AreaViewLocationFormats.Add("/Global/{2}/Views/{1}/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add("/Global/{2}/Views/Shared/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add("/Admin/{2}/Views/{1}/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add("/Admin/{2}/Views/Shared/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            //});

            services.AddControllersWithViews();

            //services.AddRazorPages();

            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "TouchGlobal",
                    areaName: "Global",
                    pattern: "/");

                endpoints.MapAreaControllerRoute(
                    name: "TouchGeneral",
                    areaName: "Global",
                    pattern: "General/{controller=Home}/{action=TouchIndex}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "TouchClient",
                    areaName: "Global",
                    pattern: "Client/{controller=Home}/{action=TouchIndex}/{id?}");

                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=TouchIndex}/{id?}");

                //endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{area=Global}/{controller=Home}/{action=TouchIndex}/{id?}");
            });
        }
    }
}
