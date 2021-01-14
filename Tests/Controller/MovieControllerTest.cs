using CopaFilmes.Core.Api;
using CopaFilmes.Core.Service;
using CopaFilmes.WebApplication.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Tests.Controller
{
    [TestClass]
    public class MovieControllerTest
    {

        private Mock<IMovieService> _movieService;
        private MovieController _movieController;

        [TestInitialize]
        public void Before()
        {
            _movieService = new Mock<IMovieService>();
            _movieController = new MovieController(_movieService.Object);
        }

        [TestMethod]
        public async Task TestGetAllAvailableMovies()
        {
            //arrange
            _movieService.Setup(movieService => movieService.GetAllAvailableMoviesAsync())
                    .ReturnsAsync(new List<Movie>());

            //act
            await _movieController.GetAllAvailableMoviesAsync();

            //verify
            _movieService.Verify(movieService => movieService.GetAllAvailableMoviesAsync(), Times.Once());
        }
    }
}
