
using TP4.Models;

namespace TP4.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(Guid id);
        void CreateMovie(Movie movie);
        void EditMovie(Movie movie);
        void DeleteMovie(Guid id);
        List<Movie> GetMoviesByGenre(Guid genreId);
        List<Movie> GetAllMoviesOrderedAscending();
        List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre);
    }
}
