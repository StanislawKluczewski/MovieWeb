using MoviesWeb.WebApi.DAL.Models;

namespace MoviesWeb.WebApi.DAL.Interfaces
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetActors();
        Task<Actor> GetActor(int id);
        Task CreateActor(Actor actor);
        Task UpdateActor(int id,Actor actor);
        Task DeleteActor(int id);
        Task Save();
    }
}
