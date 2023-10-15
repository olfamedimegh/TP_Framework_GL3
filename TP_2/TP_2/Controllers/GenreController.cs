using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
       
    }
}
