using TP4.Models;

namespace TP4.Services.ServiceContracts
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(Guid id);
        void CreateMovie(Movie movie);
        void Edit(Movie movie);
        void Delete(Guid id);

        /*used linq queries in those below*/
        List<Movie> GetMoviesByGenre(Guid genreId);
        List<Movie> GetAllMoviesOrderedAscending();
        List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre);

    }



}
