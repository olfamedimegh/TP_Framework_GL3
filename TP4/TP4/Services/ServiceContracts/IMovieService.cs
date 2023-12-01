using TP4.Models;

namespace TP4.Services.ServiceContracts
{
    public interface IMovieService
    {
        List<Movie> GetAllMoviesByGenre(string genre);
        List<Movie> GetAllMoviesOrderedByTitle();
        List<Movie> GetMoviesByGenreId(int genreId);

    }



}
