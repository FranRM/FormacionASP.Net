using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProxectoPractica2._3
{
    public class ValidOperationConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string operation = values[routeKey]?.ToString().ToLower();
            return operation.Equals("add") || operation.Equals("sub") || operation.Equals("mul") || operation.Equals("div");
        }
    }
}
