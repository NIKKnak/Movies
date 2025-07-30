using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test;

namespace MovieLibrary
{
    class MovieRepository : ICrud
    {
        private List<Movie> _movies = new List<Movie>();

        public async Task<List<Movie>> SortAge()
        {
            return await Task.Run(() => _movies.OrderBy(o => o.AgeVersion).ToList());
        }

        public List<Movie> SortPrice()
        {
            List<Movie> newList = _movies.OrderBy(o => o.PriceMovie).ToList();

            return newList;
        }

        public async Task AddMovie(Movie movie)
        {
            await Task.Run(() => _movies.Add(movie));
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
