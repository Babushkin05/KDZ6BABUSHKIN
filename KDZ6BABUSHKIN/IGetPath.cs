using System;
using GamersLib;
namespace KDZ6BABUSHKIN
{
	/// <summary>
	///  Interface with getting path for json file and reading it.
	/// </summary>
	public interface IGetPath
	{
		/// <summary>
		/// Getting path and reading new list.
		/// </summary>
		/// <returns></returns>
        protected static  List<Gamer>? GetPath()
		{
			List<Gamer>? gamers = FileHandler.GetListOfGamers();

			return gamers;
		}
	}
}

