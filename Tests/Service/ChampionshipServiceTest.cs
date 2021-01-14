using CopaFilmes.Core.Api;
using CopaFilmes.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Tests.Service
{
    [TestClass]
    public class ChampionshipServiceTest
    {

        private IChampionshipService _championshipService;
        private Mock<IMovieApiClient> _movieApiClient;

        [TestInitialize]
        public void Before()
        {
            _movieApiClient = new Mock<IMovieApiClient>();
            _championshipService = new ChampionshipService(_movieApiClient.Object);
        }

        [TestMethod]
        public async Task TestForFinals()
        {
            //arrange
            List<Movie> movies = new List<Movie>() {
                Movie.Of("tt3606756", "Os Incríveis 2", 8.5),
                Movie.Of("tt4881806", "Jurassic World: Reino Ameaçado",6.7),
                Movie.Of("tt5164214", "Oito Mulheres e um Segredo",6.3),
                Movie.Of("tt7784604", "Hereditário",7.8),
                Movie.Of("tt4154756", "Vingadores: Guerra Infinita",8.8),
                Movie.Of("tt5463162", "Deadpool 2",6.7),
                Movie.Of("tt3778644", "Han Solo: Uma História Star Wars",7.2),
                Movie.Of("tt3501632", "Thor: Ragnarok",7.9)
            };
            _movieApiClient.Setup(movieApiClient => movieApiClient.GetAllAvailableMoviesAsync()).ReturnsAsync(movies);

            //act
            ISet<string> ids = movies.Select(movie => movie.Id).ToHashSet();
            List<Movie> actual = await _championshipService.ClassifyAsync(ids);

            //verify
            List<Movie> expected = new List<Movie>() {
                Movie.Of("tt4154756"),
                Movie.Of("tt3606756")
            };
            CollectionAssert.AreEqual(expected, actual);
            _movieApiClient.Verify(movieApiClient => movieApiClient.GetAllAvailableMoviesAsync(), Times.Once());
        }

        [TestMethod]
        public async Task TestForFinalsWhenRatingIsEven()
        {
            //arrange
            List<Movie> movies = new List<Movie>() {
                Movie.Of("tt3606756", "Os Incríveis 2", 8.5),
                Movie.Of("tt4881806", "Jurassic World: Reino Ameaçado",6.7),
                Movie.Of("tt5164214", "Oito Mulheres e um Segredo",6.3),
                Movie.Of("tt7784604", "Hereditário",7.8),
                Movie.Of("tt4154756", "Vingadores: Guerra Infinita",8.5),
                Movie.Of("tt5463162", "Deadpool 2",6.7),
                Movie.Of("tt3778644", "Han Solo: Uma História Star Wars",7.2),
                Movie.Of("tt3501632", "Thor: Ragnarok",7.9)
            };
            _movieApiClient.Setup(movieApiClient => movieApiClient.GetAllAvailableMoviesAsync()).ReturnsAsync(movies);

            //act
            ISet<string> ids = movies.Select(movie => movie.Id).ToHashSet();
            List<Movie> actual = await _championshipService.ClassifyAsync(ids);

            //verify
            List<Movie> expected = new List<Movie>() {
                Movie.Of("tt3606756"),
                Movie.Of("tt4154756"),
            };
            CollectionAssert.AreEqual(expected, actual);
            _movieApiClient.Verify(movieApiClient => movieApiClient.GetAllAvailableMoviesAsync(), Times.Once());
        }

    }
}
