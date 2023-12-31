﻿using Microsoft.AspNetCore.Mvc;
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

            if (movie.ImageFile != null && movie.ImageFile.Length > 0)
            {
                // Enregistrez le fichier image sur le serveur
                var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    movie.ImageFile.CopyTo(stream);
                }

                // Enregistrez le chemin de l'image dans la base de données
                movie.Image = $"/images/{movie.ImageFile.FileName}";
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
                try
                {
                    // Retrieve the existing movie from the database

                    if (movie == null)
                    {
                        return NotFound();
                    }

                    if (movie.ImageFile != null && movie.ImageFile.Length > 0)
                    {
                        // Enregistrez le fichier image sur le serveur
                        var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            movie.ImageFile.CopyTo(stream);
                        }

                        // Enregistrez le chemin de l'image dans la base de données
                        movie.Image = $"/images/{movie.ImageFile.FileName}";
                    }
                    _db.Entry(movie).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
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
            // Delete the image file from the /images folder
            if (!string.IsNullOrEmpty(movie.Image))
            {
                var imagePath = Path.Combine("wwwroot", movie.Image.TrimStart('/'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
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
