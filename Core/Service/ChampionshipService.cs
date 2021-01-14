using CopaFilmes.Core.Api;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Core.Service
{
    public class ChampionshipService : IChampionshipService
    {

        private readonly IMovieApiClient _movieApiClient;

        public ChampionshipService(IMovieApiClient movieApiClient)
        {
            _movieApiClient = movieApiClient;
        }
        public async Task<List<Movie>> ClassifyAsync(ISet<string> ids)
        {
            return await Classify(await SearchForMoviesWithIds(ids));
        }

        private async Task<List<Movie>> SearchForMoviesWithIds(ISet<string> ids)
        {
            return (await _movieApiClient.GetAllAvailableMoviesAsync())
                    .Where(movie => ids.Contains(movie.Id))
                    .ToList();
        }
        private Task<List<Movie>> Classify(List<Movie> movies)
        {
            var orderedByTitle = SortByTitle(movies);
            var keys = CreateKeys(orderedByTitle, CreateRootKeyDelegate);
            var winners = Winners(keys);
            while (winners.Count > 2)
            {
                keys = CreateKeys(winners, CreateWinnerKeyDelegate);
                winners = Winners(keys);
            };
            var finalists = winners.OrderByDescending(winner => winner).ToList();
            return Task.FromResult(finalists);
        }

        private List<Movie> SortByTitle(List<Movie> movies)
        {
            return movies.OrderBy(movie => movie.Title).ToList();
        }

        private List<Movie> Winners(List<KeyValuePair<string, List<Movie>>> keys)
        {
            return keys.Select(key => key.Value.Max()).ToList();
        }

        private delegate KeyValuePair<string, List<Movie>> KeyCreationDelegate(LinkedList<Movie> movies);

        private List<KeyValuePair<string, List<Movie>>> CreateKeys(List<Movie> movies, KeyCreationDelegate keyCreationDelegate)
        {
            var keys = new List<KeyValuePair<string, List<Movie>>>();
            var newMovies = new LinkedList<Movie>(movies);
            while (newMovies.Any())
            {
                keys.Add(keyCreationDelegate(newMovies));
            }
            return keys;
        }

        private KeyValuePair<string, List<Movie>> CreateWinnerKeyDelegate(LinkedList<Movie> movies)
        {
            var first = movies.First.Value;
            movies.RemoveFirst();
            var next = movies.First.Value;
            movies.RemoveFirst();
            var key = KeyForPhase(first, next);
            return new KeyValuePair<string, List<Movie>>(key, new List<Movie>() { first, next });
        }

        private KeyValuePair<string, List<Movie>> CreateRootKeyDelegate(LinkedList<Movie> movies)
        {
            var first = movies.First.Value;
            movies.RemoveFirst();
            var last = movies.Last.Value;
            movies.RemoveLast();
            var key = KeyForPhase(first, last);
            return new KeyValuePair<string, List<Movie>>(key, new List<Movie>() { first, last });
        }

        private string KeyForPhase(Movie first, Movie last)
        {
            return first.Title + " vs " + last.Title;
        }
    }
}
