using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    public class Movie
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public string Acter { get; set; }
        public int PriceMovie { get; set; }
        public int AgeVersion { get; set; }
        public int Rating { get; set; }

        public Movie(string name, string acter, int price, int age, int rating)
        {
            Id = _id++;
            this.Name = name;
            this.Acter = acter;
            this.PriceMovie = price;
            this.AgeVersion = age;
            this.Rating = rating;
        }

        public Movie(string name, string acter, string price, string age, string rating)
        {
            try
            {
                Id = _id++;
                this.Name = name;
                this.Acter = acter;
                this.PriceMovie = Convert.ToInt32(price);
                this.AgeVersion = Convert.ToInt32(age);
                this.Rating = Convert.ToInt32(rating);
            }
            catch (Exception)
            {
                Console.Clear();
                throw new Exception("Данные введены с ошибкой");
            }
        }

        public override string ToString()
        {
            return $"Id = {Id}|| Name = {Name}|| Acter = {Acter}|| Price = {PriceMovie}|| AgeVersion = {AgeVersion}|| Rating = {Rating}";
        }
    }
}
