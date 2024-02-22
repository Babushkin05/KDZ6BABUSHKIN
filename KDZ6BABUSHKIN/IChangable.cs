using System;
using GamersLib;
namespace KDZ6BABUSHKIN
{
	/// <summary>
	/// Interface for a changing gamer field.
	/// </summary>
	public interface IChangable
	{
		/// <summary>
		/// Change gamer field.
		/// </summary>
		/// <param name="gamers">List of gamers to change.</param>
		/// <returns>Changed list.</returns>
		protected static List<Gamer> ChangeGamers(ref List<Gamer>? gamers)
		{
			// Choosing what gamer must be changed.
			int selectedId = gamers.Count; ;
			do
			{
				Console.Write($"What player you want to change ( by id, from 1 to {gamers.Count}) :: ");
			} while (!int.TryParse(Console.ReadLine(), out selectedId) || selectedId >= gamers.Count || selectedId < 1);
			Console.Clear();

			// Getting index of a gamer with this player_id.
			int indexOfThisGamer = -1;
			for(int i = 0; i < gamers.Count; i++)
			{
				if (gamers[i].player_id == selectedId)
					indexOfThisGamer = i;
			}

			if (indexOfThisGamer == -1)
				ChangeGamers(ref gamers);

            // Choosing what field must be changed.
            string[] fieldToChange = new string[] { "username", "level", "achievements", "guild" };

            int selectedField = Menu.Slider("What field you would change?", fieldToChange);

			// Changing field.

			if (selectedField != 2)
			{
				Console.Write($"Type value for {fieldToChange[selectedField]} :: ");
				if(selectedField!=1)
					gamers[indexOfThisGamer][fieldToChange[selectedField]] = Console.ReadLine();
				else
				{
					int value;
					do
					{
						Console.Write($"Type value for {fieldToChange[selectedField]} :: ");
					} while (!int.TryParse(Console.ReadLine(), out value));
					gamers[indexOfThisGamer][fieldToChange[selectedField]] = value;
				}
			}
			else
			{

				// Taking types of a achievement.
				foreach(Gamer gamer in gamers)
				{
					foreach(Achievement ach in gamer.achievements)
					{
						if (!Achievement.AchievementById.ContainsKey(ach.achievement_id))
						{
							Achievement.AchievementById[ach.achievement_id] = ach;
						}
					}
				}

				//Choosing what achieverment will be add to gamer.
				string[] achievementIds = Achievement.AchievementById.Keys.ToArray();

				try
				{
					Array.Sort(achievementIds, ((a, b) => int.Parse(a[1..]).CompareTo(int.Parse(b[1..]))));
				}
				finally
				{
                    int selectedIdOfAchievement = Menu.Slider("What achievement you would to add?", achievementIds);

                    Achievement achievement = Achievement.AchievementById[Achievement.AchievementById.Keys.ToArray()[selectedIdOfAchievement]];

                    List<Achievement>? achievements = gamers[indexOfThisGamer].achievements;
                    achievements.Add(achievement);
                    gamers[indexOfThisGamer].achievements = achievements;
                }
			}

			return gamers;
		}
	}
}

