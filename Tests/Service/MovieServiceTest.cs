using CopaFilmes.Core.Api;
using CopaFilmes.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CopaFilmes.Tests.Service
{
    [TestClass]
    public class MovieServiceTest
    {

        private Mock<IMovieApiClient> _movieApiClient;
        private IMovieService _movieService;

        [TestInitialize]
        public void Before()
        {
            _movieApiClient = new Mock<IMovieApiClient>();
            _movieService = new MovieService(_movieApiClient.Object);
        }

        [TestMethod]
        public async Task TestGetAllAvailableMovies()
        {
            await _movieService.GetAllAvailableMoviesAsync();
            _movieApiClient.Verify(s => s.GetAllAvailableMoviesAsync(), Times.Once());
        }



    }
}
