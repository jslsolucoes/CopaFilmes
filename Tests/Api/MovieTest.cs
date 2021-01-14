using CopaFilmes.Core.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CopaFilmes.Tests.Api
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        public void TestBuilderWithId()
        {
            string id = "t123";
            Movie movie = Movie.Of(id);
            Assert.AreEqual(id, movie.Id);
        }

        [TestMethod]
        public void TestBuilderWithIdTitleRating()
        {
            string id = "t123";
            string title = "title1";
            double rating = 1.2;
            Movie movie = Movie.Of(id, title, rating);
            Assert.AreEqual(id, movie.Id);
            Assert.AreEqual(title, movie.Title);
            Assert.AreEqual(rating, movie.Rating);
        }

    }
}
