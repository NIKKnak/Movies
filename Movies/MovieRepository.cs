using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    class MovieRepository : ICrud
    {
        private List<Movie> _movies = new List<Movie>();

        public List<Movie> SortAge()
        {
            List<Movie> newList = (from i in _movies
                                   orderby i.AgeVersion
                                   select i).ToList();
            return newList;
        }

        public List<Movie> SortPrice()
        {
            List<Movie> newList = (from i in _movies
                                   orderby i.PriceMovie
                                   select i).ToList();
            return newList;
        }

        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public void PrintAllMovies()
        {
            foreach (var movie in _movies)
            {
                Console.WriteLine(movie);
            }
        }

        public bool UpdateMovie(int id, string newName, string newActer, int newPrice, int newAge, int newRating)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return false;

            movie.Name = newName;
            movie.Acter = newActer;
            movie.PriceMovie = newPrice;
            movie.AgeVersion = newAge;
            movie.Rating = newRating;
            return true;
        }

        public void DeleteMovie(int id)
        {
            var movie = _movies.FirstOrDefault(t => t.Id == id);
            if (movie != null)
            {
                _movies.Remove(movie);
            }
        }

    }
}