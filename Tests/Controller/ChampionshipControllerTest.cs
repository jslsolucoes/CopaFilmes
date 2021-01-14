using CopaFilmes.Core.Api;
using CopaFilmes.Core.Service;
using CopaFilmes.WebApplication.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Tests.Controller
{
    [TestClass]
    public class ChampionshipControllerTest
    {

        private Mock<IChampionshipService> _championshipService;
        private ChampionshipController _championshipController;

        [TestInitialize]
        public void Before()
        {
            _championshipService = new Mock<IChampionshipService>();
            _championshipController = new ChampionshipController(_championshipService.Object);
        }

        [TestMethod]
        public async Task TestClassifyAsync()
        {
            //arrange
            ISet<string> ids = new HashSet<string>() { "t123", "t1234" };
            List<Movie> movies = ids.Select(Movie.Of).ToList();
            _championshipService.Setup(championshipService => championshipService.ClassifyAsync(ids))
                    .ReturnsAsync(movies);
            //act
            var movieTOs = await _championshipController.ClassifyAsync(ids);

            //verify
            CollectionAssert.Contains(movies, Movie.Of("t123"));
            CollectionAssert.Contains(movies, Movie.Of("t1234"));
            _championshipService.Verify(championshipService => championshipService.ClassifyAsync(ids), Times.Once());
        }
    }
}
