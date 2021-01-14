using CopaFilmes.Core.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Core.Service
{
    public interface IMovieService
    {
        /// <summary>
        ///     Retrieve all available movies for create new championships
        /// </summary>
        /// <returns></returns>
        public Task<List<Movie>> GetAllAvailableMoviesAsync();
    }
}
