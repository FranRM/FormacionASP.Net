using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Practica2._4.Handlers
{
    public class LoginHandlers
    {
        public static async Task GetLoginPageAsync(HttpContext context)
        {
            var body = @"
            <h1>Login</h1>
            <form method='post' action='/login'>
                Username:  <input type='text' name='username'><br>
                Password: <input type='password' name='password'><br>
                <hr>
                <input type='submit' value='Login' >
            </form>
        ";
            await PageUtils.SendPageAsync(context, "Login", body);
        }
        public static async Task DoLoginAsync(HttpContext context) {
            if (context.Request.Form["username"].Equals("Pepe") && context.Request.Form["password"].Equals("Pepe"))
            {
                var identity = new System.Security.Claims.ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.Request.Form["username"]));
                var principal = new ClaimsPrincipal(identity);
                await context.SignInAsync(principal);
                context.Response.Redirect("/home");
            }
            else {
                context.Response.Redirect("/error");
            }
        }
        public static async Task DoLogoutAsync(HttpContext context)
        {
            await context.SignOutAsync();
            await context.Response.WriteAsync($"Logged out!");
        }
    }
}
