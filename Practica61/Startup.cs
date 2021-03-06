using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Practica61
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
            services.AddControllersWithViews();
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
                endpoints.MapControllerRoute(
                    name: "view",
                    pattern: "friends/view/{name}",
                    defaults: new { controller = "Friends", action = "View"});

                endpoints.MapControllerRoute(
                    name: "edit",
                    pattern: "friends/edit/{id}",
                    defaults: new { controller = "Friends", action = "Edit" });

                endpoints.MapControllerRoute(
                    name: "delete",
                    pattern: "delete/friends/{id}",
                    defaults: new { controller = "Friends", action = "Delete" });
                endpoints.MapControllerRoute(
                    name: "all",
                    pattern: "products/all",
                    defaults: new { controller = "Products", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "viewP",
                    pattern: "products/{id}",
                    defaults: new { controller = "Products", action = "View" });

                endpoints.MapControllerRoute(
                    name: "category",
                    pattern: "products/category/{category}",
                    defaults: new { controller = "Products", action = "ByCategory" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "/",
                    defaults: new { controller = "Products", action = "Index" });
            });
        }
    }
}
