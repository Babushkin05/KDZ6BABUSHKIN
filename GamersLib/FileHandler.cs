using System;
using System.Text.Json;
namespace GamersLib
{
	/// <summary>
	/// Class for saving and reading json.
	/// </summary>
	public static class FileHandler
	{
		// List of gamers
		internal static List<Gamer>? gamers;

		// Name of file
		public static string? nameOfJson;

		// Incorrect chars for file name.
        private static char sep = Path.DirectorySeparatorChar;

		/// <summary>
		/// Read list of gamers from json.
		/// </summary>
		/// <returns>List of gamers.</returns>
        public static List<Gamer>? GetListOfGamers()
		{
			Achievement.GamersReachedAchievement = new Dictionary<string, int>();

			//Getting name of file.
            nameOfJson = User.GetNameOfJson();

			// Trying read file.
			try
			{
                string jsonString = File.ReadAllText($"..{sep}..{sep}..{sep}..{sep}{nameOfJson}.json");
				try
				{
                    gamers = JsonSerializer.Deserialize<List<Gamer>>(jsonString);
                }
                catch(Exception e)
				{
					Console.Write(e.Message);
					return new List<Gamer>();
				}
            }
			catch
			{
                GetListOfGamers();
			}

			return gamers;
		}

		/// <summary>
		/// Saving json file.
		/// </summary>
		public static void SaveFile()
		{
			// Takes name of file from user.
			nameOfJson = User.GetNameOfJson();

			// Use SaveFile with name.
			SaveFile(nameOfJson);
		}

		/// <summary>
		/// Saving json file.
		/// </summary>
		/// <param name="nameOfJson_">Name to save file.</param>
		public static void SaveFile(string? nameOfJson_)
		{
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(gamers,options);
            File.WriteAllText($"..{sep}..{sep}..{sep}..{sep}{nameOfJson_}.json", jsonString);
		}
	}
}

