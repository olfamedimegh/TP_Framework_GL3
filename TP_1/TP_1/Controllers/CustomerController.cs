using Microsoft.AspNetCore.Mvc;
using Tp1.Models;

namespace Tp1.Controllers
{
    public class CustomerController : Controller
    {
        static List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 11, Name = "Customer 1" },
                new Customer { Id = 12, Name = "Customer 2" },
                new Customer { Id = 13, Name = "Customer 3" }
            };
        public IActionResult Index()
        {
            return View(customers);
        }
        [HttpGet("Customer/{id}")]
        public IActionResult Details(int id)
        {

            foreach (var customer in customers)
            {
                if (customer.Id == id )
                {
                    return View(customer);
                }
            }
            return Content($"a customer with the the id {id} doesn't exist !");
        }
    }
}
