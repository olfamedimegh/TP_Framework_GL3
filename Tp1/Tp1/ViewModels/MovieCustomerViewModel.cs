using System.Collections.Generic;
using Tp1.Models;

namespace Tp1.ViewModels
{
    public class MovieCustomerViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}