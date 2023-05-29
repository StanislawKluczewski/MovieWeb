using MoviesWeb.WebApi.DAL.Models;

namespace MoviesWeb.WebApi.BLL.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetActors();
        Task AddMovieToActor(Movie movie, int actorId);
        Task<IEnumerable<Movie>>GetActorMovies(int actorId);
        Task ChangeActorMark(int actorId, double mark);

    }
}
