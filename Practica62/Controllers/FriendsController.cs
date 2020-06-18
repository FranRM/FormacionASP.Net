using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Practica62.Controllers
{
    
        public class FriendsController : Controller
    {
        // GET: /Friends/
[Route("{controller}")]         
public IActionResult Index() => Content("FriendsController.Index()");

// GET: /Friends/View/John
[Route("{controller}/{action}/{name}")] 
public IActionResult View(string name) => Content($"FriendsController.View('{name}')");

// GET: /Friends/Edit/23
[Route("{controller}/{action}/{id}")] 
public IActionResult Edit(int id) => Content($"FriendsController.Edit({id})");

// GET: /delete/friends/18
[Route("{action}/{controller}/{id}")] 
public IActionResult Delete(int id) => Content($"FriendsController.Delete({id})");
    }
}