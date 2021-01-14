using CopaFilmes.Core.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Core.Service
{
    public interface IChampionshipService
    {
        /// <summary>
        ///     Create a new championship and return finalists ordered by position
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<Movie>> ClassifyAsync(ISet<string> ids);
    }
}
