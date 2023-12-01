using TP4.Models;
using TP4.Services.ServiceContracts;

namespace TP4.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movie> GetAllMoviesByGenre(string genre)
        {
            return _dbContext.movies
                .Where(m => m.Genre.Equals(genre))
                .ToList();
        }
        public List<Movie> GetAllMoviesOrderedByTitle()
        {
            return _dbContext.movies
                .OrderBy(m => m.Name)
                .ToList();
        }
        public List<Movie> GetMoviesByGenreId(int genreId)
        {
            return _dbContext.movies
                .Where(m => m.GenreId.Equals(genreId))
                .ToList();
        }
    }
}
