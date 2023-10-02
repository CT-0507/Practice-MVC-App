using System;
using System.IO;
using System.Linq;
using System.Security.Policy;
using AppMvcNet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppMvcNet.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public string Index()
        {
            //this.HttpContext
            //this.Request
            //this.Response
            //this.RouteData
            //this.User
            // this.ModelState
            //this.ViewData
            //this.Url
            // this.Tempdata

            _logger.LogInformation("Index Action");
            Console.WriteLine("Index Action");
            return "I am index of first";
        }

        public void Nothing()
        {
            _logger.LogCritical("Nothing Action");
            Response.Headers.Add("hi", "Good to see everyone");
        }

        public object Anything() => DateTime.Now;

        public IActionResult Readme()
        {
            var content = @"
            Hi everyone,
            You are learning about ASP.NET MVC
            
            
            
            Cuong.NET";

            return Content(content, "text/plain");
        }

        public IActionResult RandomPic()
        {
            // Startup.ContentRootPath
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "RandomPic.png");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/png");
        }

        public IActionResult IphonePrice()
        {
            return Json(
                new
                {
                    productName = "Iphone X",
                    Price = 1000
                }
            );
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Redirect to " + url);
            return LocalRedirect(url);
        }

        public IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogInformation("Redirect to " + url);
            return Redirect(url);
        }

        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
                username = "Guest User";
            //return View("hello2", username); // View() -> Razor Engine, doc .cshtml(template)

            return View("Hello1", username);
        }

        [TempData]
        public string StatusMessage { set; get; }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                // TempData["StatusMessage"] = "Requested product is not available or not existed";
                StatusMessage = "Requested product is not available or not existed";
                return Redirect(Url.Action("Index", "Home"));
            }
            // View/First/ViewProduct
            // MyView/First/ViewProduct
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");

            ViewBag.product = product;
            return View("ViewProduct3");
        }

        //IAction
        // ContentResult                    | Content()
    }
}