using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Practica62.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        // Ruta: /Products/All
        [Route("All")] 
public IActionResult Index() => Content("ProductsController.Index()");

// Ruta: /Products/Lenovo-yoga
[Route("{id}")] 
public IActionResult View(string id) => Content($"ProductsController.View('{id}')");

// Ruta: /Products/Category/Ultrabooks
[Route("{action}/{category}")] 
public IActionResult ByCategory(string category) => Content($"ProductsController.ByCategory('{category}')");
    }
}