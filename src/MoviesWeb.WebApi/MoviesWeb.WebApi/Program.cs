using MoviesWeb.WebApi.BLL.Interfaces;
using MoviesWeb.WebApi.BLL.Services;
using MoviesWeb.WebApi.DAL.Data;
using MoviesWeb.WebApi.DAL.Interfaces;
using MoviesWeb.WebApi.DAL.Repositories;
using MoviesWeb.WebApi.DAL.UnitOfWork;

namespace MoviesWeb.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.AddScoped<IActorRepository, ActorRepository>();
            builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();  
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IActorService, ActorService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}