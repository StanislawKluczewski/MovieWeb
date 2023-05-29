using Microsoft.EntityFrameworkCore;
using MoviesWeb.WebApi.DAL.Data;
using MoviesWeb.WebApi.DAL.Interfaces;
using MoviesWeb.WebApi.DAL.Models;

namespace MoviesWeb.WebApi.DAL.Repositories
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        private readonly ApplicationDbContext dbContext;
        private bool disposed = false;
        public MovieRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task CreateMovie(Movie movie)
        {
            if (movie != null)
            {
                await this.dbContext.Movies.AddAsync(movie);
            }
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await this.dbContext.Movies.FirstAsync(m => m.MovieId == id);
            if (movie != null)
            {
                this.dbContext.Movies.Remove(movie);
            }
        }

        public async Task<Movie> GetMovie(int id)
        {
            var result = await this.dbContext.Movies.FirstAsync(m => m.MovieId == id);
            return result;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await this.dbContext.Movies.ToListAsync();
        }

        public async Task UpdateMovie(int id, Movie movie)
        {
            var foundMovie = await this.dbContext.Movies.FirstAsync(m => m.MovieId == id);
            if (foundMovie != null && movie != null)
            {
                foundMovie.Name = movie.Name;
                foundMovie.DateOfProduction = movie.DateOfProduction;
                foundMovie.Category = movie.Category;
                foundMovie.MovieLength = movie.MovieLength;
                foundMovie.BoxOffice = movie.BoxOffice;
                foundMovie.MovieMark = movie.MovieMark;
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
