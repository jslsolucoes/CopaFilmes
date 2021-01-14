using Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Controllers;

namespace CopaFilmes.WebApplication.Controllers
{
    [ApiController]
    [Route("api/v1/configs")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _iconfigService;

        public ConfigController(IConfigService iconfigService)
        {
            _iconfigService = iconfigService;
        }

        [HttpGet]
        public async Task<ConfigTO> GetConfig()
        {
            Config config = await _iconfigService.GetConfigAsync();
            return await Task.FromResult(ConfigTO.Of(config));
        }

    }
}
