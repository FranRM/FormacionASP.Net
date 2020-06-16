using Microsoft.AspNetCore.Mvc;
using MVC4._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC4._1.Controllers
{
    public class BlogController: Controller
    {
        private readonly IBlogServices _blogServices;
        public BlogController(IBlogServices blogServices) {
            _blogServices = blogServices;
        }
        public IActionResult Index()
        {
            var posts = _blogServices.GetLatestPosts(10);
            return View("Index", posts);
        }
        public IActionResult Archive(int year, int month)
        {
            var posts = _blogServices.GetPostsByDate(year, month);
            return View(posts);
        }
    }
}
