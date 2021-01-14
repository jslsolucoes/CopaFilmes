using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Core.Api
{
    public interface IMovieApiClient
    {
        /// <summary>
        ///     Retrieve available movies from external backend
        /// </summary>
        /// <returns></returns>
        public Task<List<Movie>> GetAllAvailableMoviesAsync();
    }
}
