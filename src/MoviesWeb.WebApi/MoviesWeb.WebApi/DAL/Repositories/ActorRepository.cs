using Microsoft.EntityFrameworkCore;
using MoviesWeb.WebApi.DAL.Data;
using MoviesWeb.WebApi.DAL.Interfaces;
using MoviesWeb.WebApi.DAL.Models;

namespace MoviesWeb.WebApi.DAL.Repositories
{
    public class ActorRepository : IActorRepository, IDisposable
    {
        private readonly ApplicationDbContext dbContext;
        private bool disposed = false;
        public ActorRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateActor(Actor actor)
        {
           await this.dbContext.Actors.AddAsync(actor);
        }

        public async Task DeleteActor(int id)
        {
            var actor = await this.dbContext.Actors.FirstAsync(a => a.ActorId == id);
            if(actor != null)
            {
                this.dbContext.Actors.Remove(actor);
            }
        }

        public async Task<Actor> GetActor(int id)
        {
            var actor = await this.dbContext.Actors.FirstAsync(a => a.ActorId == id);
            return actor;
        }

        public async Task<IEnumerable<Actor>> GetActors()
        {
            return await this.dbContext.Actors.ToListAsync();
        }

        public async Task UpdateActor(int id, Actor actor)
        {
            var foundActor = await this.dbContext.Actors.FirstAsync(a => a.ActorId == id);
            if (actor != null && foundActor != null)
            {
                foundActor.Name = actor.Name;
                foundActor.Surname = actor.Surname;
                foundActor.Sex = actor.Sex;
                foundActor.Wiek = actor.Wiek;
                foundActor.Nationality = actor.Nationality;
                foundActor.ActorMark = actor.ActorMark;
            }
        }

        public async Task Save()
        {
            await this.dbContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
