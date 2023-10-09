using System.ComponentModel.DataAnnotations;

namespace Tp1.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }


    }
}
