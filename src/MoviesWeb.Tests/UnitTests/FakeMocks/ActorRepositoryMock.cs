using MoviesWeb.WebApi.DAL.Interfaces;
using MoviesWeb.WebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWeb.Tests.UnitTests.FakeMocks
{
    public class ActorRepositoryMock : IActorRepository
    {
        private List<Actor> actors = new List<Actor>();
        public async Task CreateActor(Actor actor)
        {
            actors.Add(actor);
        }

        public async Task DeleteActor(int id)
        {
            var actor = await Task.FromResult(actors.Find(a => a.ActorId == id));
            actors.Remove(actor);
        }

        public async Task<Actor> GetActor(int id)
        {
            var actor = await Task.FromResult(actors.Find(a => a.ActorId == id));
            return actor;
        }

        public async Task<IEnumerable<Actor>> GetActors()
        {
            var actors = await Task.FromResult(this.actors);
            return actors;
        }

        public async Task UpdateActor(int id, Actor actor)
        {
            var index = await Task.FromResult(actors.Find(a => a.ActorId == id));
            if (actor != null)
            {
                index = actor;
            }
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
