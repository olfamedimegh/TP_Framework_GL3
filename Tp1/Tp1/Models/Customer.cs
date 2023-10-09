using System.ComponentModel.DataAnnotations;

namespace Tp1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
