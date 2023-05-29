using Microsoft.AspNetCore.Mvc;
using MoviesWeb.WebApi.DAL.Interfaces;
using MoviesWeb.WebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet("movies")]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await movieRepository.GetMovies();
        }

        [HttpGet("movies/{id}")]
        public async Task<Movie> GetMovie(int id)
        {
            var result = await movieRepository.GetMovie(id);
            return result;
        }

        [HttpPost("addMovie")]
        public async Task AddMovie(Movie movie)
        {
            await movieRepository.CreateMovie(movie);
            await movieRepository.Save();
        }

        [HttpPut("updateMovie")]
        public async Task UpdateMovie(int id, Movie movie)
        {
            await movieRepository.UpdateMovie(id, movie);
            await movieRepository.Save();
        }

        [HttpDelete("deleteMovie")]
        public async Task DeleteMovie(int id)
        {
            await movieRepository.DeleteMovie(id);
            await movieRepository.Save();
        }


    }
}
