using Microsoft.AspNetCore.Mvc;
using Routing.Models;
using System.Diagnostics;

namespace Routing.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View("Index");
		}

		[Route("/")]
		public IActionResult Index()
		{
			return View();
		}

		[Route("{id?}/{name?}")]
		public IActionResult Cow(int? id, string? name)
		{
			if (name == null)
			{
				return Content($"The cow Jerry moos at you {id} times.");
			}
			else
			{
				return Content($"The cow {name} moos at you {id} times.");
			}
		}

		[Route("EatMoreChicken")]
		public IActionResult Chicken()
		{
			return Redirect("https://www.chick-fil-a.com/");
		}

		[Route("AllCows/Gallery/{number}/Page{page}")]
		[Route("AllCows/Gallery/{number}/")]
		[Route("AllCows/Gallery/{number}/{page}")]
		public IActionResult Gallery(int number, int page)
		{
			List<Cow> CowList = new List<Cow>();

			for (int i = 0; i < number; i++)
			{
				CowList.Add(new Models.Cow("Jerry", "Hes Jerry", "/images/cow.jpg"));
			}

			if (page != null)
			{
				ViewBag.page = page;
			}

			return View(CowList);
		}

		public IActionResult Privacy()
		{
			return View();
		}

	}
}