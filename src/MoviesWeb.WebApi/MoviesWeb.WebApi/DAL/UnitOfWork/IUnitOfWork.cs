using MoviesWeb.WebApi.DAL.Interfaces;

namespace MoviesWeb.WebApi.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IActorRepository ActorRepository { get; }
        IMovieRepository MovieRepository { get; }
        IDirectorRepository DirectorRepository { get; }
        Task Save();
    }
}
