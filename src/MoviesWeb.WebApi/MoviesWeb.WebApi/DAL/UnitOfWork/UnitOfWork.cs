using MoviesWeb.WebApi.DAL.Data;
using MoviesWeb.WebApi.DAL.Interfaces;
using MoviesWeb.WebApi.DAL.Repositories;

namespace MoviesWeb.WebApi.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        private IMovieRepository movieRepository;
        private IActorRepository actorRepository;
        private IDirectorRepository directorRepository;

        public UnitOfWork(IMovieRepository? movieRepository, IActorRepository? actorRepository, IDirectorRepository? directorRepository)
        {
            this.movieRepository = movieRepository;
            this.actorRepository = actorRepository;
            this.directorRepository = directorRepository;
        }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }
        public IActorRepository ActorRepository
        {
            get
            {
                if (this.actorRepository == null)
                {
                    this.actorRepository = new ActorRepository(this.dbContext);
                }
                return this.actorRepository;
            }
        }

        public IMovieRepository MovieRepository
        {
            get
            {
                if (this.movieRepository == null)
                {
                    this.movieRepository = new MovieRepository(this.dbContext);
                }
                return this.movieRepository;
            }
        }

        public IDirectorRepository DirectorRepository 
        {
            get
            {
                if (this.directorRepository == null)
                {
                    this.directorRepository = new DirectorRepository(this.dbContext);
                }
                return this.directorRepository;
            }
        }

        public async Task Save()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
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
