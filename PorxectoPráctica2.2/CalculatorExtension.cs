using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PorxectoPráctica2._2
{
    public static class CalculatorExtension
    {
        public static IApplicationBuilder UseCalculator(this IApplicationBuilder app, string path)
        {
            return app.UseMiddleware<CalculatorMiddleWare>(path);
        }
    }
}
