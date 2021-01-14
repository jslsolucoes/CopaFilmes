using System;
using System.Text.Json.Serialization;

namespace CopaFilmes.Core.Api
{
    public class Movie : IComparable<Movie>, IEquatable<Movie>
    {

        public Movie()
        {

        }

        private Movie(string id) => (Id) = (id);

        private Movie(string id, string title, double rating) =>
             (Id, Title, Rating) = (id, title, rating);

        private Movie(string id, string title, int year) =>
             (Id, Title, Year) = (id, title, year);

        public static Movie Of(string id, string title, double rating)
        {
            return new Movie(id, title, rating);
        }

        public static Movie Of(string id, string title, int year)
        {
            return new Movie(id, title, year);
        }

        public static Movie Of(string id)
        {
            return new Movie(id);
        }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("titulo")]
        public string Title { get; set; }

        [JsonPropertyName("ano")]
        public int Year { get; set; }

        [JsonPropertyName("nota")]
        public double Rating { get; set; }
        public int CompareTo(Movie movieTO)
        {
            int compareTo = Rating.CompareTo(movieTO.Rating);
            if (compareTo == 0) return movieTO.Title.CompareTo(Title);
            return compareTo;
        }

        public bool Equals(Movie movie)
        {
            return movie != null && Id == movie.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Movie movie && this.Equals(movie);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }



}
