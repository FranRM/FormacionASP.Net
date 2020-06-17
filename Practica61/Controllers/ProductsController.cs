using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Practica61.Controllers
{
    public class ProductsController : Controller
    {
        // Ruta: /Products/All
        public IActionResult Index() => Content("ProductsController.Index()");

        // Ruta: /Products/Lenovo-yoga
        public IActionResult View(string id) => Content($"ProductsController.View('{id}')");

        // Ruta: /Products/Category/Ultrabooks
        public IActionResult ByCategory(string category) => Content($"ProductsController.ByCategory('{category}')");
    }
}
