#nullable disable
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class MoviesController : Controller
    {
        // Add service injections here
        private readonly IMovieService _movieService;
        private readonly IDirectorService _directorService;

        public MoviesController(IMovieService movieService, IDirectorService directorService)
        {
            _movieService = movieService;
            _directorService = directorService;
        }

        // GET: Movies
        public IActionResult Index()
        {
            List<MovieModel> movieList = _movieService.Query().ToList();
            return View(movieList);
        }

        // GET: Movies/Details/5
        public IActionResult Details(int id)
        {
            MovieModel movie = _movieService.Query().SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["DirectorId"] = new SelectList(_directorService.Query().ToList(), "Id", "NameOutput");
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                bool result = _movieService.Add(movie);
                if (result)
                {
                    TempData["Message"] = "Movie added successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Movie couldn't be added!");
            }

            ViewData["DirectorId"] = new SelectList(_directorService.Query().ToList(), "Id", "NameOutput");
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int id)
        {
            MovieModel movie = _movieService.Query().SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["DirectorId"] = new SelectList(_directorService.Query().ToList(), "Id", "Surname");
            return View(movie);
        }

        // POST: Movies/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                bool result = _movieService.Update(movie);
                if (result)
                {
                    TempData["Message"] = "Movie updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Movie couldn't be updated!");
            }
            ViewData["DirectorId"] = new SelectList(_directorService.Query().ToList(), "Id", "Surname");
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int id)
        {
            MovieModel movie = _movieService.Query().SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieService.Delete(id);
            TempData["Message"] = "Movie deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
