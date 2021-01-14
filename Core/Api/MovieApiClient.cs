using CopaFilmes.Core.Extension;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Text.Json.JsonSerializer;

namespace CopaFilmes.Core.Api
{
    public class MovieApiClient : IMovieApiClient, IDisposable
    {

        private readonly IConfigService _configService;
        private readonly HttpClient _httpClient;

        public MovieApiClient(IConfigService configService)
        {
            _configService = configService;
            _httpClient = new HttpClient();
        }

        public void Dispose()
        {
            _httpClient.CancelPendingRequests();
            _httpClient.Dispose();
        }

        public async Task<List<Movie>> GetAllAvailableMoviesAsync()
        {
            Config config = await _configService.GetConfigAsync();
            var url = config.MovieApiUrlBase + "/filmes";
            var jsonOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            return await _httpClient.GetAsync(url)
                    .SelectMany(response => response.Content.ReadAsStringAsync())
                    .Select(body => Deserialize<List<Movie>>(body, jsonOptions));
        }
    }
}
