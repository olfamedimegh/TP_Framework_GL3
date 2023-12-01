using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
   
    public class Movie
    {
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        public string? Name { get; set; }

        public List<Customer>? Customers { get; set; }

        public string? Image { get; set; }
        
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public DateTime? CreatedDate { get; set; }


        public Guid GenreId { get; set; }

        [ForeignKey("GenreId")]  // Define the foreign key relationship
        public virtual Genre? Genre { get; set; }  // Navigation property to Genre
        public Movie()
        {
        }
    }
}
