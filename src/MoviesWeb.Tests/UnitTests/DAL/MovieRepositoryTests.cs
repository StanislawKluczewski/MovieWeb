using Moq;
using MoviesWeb.WebApi.Controllers;
using MoviesWeb.WebApi.DAL.Interfaces;
using MoviesWeb.WebApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWeb.Tests.UnitTests.DAL
{
    public class MovieRepositoryTests
    {
        private readonly Mock<IMovieRepository> movieRepository;
        public MovieRepositoryTests()
        {
            movieRepository = new Mock<IMovieRepository>();
        }

        private List<Movie> moviesData = new List<Movie>{
                  new Movie
                  {
                      MovieId = 1,
                      Name= "Film1",
                      DateOfProduction = DateTime.Now,
                      Category = "Thriller",
                      MovieLength = 100,
                      BoxOffice = 10000,
                      MovieMark = 5.6,
                      ProductionCountry = "USA"
                  },
                  new Movie
                  {
                      MovieId = 2,
                      Name= "Film2",
                       DateOfProduction = new DateTime(2010,5,4),
                      Category = "Comedy",
                      MovieLength = 90,
                      BoxOffice = 25000,
                      MovieMark = 6.3,
                      ProductionCountry = "Spanish"
                  },
                  new Movie
                  {
                      MovieId = 3,
                      Name= "Film3",
                      DateOfProduction = new DateTime(1995,1,5),
                      Category = "Comedy",
                      MovieLength = 1000,
                      BoxOffice = 100000,
                      MovieMark = 5.7,
                      ProductionCountry = "Spain"
                  },
                  new Movie
                  {
                      MovieId = 4,
                      Name= "Film4",
                      DateOfProduction = new DateTime(2001,8,19),
                      Category = "Horror",
                      MovieLength = 1000,
                      BoxOffice = 100000,
                      MovieMark = 5.7,
                      ProductionCountry = "Japan"
                  }
        };
        [Fact]
        public async Task ShouldReturnAllMovies()
        {
            // Arrange
            movieRepository.Setup(x => x.GetMovies())
                .ReturnsAsync(moviesData);
            var movieContoller = new MovieController(movieRepository.Object);

            // Act
            var result = await movieContoller.GetMovies();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(moviesData.Count(), result.Count());
        }

        [Theory]
        [InlineData(1)]
        public async Task ShouldReturnSingleMovie(int id)
        {
            // Arrange
            var movies = moviesData;
            this.movieRepository.Setup(x => x.GetMovie(id))
                .ReturnsAsync(movies[0]);
            var movieContoller = new MovieController(this.movieRepository.Object);

            // Act
            var result = await movieContoller.GetMovie(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.MovieId);
            Assert.Equal("Film1", result.Name);

        }

        [Fact]
        public async Task ShouldAddMovie()
        {
            // Arrange
            this.movieRepository.Setup(x => x.CreateMovie(It.IsAny<Movie>()));
            Movie movie = new Movie()
            {
                MovieId = 5,
                Name = "Film5",
                DateOfProduction = new DateTime(2002, 9, 13),
                Category = "Animation",
                MovieLength = 90,
                BoxOffice = 100,
                MovieMark = 5.8,
                ProductionCountry = "Germany"
            };
            var movieContoller = new MovieController(movieRepository.Object);

            // Act
            await movieContoller.AddMovie(movie);

            // Assert
            Assert.NotNull(movie);
            this.movieRepository.Verify(v => v.CreateMovie(movie));
            
        }

        [Fact]
        public async Task ShouldDeleteMovie()
        {
            // Arrange
            this.movieRepository.Setup(x => x.DeleteMovie(It.IsAny<int>()));
            var movieContoller = new MovieController(movieRepository.Object);

            // Act
            await movieContoller.DeleteMovie(1);

            // Assert
            this.movieRepository.Verify(v => v.DeleteMovie(1));
        }

        [Fact]
        public async Task ShouldUpdateMovie()
        {
            // Arrange 
            this.movieRepository.Setup(x => x.UpdateMovie(moviesData[0].MovieId, It.IsAny<Movie>()));
            Movie movie = new Movie()
            {
                MovieId = 1,
                Name = "Film6",
                DateOfProduction = new DateTime(2005, 2, 7),
                Category = "Musical",
                MovieLength = 70,
                BoxOffice = 101240,
                MovieMark = 7.2,
                ProductionCountry = "France"
            };
            var movieContoller = new MovieController(movieRepository.Object);

            // Act
            await movieContoller.UpdateMovie(moviesData[0].MovieId, movie);

            // Assert
            Assert.NotEmpty(moviesData);
            Assert.Equal(moviesData[0].MovieId, movie.MovieId);
            this.movieRepository.Verify(v => v.UpdateMovie(moviesData[0].MovieId, movie));
        }


    }
}


