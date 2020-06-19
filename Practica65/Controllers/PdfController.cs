using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Practica65.Controllers
{
    public class PdfController : Controller
    {
        public IActionResult Download()
        {
            var defaultValues = new PdfFile{
                FileName = "default.pdf",
                Text = "Hello world."
            };
            return View(defaultValues);
        }
        [HttpPost]
        public IActionResult Download(PdfFile form) {
            return new PdfFileResult(form.FileName, form.Text);
        }
    }
}
