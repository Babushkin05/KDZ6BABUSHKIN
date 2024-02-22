using System;
using GamersLib;
namespace KDZ6BABUSHKIN
{
	/// <summary>
	///  Interface for sorting list.
	/// </summary>
	public interface ISortable
	{
		/// <summary>
		/// Sort list for a some field.
		/// </summary>
		/// <param name="gamers">List to sort.</param>
		/// <returns> sorted list.</returns>
		protected static List<Gamer> SortList(ref List<Gamer>? gamers)
		{
			// Choosing params user wants to sort.
			string[] fieldsToSort = new string[] { "player_id", "username", "level", "game_score", "guild" };

			int selectedField = Menu.Slider("What field to sort?", fieldsToSort);

			int reversed = Menu.Slider("Is reverse sorting?", new string[] { "No", "Yes" });

			// Sorting.
			gamers.Sort((a, b) =>
			{
				int res;

				if (selectedField == 3)
					res = ((double)a[fieldsToSort[selectedField]]).CompareTo((double?)b[fieldsToSort[selectedField]]);
				else if(selectedField==0 || selectedField==2)
                    res = ((int)a[fieldsToSort[selectedField]]).CompareTo((int?)b[fieldsToSort[selectedField]]);
                else
					res = ((string)a[fieldsToSort[selectedField]]).CompareTo((string?)b[fieldsToSort[selectedField]]);

				return (int)Math.Pow(-1, reversed) * res;
			});

			return gamers;

        }
	}
}

