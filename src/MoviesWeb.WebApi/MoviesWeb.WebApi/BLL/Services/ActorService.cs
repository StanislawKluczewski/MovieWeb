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

        public async Task AddMovieToActor(Movie movie, Actor _actor)
        {
            var actor = await this.unitOfWork.ActorRepository.GetActor(_actor.ActorId);
            actor.ActorMovies?.Add(movie);
            await this.unitOfWork.ActorRepository.Save();
        }

        public async Task ChangeActorMark(Actor _actor, double mark)
        {
            var actor = await this.unitOfWork.ActorRepository.GetActor(_actor.ActorId);
            if (actor != null && actor.ActorMark != mark)
            {
                actor.ActorMark = mark;
                await this.unitOfWork.ActorRepository.Save();
            }
        }

        public async Task<IEnumerable<Movie>> GetActorMovies(Actor _actor)
        {
            var actor = await this.unitOfWork.ActorRepository.GetActor(_actor.ActorId);
            if (actor != null)
            {
                return actor.ActorMovies.ToList();
            }
            return Enumerable.Empty<Movie>();
        }
    }
}
