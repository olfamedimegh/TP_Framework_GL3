using Microsoft.AspNetCore.Mvc;
using TP_2.Models;

namespace TP2.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Movie> movies = _db.movies.ToList();
            return View(movies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // Validez les données du formulaire et ajoutez le nouveau film à la base de données
                _db.movies.Add(movie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public IActionResult Edit(int id)
        {
            // Récupérez le film à partir de la base de données en utilisant l'ID
            var movie = _db.movies.Find(id);

            if (movie == null)
            {
                return NotFound(); // Ou renvoyez une vue d'erreur personnalisée
            }

            return View(movie);
        }
        public IActionResult Delete(int id)
        {
            var movie = _db.movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }





    }
}
