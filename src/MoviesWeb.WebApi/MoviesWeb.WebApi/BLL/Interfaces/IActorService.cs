using MoviesWeb.WebApi.DAL.Models;

namespace MoviesWeb.WebApi.BLL.Interfaces
{
    public interface IActorService
    {
        Task AddMovieToActor(Movie movie, Actor actor);
        Task<IEnumerable<Movie>>GetActorMovies(Actor actor);
        Task ChangeActorMark(Actor actor, double mark);
    }
}
