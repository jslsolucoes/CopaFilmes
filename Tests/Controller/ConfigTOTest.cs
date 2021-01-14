using Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Controllers;

namespace CopaFilmes.Tests.Controller
{
    [TestClass]
    public class ConfigTOTest
    {
        [TestMethod]
        public void TestBuilderWithConfig()
        {
            int maxMovies = 8;
            Config config = new Config()
            {
                MaxMovies = maxMovies
            };
            var configTO = ConfigTO.Of(config);
            Assert.AreEqual(maxMovies, configTO.MaxMovies);
        }


    }
}
