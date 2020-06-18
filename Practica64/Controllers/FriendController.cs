using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practica64.Models;

namespace Practica64.Controllers
{
    public class FriendController : Controller
    {
        public IActionResult Create()
        {
            //return View();
            var newFriend = new Friend()
            {
                Name = "Default name",
                Age = 26,
                Address = new Address()
            };
            return View(newFriend);
        }
        [HttpPost]
        public IActionResult Create(Practica64.Models.Friend friend)
        {
            //return Content($"Nombre: {friend.Name}, Edad: {friend.Age}, Correo: {friend.Email}, Rua: {friend.address.Street}, Poboaci�n: {friend.address.City}, CP: {friend.address.ZipCode}.");
            
            //if (string.IsNullOrEmpty(friend.Name) || friend.Age < 18)
            //{
            //    ViewData["ErrorMessage"] = "Invalid data";

            //    if (string.IsNullOrEmpty(friend.Name))
            //    {
            //        ViewData["ErrorName"] = "* Invalid name";
            //    }
            //    if (friend.Age < 18)
            //    {
            //        ViewData["ErrorAge"] = "*Age must be >18";
            //    }
            //    return View(friend);
            //}
            //else
            //{
            //    var serializedFriend = JsonSerializer.Serialize(friend);
            //    return Content($"Created: {serializedFriend}");
            //}

            if (!ModelState.IsValid)
            {
                return View(friend);
            }
            return Content($"Created: {friend.Name}");


        }
    }
}
