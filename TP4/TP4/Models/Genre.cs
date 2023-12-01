using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
