using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using VideoGameLibrary.Models;
using VideoGameLibrary.Data;
using VideoGameLibrary.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VideoGameLibrary.Controllers
{
    public class GameController : Controller
    {
        IDataAccessLayer DAL;
        public GameController(IDataAccessLayer indal)
        {
            DAL = indal;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Library()
        {
            return View(DAL.GetGames());
        }

        [HttpPost]
        public IActionResult Loan(string LoanOut, int? id) 
        {
            if (!id.HasValue) return NotFound();

            DAL.Loan(id, LoanOut);
            return View("Library", DAL.GetGames());
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return NotFound();

            DAL.RemoveGame(id);
            return View("Library", DAL.GetGames());
        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if (!id.HasValue) return NotFound();

            Game found = DAL.GetGame(id);

            if (found == null) return NotFound();

            return View(found);
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                DAL.EditGame(game);
                return View("Library", DAL.GetGames());
            }
            return View();
        }

        [HttpPost]
        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                ViewBag.Search = $"";
                return View("Library", DAL.GetGames());
            }
            ViewBag.Search = $"That contains \"{key}\".";
            return View("Library", DAL.Search(key));
        }

        [HttpPost]
        public IActionResult Filter(string genere, string platform, string esrb)
        {
            return View("Library", DAL.Filter(genere, platform, esrb));
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Game game) 
        {
            if (ModelState.IsValid)
            {
                DAL.AddGame(game);
                return View("Library", DAL.GetGames());
            }
            return View();
        }
    }
}
