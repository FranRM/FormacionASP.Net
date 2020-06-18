using Microsoft.AspNetCore.Mvc;
using Practica63.Models;
using System.Text.Json;

namespace Practica63.Controllers
{
    public class FriendController: Controller
    {
        public IActionResult Create() {
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
        public IActionResult Create(Practica63.Models.Friend friend) {
            //return Content($"Nombre: {friend.Name}, Edad: {friend.Age}, Correo: {friend.Email}, Rua: {friend.address.Street}, Poboación: {friend.address.City}, CP: {friend.address.ZipCode}.");
            if (string.IsNullOrEmpty(friend.Name) || friend.Age < 18)
            {
                ViewData["ErrorMessage"] = "Invalid data";
                
                if (string.IsNullOrEmpty(friend.Name)) {
                    ViewData["ErrorName"] = "* Invalid name";
                }
                if ( friend.Age < 18) {
                    ViewData["ErrorAge"] = "*Age must be >18";
                }
                return View(friend);
            }
            else {
                var serializedFriend = JsonSerializer.Serialize(friend);
                return Content($"Created: {serializedFriend}");
            }

            
        }
    }
}