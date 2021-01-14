using System.Threading.Tasks;

namespace Core.Service
{
    public interface IConfigService
    {
        /// <summary>
        ///     Retrieve application configuration
        /// </summary>
        /// <returns></returns>
        public Task<Config> GetConfigAsync();

    }
}
