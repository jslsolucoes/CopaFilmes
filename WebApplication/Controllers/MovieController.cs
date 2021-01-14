using CopaFilmes.Core.Extension;
using CopaFilmes.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Controllers;

namespace CopaFilmes.WebApplication.Controllers
{
    [ApiController]
    [Route("api/v1/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<List<MovieTO>> GetAllAvailableMoviesAsync()
        {
            var movies = (await _movieService.GetAllAvailableMoviesAsync())
                                .Select(MovieTO.Of).ToList();
            return await Task.FromResult(movies);
        }

    }
}
