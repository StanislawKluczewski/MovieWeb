using MoviesWeb.WebApi.DAL.Models;

namespace MoviesWeb.WebApi.DAL.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(int id);
        Task CreateMovie(Movie movie);
        Task DeleteMovie(int id);
        Task UpdateMovie(int id, Movie movie);
        Task Save();
    }
}
