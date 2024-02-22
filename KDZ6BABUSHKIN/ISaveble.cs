using System;
using GamersLib;
namespace KDZ6BABUSHKIN
{
	/// <summary>
	/// Interface that saves list of a gamers.
	/// </summary>
	public interface ISaveble
	{
		/// <summary>
		/// Method to save list of gamers.
		/// </summary>
		/// <param name="gamers">Gamers to save</param>
		/// <returns>Saved list.</returns>
		protected static List<Gamer> Saving(ref List<Gamer>? gamers)
		{
			FileHandler.SaveFile();

			return gamers;
		}
	}
}

