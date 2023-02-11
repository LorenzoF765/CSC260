using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private static int intCount = 0;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("magic")]
        public IActionResult Counter(/*string pizza*/)
        {
            ///ViewBag.mypizza = pizza;
            ViewBag.Count = intCount++;
            ViewData["Count"] = ViewBag.Count;
            return View();
        }

        public IActionResult Input()
        {
            ViewData["Title"] = "Input Form";
            return View();
        }

        public IActionResult Output(string FirstName, string LastName)
        {
            ViewBag.FN = FirstName;
            ViewBag.LN = LastName;
            return View();
        }

        public IActionResult Index()
        {
            //return Redirect("https://stackoverflow.com");
            //return View("Counter");
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Future()
        {
            return View();
        }

        public IActionResult Before()
        {
            return View();
        }

        [Route("pizza/{id?}")]
        public IActionResult RouteTest(int? id)
        {
            //return Content("route test stuff");
            return Content($"id = {id?.ToString() ?? "NULL"}");
        }

        public IActionResult Colors(string colors)
        {
            var colorList = colors.Split('/');
            return Content(string.Join(",", colorList));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}