using CopaFilmes.WebApplication.Controllers;
using Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using WebApplication.Controllers;

namespace CopaFilmes.Tests.Controller
{
    [TestClass]
    public class ConfigControllerTest
    {

        private Mock<IConfigService> _configService;
        private ConfigController _configController;

        [TestInitialize]
        public void Before()
        {
            _configService = new Mock<IConfigService>();
            _configController = new ConfigController(_configService.Object);
        }

        [TestMethod]
        public async Task TestGetConfig()
        {
            //arrange
            _configService.Setup(configService => configService.GetConfigAsync())
                    .ReturnsAsync(new Config()
                    {
                        MaxMovies = 8
                    });

            //act
            ConfigTO configTO = await _configController.GetConfig();

            //verify
            Assert.AreEqual(8, configTO.MaxMovies);
            _configService.Verify(configService => configService.GetConfigAsync(), Times.Once());
        }
    }
}
