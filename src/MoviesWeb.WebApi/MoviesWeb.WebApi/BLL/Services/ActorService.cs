using MoviesWeb.WebApi.BLL.Interfaces;
using MoviesWeb.WebApi.DAL.Interfaces;
using MoviesWeb.WebApi.DAL.Models;
using MoviesWeb.WebApi.DAL.UnitOfWork;

namespace MoviesWeb.WebApi.BLL.Services
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork unitOfWork;

        public ActorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddMovieToActor(Movie movie, int actorId)
        {
            var actor = await this.unitOfWork.ActorRepository.GetActor(actorId);
            actor.ActorMovies?.Add(movie);
            await this.unitOfWork.ActorRepository.Save();
        }

        public async Task ChangeActorMark(int actorId, double mark)
        {
            var actor = await this.unitOfWork.ActorRepository.GetActor(actorId);
            if (actor != null && actor.ActorMark != mark)
            {
                actor.ActorMark = mark;
                await this.unitOfWork.ActorRepository.Save();
            }
        }

        public async Task<IEnumerable<Movie>> GetActorMovies(int actorId)
        {
            var actor = await this.unitOfWork.ActorRepository.GetActor(actorId);
            if (actor != null)
            {
                return actor.ActorMovies.ToList();
            }
            return Enumerable.Empty<Movie>();
        }
        public async Task<IEnumerable<Actor>> GetActors()
        {
            var actors = await this.unitOfWork.ActorRepository.GetActors();
            return actors.ToList();
        }
    }
}
