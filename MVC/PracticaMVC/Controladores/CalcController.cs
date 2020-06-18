using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace PracticaMVC.Controladores
{
    public class CalcController : Controller
    {
        private readonly ICalculatorServices _calculatorServices;
        private readonly ILogger _logger;
        private const string BasePath = "/calc";

        public CalcController(ILogger<CalcController> logger, ICalculatorServices calculatorServices)
        {
            _logger = logger;
            _calculatorServices = calculatorServices;
        }

        public IActionResult Index()
        {
            var html = GetHtmlPage("Start",
                $@" <form method='post' action='{BasePath}/results'>
                        <input type='number' name='a'>
                        <select name='operation'>
                            <option value='+'>+</option>
                            <option value='-'>-</option>
                            <option value='*'>*</option>
                            <option value='/'>/</option>
                        </select>
                        <input type='number' name='b'>
                        <input type='submit' value='Calculate'>
                    </form>
                ");
            return Content(html, contentType: "text/html");
        }

        public IActionResult Results(int a, int b, string operation)
        {
            _logger.LogDebug($"Trying to calculate: {a}{operation}{b}");

            var result = _calculatorServices.Calculate(a, b, operation);
            var html = GetHtmlPage("Results",
                $@"<h2>{a}{operation}{b}={result}</h2>
                <p><a href='{BasePath}'>Back</a></p>"
            );
            return Content(html, contentType: "text/html");
        }

        private string GetHtmlPage(string title, string body)
        {
            return $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8' />
                    <title>{title} - Calculator</title>
                    <link href='/styles/calculator.css' rel='stylesheet' />
                </head>
                <body>
                    <h1>
                        <img src='/images/calculator.png' />
                        Simple calculator
                    </h1>
                    {body}
                </body>
                </html>
            ";
        }
    }
}