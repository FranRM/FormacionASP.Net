using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProxectoPractica2._3
{
    public class ValidDivisionConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            int divisor;
            return int.TryParse(values[routeKey]?.ToString(), out divisor) && divisor != 0;
        }
    }
}
