using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP3.Models;

namespace TP3.Controllers
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
        public IActionResult Create()
        {
            var members = _db.genres.ToList();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.Name,
                Value = members.Name
            });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var members = _db.genres.ToList();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.Name,
                Value = members.Name
            });
            ViewBag.Errors = ModelState.Values
            .SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return View();
            }

            // Validez les données du formulaire et ajoutez le nouveau film à la base de données
            _db.movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Edit(Guid id)
        {
            // Récupérez le film à partir de la base de données en utilisant l'ID
            var movie = _db.movies.Find(id);

            if (movie == null)
            {
                return NotFound(); // Ou renvoyez une vue d'erreur personnalisée
            }

            return View(movie);
        }
        public IActionResult Delete(Guid id)
        {
            var movie = _db.movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var movie = _db.movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            _db.movies.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction("Index"); // Redirect to the list after successful deletion
        }




    }
}
