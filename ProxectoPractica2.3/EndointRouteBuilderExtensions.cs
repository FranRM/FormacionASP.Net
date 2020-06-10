using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProxectoPractica2._3
{
    public static class EndointRouteBuilderExtensions {
        public static IEndpointConventionBuilder MapCalculator(this IEndpointRouteBuilder endpoints, string routePattern)
        {
            {
                return endpoints.MapGet(routePattern, CalculatorHandler.CalculateAsync);
            }
        }
    }
}
