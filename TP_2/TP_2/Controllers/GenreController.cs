using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_2.Models;

namespace TP_2.Controllers

{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.genres.ToList());
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            _db.genres.Add(genre);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult OnPost(Guid? id)
        {
            if (id == null) return NotFound();
            var m = _db.genres.FirstOrDefault(c => c.Id == id);
            return View(m);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnPost(Genre genre, Guid id)
        {
            var c = _db.genres.Find(id);
            c.Name = genre.Name;
            //_db.genres.Update(genre);
            try
            {   //breakpoints sur SaveChanges pour effectuer deux edit en 
                //Parrallèle --> Exécution du UPDATE 
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException db)
            {
                TempData["message"] = $"Cannot Add : {db.Message}";
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }

    }
}
