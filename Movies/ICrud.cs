using MovieLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface ICrud
    {
        Task AddMovie(Movie movie);
        void PrintAllMovies();
        bool UpdateMovie(int id, string newName, string newActer, int newPrice, int newAge, int newRating);
        void DeleteMovie(int id);

    }
}
