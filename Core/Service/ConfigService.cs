using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Core.Service
{
    public class ConfigService : IConfigService
    {

        private readonly IConfiguration _configuration;
        public ConfigService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<Config> GetConfigAsync()
        {
            var config = new Config
            {
                MovieApiUrlBase = _configuration["External:MovieApiUrlBase"],
                MaxMovies = int.Parse(_configuration["Configs:MaxMovies"])
            };
            return Task.FromResult(config);
        }
    }
}
