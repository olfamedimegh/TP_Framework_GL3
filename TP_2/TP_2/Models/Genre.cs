namespace TP_2.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
