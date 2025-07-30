using System.Threading.Tasks;

namespace MovieLibrary
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Logic logic = new Logic();
            await logic.Start();
        }

    }
}
