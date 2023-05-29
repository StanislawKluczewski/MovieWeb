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
        public async Task ShouldCountActors()
        {
            var actor = new Actor() { ActorId = 1, Name = "Actor1" };
            var actor1 = new Actor() { ActorId = 2, Name = "Actor2" };


        }

        [Fact]
        public async Task ShouldCheckDeletingActors()
        {

        }

        [Fact]
        public async Task ShouldCheckAddingMoviesToActors()
        {
            Actor actor1 = new Actor() { ActorId = 1, Name = "Actor1" };
            Actor actor2 = new Actor() { ActorId = 2, Name = "Actor2" };
            this.mockActorRepository.Setup(x=> x.GetActors()).ReturnsAsync(new List<Actor>() { actor1, actor2 });

            var unitOfWork = new UnitOfWork(null, this.mockActorRepository.Object,null);
            var actorService = new ActorService(unitOfWork);

            await actorService.AddMovieToActor(new Movie() { MovieId = 1, Name = "Film1"}, actor1.ActorId);
            await actorService.AddMovieToActor(new Movie() { MovieId = 2, Name = "Film2" }, actor1.ActorId);
            await actorService.AddMovieToActor(new Movie() { MovieId = 3, Name = "Film3" }, actor1.ActorId);
            await actorService.AddMovieToActor(new Movie() { MovieId = 1, Name = "Film1" }, actor2.ActorId);
            var resultActor1 = await actorService.GetActorMovies(actor1.ActorId);
            var resultActor2 = await actorService.GetActorMovies(actor1.ActorId);

            Assert.Equal(3, resultActor1.Count());
            Assert.Equal(1, resultActor2.Count());
        }


    }
}
