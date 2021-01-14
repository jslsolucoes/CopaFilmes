using Core.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CopaFilmes.Tests.Service
{
    [TestClass]
    public class ConfigServiceTest
    {

        private Mock<IConfiguration> _configuration;
        private IConfigService _configService;

        [TestInitialize]
        public void Before()
        {
            _configuration = new Mock<IConfiguration>();
            _configService = new ConfigService(_configuration.Object);
        }

        [TestMethod]
        public async Task TestGetConfigs()
        {

            _configuration.SetupGet(x => x[It.Is<string>(s => s == "External:MovieApiUrlBase")])
                    .Returns("http://someapi");
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "Configs:MaxMovies")])
                   .Returns("8");

            var config = await _configService.GetConfigAsync();
            Assert.AreEqual(8, config.MaxMovies);
            Assert.AreEqual("http://someapi", config.MovieApiUrlBase);
        }



    }
}
