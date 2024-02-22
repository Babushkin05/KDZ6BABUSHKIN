using System;
using GamersLib;
using System.Text.Json;
namespace KDZ6BABUSHKIN
{
	/// <summary>
	/// Interface for comfortable view of gamers.
	/// </summary>
	public interface IShowTable
	{
		/// <summary>
		/// Show table of gamers.
		/// </summary>
		/// <param name="gamers">List to show.</param>
		protected static void ShowTable(List<Gamer>? gamers)
		{
			Console.Clear();

			// Head of table/
			string head = "player_id      username       level          game_score     achievements   guild";
			Console.WriteLine(head);

			// Fields of gamer.
			string[] fields = new string[] { "player_id", "username", "level", "game_score", "achievements", "guild" };

			// Writing fields in table.
			foreach(Gamer gamer in gamers)
			{
				foreach(string field in fields)
				{
					string? toWrite = "";

					if(field!= "achievements")
					{
						toWrite = gamer[field].ToString();
					}

					else
					{
						foreach(Achievement ach in (List<Achievement>)gamer[field])
						{
							toWrite += ach.achievement_id + ";";
						}
						toWrite = toWrite[..^1];
					}

					// Cutting string for a field size/
                    if (toWrite.Length > 14)
                        toWrite = toWrite[..6] + ".." + toWrite[^6..];
                    while (toWrite.Length < 15)
                        toWrite += ' ';

                    Console.Write(toWrite);
                }
				Console.Write("\n");
			}
			Console.ReadKey();
		}

	}
}

