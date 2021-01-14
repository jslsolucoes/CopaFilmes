using Core.Service;
using System.Text.Json.Serialization;

namespace WebApplication.Controllers
{
    public class ConfigTO
    {
        [JsonPropertyName("maxMovies")]
        public int MaxMovies { get; }

        public ConfigTO() { }

        private ConfigTO(int maxMovies) =>
             (MaxMovies) = (maxMovies);

        public static ConfigTO Of(Config config)
        {
            return new ConfigTO(config.MaxMovies);
        }
    }
}
