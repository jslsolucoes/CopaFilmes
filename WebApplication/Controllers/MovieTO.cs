using CopaFilmes.Core.Api;
using System.Text.Json.Serialization;

namespace WebApplication.Controllers
{
    public class MovieTO
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("titulo")]
        public string Title { get; }

        [JsonPropertyName("ano")]
        public int Year { get; }

        public MovieTO() { }

        private MovieTO(string id, string title, int year) =>
             (Id, Title, Year) = (id, title, year);

        public static MovieTO Of(Movie movie)
        {
            return new MovieTO(movie.Id, movie.Title, movie.Year);
        }
    }
}
