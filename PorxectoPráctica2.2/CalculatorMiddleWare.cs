using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PorxectoPráctica2._2
{
    public class CalculatorMiddleWare
    {
        private readonly string _basePath;
        private readonly RequestDelegate _next;
        private readonly ICalculatorServices _calculatorServices;

        public CalculatorMiddleware(string basePath,
                                    RequestDelegate next,
                                    ICalculatorServices calculatorServices)
        {
            _basePath = basePath;
            _next = next;
            _calculatorServices = calculatorServices;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(_basePath))
            {
                if (context.Request.Path.StartsWithSegments($"{_basePath}/results"))
                {
                    // Envía al navegador el resultado del cálculo
                    await SendCalculationResults(context);
                }
                else if (context.Request.Path.Value == _basePath)
                {
                    // Envía al navegador la página de entrada de datos
                    await SendCalculatorHomePage(context);
                }
                else
                {
                    // Envía al navegador un error 404 (not found)
                    context.Response.Clear();
                    context.Response.StatusCode = 404;
                }
            }
            else await _next(context);
        }
    }
}
