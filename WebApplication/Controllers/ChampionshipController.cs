using CopaFilmes.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Controllers;

namespace CopaFilmes.WebApplication.Controllers
{
    [ApiController]
    [Route("api/v1/championships")]
    public class ChampionshipController : ControllerBase
    {
        private readonly IChampionshipService _championshipService;
        public ChampionshipController(IChampionshipService championshipService)
        {
            _championshipService = championshipService;
        }

        [HttpPost]
        public async Task<List<MovieTO>> ClassifyAsync([FromBody][Required][MinLength(8)][MaxLength(8)] ISet<string> ids)
        {
            var movies = (await _championshipService.ClassifyAsync(ids))
                               .Select(MovieTO.Of).ToList();
            return await Task.FromResult(movies);
        }

    }
}
