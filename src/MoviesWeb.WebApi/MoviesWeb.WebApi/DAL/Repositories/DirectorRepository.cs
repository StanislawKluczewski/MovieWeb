using Microsoft.EntityFrameworkCore;
using MoviesWeb.WebApi.DAL.Data;
using MoviesWeb.WebApi.DAL.Interfaces;
using MoviesWeb.WebApi.DAL.Models;

namespace MoviesWeb.WebApi.DAL.Repositories
{
    public class DirectorRepository : IDirectorRepository, IDisposable
    {
        private readonly ApplicationDbContext applicationDbContext;
        private bool disposed = false;
        public DirectorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task CreateDirector(Director director)
        {
            if (director != null)
            {
                await this.applicationDbContext.Directors.AddAsync(director);
            }
        }

        public async Task DeleteDirector(int id)
        {
            var director = await this.applicationDbContext.Directors.FirstAsync(d=> d.DirectorId == id);
            if(director != null)
            {
                this.applicationDbContext.Directors.Remove(director);
            }
        }

        public async Task<Director> GetDirector(int id)
        {
            return await this.applicationDbContext.Directors.FirstAsync(d => d.DirectorId == id);
        }

        public async Task<IEnumerable<Director>> GetDirectors()
        {
            return await this.applicationDbContext.Directors.ToListAsync();
        }

        public async Task UpdateDirector(int id, Director director)
        {
            var foundDirector = await this.applicationDbContext.Directors.FirstAsync(d => d.DirectorId == id);
            if(foundDirector != null && director != null)
            {
                foundDirector.Name = director.Name;
                foundDirector.Surname = director.Surname;
                foundDirector.Sex = director.Sex;
                foundDirector.Wiek = director.Wiek;
                foundDirector.Nationality = director.Nationality;
                foundDirector.DirectorMark = director.DirectorMark;

            }
        }

        public async Task Save()
        {
            await this.applicationDbContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.applicationDbContext.Dispose();
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
