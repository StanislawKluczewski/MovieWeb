using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using MoviesWeb.WebApi.DAL.Models;

namespace MoviesWeb.WebApi.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration configuration;
        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("MoviesDatabase");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
        }
    }
}