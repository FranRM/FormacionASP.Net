using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("visits", async (HttpContext context) =>
                {
                    var newCount = context.Session.GetInt32("count").GetValueOrDefault() + 1;
                    context.Session.SetInt32("count", newCount);
                    await context.Response.WriteAsync($"Your visits: {newCount}");
                });
                endpoints.MapGet("resetVisits", async (HttpContext context) =>
                {
                    context.Session.SetInt32("count", 0);
                });
            });
        }
    }
}
