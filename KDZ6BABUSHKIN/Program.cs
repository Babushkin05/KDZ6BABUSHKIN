using System.Text.Json;
using GamersLib;
namespace KDZ6BABUSHKIN
{
    /// <summary>
    /// Main class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Method that starting program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Repeating Solution.
            do
            {
                // Getting list of gamers from a file.
                List<Gamer>? gamers = FileHandler.GetListOfGamers();

                // Creating new menu.
                Menu menu = new Menu(ref gamers);

                // Launching menu.
                menu.StartMenu();

                Console.WriteLine("type enter to repeat program or another key to quit");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
            

        }
    }
}