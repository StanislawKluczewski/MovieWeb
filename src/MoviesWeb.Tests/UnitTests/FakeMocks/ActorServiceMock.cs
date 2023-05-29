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


        public async Task AddMovieToActor(Movie movie, Actor actor)
        {
            if (movie != null && actor != null)
            {
                actor?.ActorMovies?.Add(movie);
            }
        }

        public async Task RemoveMovieFromActor(Movie movie, Actor actor)
        {
            if (movie != null && actor != null)
            {
                actor.ActorMovies?.Remove(movie);
            }
        }

        public async Task ChangeActorMark(Actor actor, double mark)
        {
            if (mark > 0.0)
            {
                actor.ActorMark = mark;
            }
        }

        public async Task<IEnumerable<Movie>> GetActorMovies(Actor actor)
        {
            var result = await Task.FromResult(actor.ActorMovies?.ToList());
            return result;
        }
    }
}
