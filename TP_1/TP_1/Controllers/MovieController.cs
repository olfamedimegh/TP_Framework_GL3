using Microsoft.AspNetCore.Mvc;
using Tp1.Models;


namespace Tp1.Controllers
{
    public class MovieController : Controller
    {
        private IEnumerable<Movie> getAllMovies()
        {
            var movies = new List<Movie>()
             {
            new Movie { Id = 0, Name="Harry Potter 1", ReleaseDate = new DateTime(2001, 11,14)},
            new Movie { Id = 1, Name = "Movie 1", ReleaseDate = new DateTime(2005, 1, 15) },
            new Movie { Id = 2, Name = "Movie 2", ReleaseDate = new DateTime(2013, 5, 20) },
            new Movie { Id = 3, Name = "Movie 3", ReleaseDate = new DateTime(2009, 3, 10) }
            };
            return movies;
        }

        public IActionResult Index()
        {
            var movies = getAllMovies();
            return View(movies);
        }
        public IActionResult Edit(int id)
        {
            return Content("Test Id" + id);
        }

        [HttpGet("Movie/released/{year}/{month}")]
        public IActionResult ByRelease(int year, int month)
        {

            List<Movie> moviesByReleased = new List<Movie>();
            var movies = getAllMovies();
            foreach (var movie in movies)
            {
                if (movie.ReleaseDate.Year == year && movie.ReleaseDate.Month == month)
                {
                    moviesByReleased.Add(movie);
                }
            }
            return View(moviesByReleased);
            //return Content($"Vous avez demandé les films sortis en année {year} et mois {month}");
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return Content("ID not found");
            var testDetails = getAllMovies().
            FirstOrDefault(c => c.Id == id);
           // return RedirectToAction(nameof(Index));
            return View(testDetails);

        

        }

    }
}
