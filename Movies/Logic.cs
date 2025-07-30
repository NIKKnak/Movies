using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary
{
    internal class Logic
    {
        public async Task Start()
        {
            MovieRepository movieRepository = new MovieRepository();

            #region Тестовые данные

            Movie movie1 = new Movie(name: "Маска", acter: "Джим Керри", price: 100, age: 12, rating: 88);
            Movie movie2 = new Movie(name: "История игрушек", acter: "Игрушки", price: 150, age: 6, rating: 70);
            Movie movie3 = new Movie(name: "Коммандо", acter: "Арнольд Шварценеггер", price: 200, age: 18, rating: 76);
            await movieRepository.AddMovie(movie: movie1);
            await movieRepository.AddMovie(movie: movie2);
            await movieRepository.AddMovie(movie: movie3);

            #endregion Тестовые данные

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Выберите действие\n" +
                                        $"1 - Добавить фильм\n" +
                                        $"2 - Удалить фильм\n" +
                                        $"3 - Испраить информацию о фильме\n" +
                                        $"4 - Списох всех фильмов");

                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Заполните информацию о фильме через пробел в порядке\n" +
                                                "Название, Актер, Цена, Возрастные ограничения, Рейтинг");
                        try
                        {
                            string[] dataToCreate = await SplitCurrentData();

                            Movie movie = new Movie(name: dataToCreate[0], acter: dataToCreate[1], price: dataToCreate[2], age: dataToCreate[3], rating: dataToCreate[4]);
                            await movieRepository.AddMovie(movie: movie);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Произошла ошибка: {ex.Message}"); // заменить на пользовательский Exception
                        }
                        break;

                    case ConsoleKey.D2:
                        try
                        {
                            Console.Clear();
                            movieRepository.PrintAllMovies();
                            Console.WriteLine();
                            Console.WriteLine("Введите id фильма, который хотите удалить");
                            int deleteNumber = Convert.ToInt32(Console.ReadLine());
                            movieRepository.DeleteMovie(id: deleteNumber);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ошибка ввода");
                        }
                        break;

                    case ConsoleKey.D3:
                        try
                        {
                            Console.Clear();
                            movieRepository.PrintAllMovies();
                            Console.WriteLine();
                            Console.WriteLine("Введите id фильма, описание которого хотите изменить");
                            int idNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine("Заполните информацию о фильме через пробел в порядке\n" +
                                "Название, Актер, Цена, Возрастные ограничения, Рейтинг");
                            string[] dataToUpdate = await SplitCurrentData();
                            movieRepository.UpdateMovie(
                                                        id: idNumber,
                                                        newName: dataToUpdate[0],
                                                        newActer: dataToUpdate[1],
                                                        newPrice: Convert.ToInt32(dataToUpdate[2]),
                                                        newAge: Convert.ToInt32(dataToUpdate[3]),
                                                        newRating: Convert.ToInt32(dataToUpdate[4])
                                                        );
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ошибка ввода");
                        }
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        movieRepository.PrintAllMovies();
                        Console.WriteLine();
                        Console.WriteLine("1 - Отсортировать по возрасту");
                        var case4Key = Console.ReadKey(true).Key;
                        if (case4Key == ConsoleKey.D1)
                        {
                            Console.Clear();
                            List<Movie> newSort = await movieRepository.SortAge();
                            foreach (var item in newSort)
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }
                        Console.ReadKey();
                        break;
                }
            }
        }

        private async Task<string[]> SplitCurrentData()
        {
            string currentData = await Task.Run(() => Console.ReadLine());
            string[] arrayData = currentData.Split(' ');
            if (arrayData.Length != 5)
            {
                Console.WriteLine("Некорректный ввод данных");
                Console.ReadKey();
            }
            return arrayData;
        }
    }
}
