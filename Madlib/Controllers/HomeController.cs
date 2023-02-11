using MadLib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MadLib.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Output(string Adjective01, string Place01,
            string Adjective02, string Adjective04, string SongTitle01,
            string Adjective06, string Noun02, string PastTenseVerb02,
            string Noun04, string Verb01, string Verb03, string Noun01,
            string Clothing01, string Adjective03, string Adjective05,
            string Food01, string PastTenseVerb01, string Noun03,
            string PastTenseVerb03, string Noun05, string Verb02, 
            string Adjective07)
		{
            ViewBag.Adjective01 = Adjective01;
            ViewBag.Adjectove02 = Adjective02;
            ViewBag.Adjective03 = Adjective03;
            ViewBag.Adjective04 = Adjective04;
            ViewBag.Adjective05 = Adjective05;
            ViewBag.Adjective06 = Adjective06;
            ViewBag.Adjective07 = Adjective07;
            ViewBag.Noun01 = Noun01;
            ViewBag.Noun02 = Noun02;
            ViewBag.Noun03 = Noun03;
            ViewBag.Noun04 = Noun04;
            ViewBag.Noun05 = Noun05;
            ViewBag.Verb01 = Verb01;
            ViewBag.Verb02 = Verb02;
            ViewBag.Verb03 = Verb03;
            ViewBag.PastTenseVerb01 = PastTenseVerb01;
            ViewBag.PastTenseVerb02 = PastTenseVerb02;
            ViewBag.PastTenseVerb03 = PastTenseVerb03;
            ViewBag.Place01 = Place01;
            ViewBag.SongTitle01 = SongTitle01;
            ViewBag.Clothing01 = Clothing01;
            ViewBag.Food01 = Food01;

			return View();
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}