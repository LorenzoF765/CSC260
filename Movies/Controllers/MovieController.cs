using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Interfaces;
using Movies.Models;

namespace Movies.Controllers
{
	public class MovieController : Controller
	{
		IDataAccessLayer DAL = new MovieListDAL();

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult DisplayMovie()
		{
			Movie m = new Movie("Fantastic Mr. Fox", 2009, 4.5f);
			return View(m);
		}

		public IActionResult MultMovies() 
		{ 
			return View(DAL.GetMovies());
		}

		public IActionResult ParamTest(int? id)
		{
			//return Content("things");
			return Content($"id = {id?.ToString() ?? "NULL"}");
			// ?? = null coalescing operator, (if left is null, do right)
			// id? = check if null, if it is dont do the next thing
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Movie m)
		{
			// custom validation
			if (m.Title == "The Room")
			{
				ModelState.AddModelError("CustomError", "That movie is trash. It ain't allowed.");
			}
			
			if (ModelState.IsValid)
			{ 
				DAL.AddMovie(m);
				TempData["success"] = "Movie " + m.Title + " created";
				return View("MultMovies", DAL.GetMovies());
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int? id) 
		{
			if (!id.HasValue) return NotFound();

			Movie found = DAL.GetMovie(id);

			if (found == null) return NotFound();

			return View(found);
		}

		[HttpPost]
		public IActionResult Edit(Movie movie)
		{
            DAL.EditMovie(movie);
            return View("MultMovies", DAL.GetMovies());
        }

		public IActionResult Delete(int? id) 
		{
			// this if is so pointless because it can never be null
			if (DAL.GetMovie(id) == null) ModelState.AddModelError("Title", "Movie does not exist");

			if (ModelState.IsValid)
			{ 
				DAL.RemoveMovie(id);
			}
			return View("MultMovies", DAL.GetMovies());
        }
	}
}

// DateTime dt = DateTime.Now
// Model.Count()
// LoanDate = null
// Model.LoanDate.HasValue
// LoanDate.Value.ToShortDateString() "1/1/1111"
// LoanDate.Value.ToLongDateString() "January 1, 1111"
// model will store the filename for the image <img src"/images/@Model.ImageName" />
// Game oneame = lstGames.Find(g => g.ID == ID);
// lstGames.FindIndex(g => g.ID ==ID);
// use a form for loaning