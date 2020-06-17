using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab051.Models.Repositories;
using Lab051.Models.Repositories.Database;
using Lab051.Models.Repositories.InMemory;
using Lab051.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lab051
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
            services.AddScoped<IBlogServices, BlogServices>();

            // ** Descomenta la siguiente línea para usar el repositorio en memoria
            // services.AddScoped<IPostsRepository, InMemoryPostsRepository>();

            // ** Descomenta el siguiente bloque para usar el repositorio basado en EF con SQLite:
            //services.AddScoped<IPostsRepository, SqlitePostsRepository>();
            //services.AddDbContext<BlogDataContext>();
            //SqlitePostsRepository.InitializeDatabase();

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
                    name: "archive",
                    pattern: "blog/archive/{year}/{month}",
                    defaults: new { controller = "Blog", action = "Archive" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
