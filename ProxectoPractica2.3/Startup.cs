using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProxectoPractica2._3.Services;

namespace ProxectoPractica2._3
{
    public static class CalculatorHandler
    {
        public static async Task CalculateAsync(HttpContext ctx)
        {
            var a = Convert.ToInt32(ctx.GetRouteValue("a"));
            var b = Convert.ToInt32(ctx.GetRouteValue("b"));
            var operation = ctx.GetRouteValue("operation").ToString();

            var services = ctx.RequestServices.GetService<ICalculatorServices>();
            var result = services.Calculate(a, b, operation);
            await ctx.Response.WriteAsync(result.ToString());
        }
    }
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICalculatorServices, CalculatorServices>();
            services.AddTransient<ICalculatorEngine, CalculatorEngine>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapCalculator("/calculator/{operation:}/{a}/{b}");
            });
        }
    }
}
