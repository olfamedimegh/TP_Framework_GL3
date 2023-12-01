using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP4.Models;

namespace TP4.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Customer> customers = _db.custumors.ToList();  
            return View(customers);
        }
        public IActionResult Create()
        {
            var members = _db.Membershiptypes.ToList();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.Name,
                Value = members.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer c)
        {
            
            if (!ModelState.IsValid)
            {
                var members = _db.Membershiptypes.ToList();
                ViewBag.member = members.Select(members => new SelectListItem()
                {
                    Text = members.Name,
                    Value = members.Id.ToString()
                });
                ViewBag.Errors = ModelState.Values
                .SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View();
            }
            
            c.Id = new Guid();
            _db.custumors.Add(c);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id) {
            return View();

        }


    }
}
