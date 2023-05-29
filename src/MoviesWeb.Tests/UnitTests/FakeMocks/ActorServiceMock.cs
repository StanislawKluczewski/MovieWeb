using MoviesWeb.WebApi.BLL.Interfaces;
using MoviesWeb.WebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWeb.Tests.UnitTests.FakeMocks
{
    public class ActorServiceMock : IActorService
    {

        private List<Actor> _actors = new List<Actor>() { };


        public async Task AddMovieToActor(Movie movie, int actorId)
        {
            var actor = await Task.FromResult(_actors.Find(a => a.ActorId == actorId));
            actor?.ActorMovies?.Add(movie);
        }

        public async Task ChangeActorMark(int actorId, double mark)
        {
            var actor = await Task.FromResult(_actors.Find(a => a.ActorId == actorId));
            actor.ActorMark = mark;
        }

        public async Task<IEnumerable<Movie>> GetActorMovies(int actorId)
        {
            var actor = await Task.FromResult(_actors.Find(a => a.ActorId == actorId));
            return actor.ActorMovies.ToList();
        }

        public async Task<IEnumerable<Actor>> GetActors()
        {
            var result = await Task.FromResult(_actors.ToList());
            return result;
        }
    }
}
