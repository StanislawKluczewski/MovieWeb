using Moq;
using MoviesWeb.Tests.UnitTests.DAL;
using MoviesWeb.Tests.UnitTests.FakeMocks;
using MoviesWeb.WebApi.BLL.Interfaces;
using MoviesWeb.WebApi.BLL.Services;
using MoviesWeb.WebApi.DAL.Interfaces;
using MoviesWeb.WebApi.DAL.Models;
using MoviesWeb.WebApi.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWeb.Tests.UnitTests.BLL
{
    public class ActorServiceTests
    {
        private readonly Mock<IActorRepository> mockActorRepository;
        private readonly IActorService actorServiceMock;
        public ActorServiceTests()
        {
            this.mockActorRepository = new Mock<IActorRepository>();
            this.actorServiceMock = new ActorServiceMock();
        }

        [Fact]
        public async Task ShouldCountActorMovies()
        {
            // Arrange
            Actor actor = new Actor() { ActorId = 1, ActorMovies = new List<Movie> { new Movie { MovieId = 1, Name = "Movie1" } } };
            this.mockActorRepository.Setup(x => x.GetActor(actor.ActorId))
                                 .ReturnsAsync(actor);
            var unitOfWork = new UnitOfWork(null, this.mockActorRepository.Object, null);
            var actorService = new ActorService(unitOfWork);

            // Act
            var result = await Task.FromResult(actorService.GetActorMovies(actor));

            // Assert
            Assert.Equal(1, result.Result.Count());
            Assert.Equal(actor.ActorMovies, result.Result);
        }

        [Fact]
        public async Task ShouldCheckAddingMovieToActor()
        {
            // Arrange
            Actor actor = new Actor() { ActorId = 1, ActorMovies = new List<Movie> { } };
            this.mockActorRepository.Setup(x => x.GetActor(actor.ActorId))
                                    .ReturnsAsync(actor);
            var unitOfWork = new UnitOfWork(null, this.mockActorRepository.Object, null);
            var actorService = new ActorService(unitOfWork);

            // Act
            await actorService.AddMovieToActor(new Movie { MovieId = 1, Name = "Movie1" }, actor);
            var result = await Task.FromResult(actorService.GetActorMovies(actor));
            
            // Assert
            Assert.Equal(result.Result.Count(), 1);
            Assert.Equal(result.Result, actor.ActorMovies);
        }

        [Fact]
        public async Task ShouldCheckChangingActorMark()
        {
            // Arrange
            Actor actor = new Actor() { ActorId = 1, Name = "Bruce", Surname="Willis", Sex = "Man", ActorMark = 8.8 };
            this.mockActorRepository.Setup(x => x.GetActor(actor.ActorId))
                                    .ReturnsAsync(actor);
            var unitOfWork = new UnitOfWork(null, this.mockActorRepository.Object,null);
            var actorService = new ActorService(unitOfWork);

            // Act
            await actorService.ChangeActorMark(actor, 8.2);

            // Assert
            Assert.Equal(actor.ActorMark, 8.1999999999999993);
        }
    }
}
