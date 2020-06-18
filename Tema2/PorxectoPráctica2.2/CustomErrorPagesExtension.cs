﻿using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PorxectoPráctica2._2
{
    public static class CustomErrorPagesExtensions
    {
        public static IApplicationBuilder UseCustomErrorPages(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomErrorPagesMiddleware>();
        }
    }
}
