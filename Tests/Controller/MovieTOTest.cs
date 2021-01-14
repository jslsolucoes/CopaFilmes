using CopaFilmes.Core.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Controllers;

namespace CopaFilmes.Tests.Controller
{
    [TestClass]
    public class MovieTOTest
    {
        [TestMethod]
        public void TestBuilderWithMovie()
        {
            string id = "t123";
            string title = "movie1";
            int year = 1984;
            Movie movie = Movie.Of(id, title, year);
            var movieTO = MovieTO.Of(movie);
            Assert.AreEqual(id, movieTO.Id);
            Assert.AreEqual(title, movieTO.Title);
            Assert.AreEqual(year, movieTO.Year);
        }


    }
}
