using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                Value = members.Id.ToString()
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
                Value = members.Id.ToString()
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

            var members = _db.genres.ToList();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.Name,
                Value = members.Id.ToString()

            });

            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,GenreId,CreatedDate,Image")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                var existingMovie = _db.movies.Find(id);
                try
                {
                    // Retrieve the existing movie from the database

                    if (existingMovie == null)
                    {
                        return NotFound();
                    }

                    // Update the properties of the existing movie
                    existingMovie.Name = movie.Name;
                    existingMovie.GenreId = movie.GenreId;
                    existingMovie.CreatedDate = movie.CreatedDate;


                    // Check if a new image file is provided
                    if (movie.Image != null)
                    {
                        existingMovie.Image = movie.Image;
                    }
                    _db.Update(existingMovie);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (existingMovie == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            // If ModelState is not valid, re-populate the ViewBag with genres and return to the Edit view
            var members = _db.genres.ToList();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.Name,
                Value = members.Id.ToString()
            });

            return View(movie);
        }

        //
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

        public IActionResult Details(Guid id)
        {
            // Récupérez le film à partir de la base de données en utilisant l'ID
            var movie = _db.movies.Find(id);

            if (movie == null)
            {
                return NotFound(); // Ou renvoyez une vue d'erreur personnalisée
            }

            return View(movie);
        }


    }
}
