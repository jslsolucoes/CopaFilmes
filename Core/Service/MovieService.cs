using CopaFilmes.Core.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Core.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieApiClient _movieApiClient;

        public MovieService(IMovieApiClient movieApiClient)
        {
            _movieApiClient = movieApiClient;
        }
        public Task<List<Movie>> GetAllAvailableMoviesAsync()
        {
            return _movieApiClient.GetAllAvailableMoviesAsync();
        }

    }
}
