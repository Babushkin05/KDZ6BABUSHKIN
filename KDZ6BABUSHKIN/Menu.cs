using System;
using GamersLib;
namespace KDZ6BABUSHKIN
{
	/// <summary>
	/// Menu for list of gamers.
	/// </summary>
	public partial class Menu : IGetPath, ISortable, IChangable, ISaveble, IShowTable
	{
		// List of subscribes
		private delegate List<Gamer>? del();
		private del[] events = new del[4];

		//List of gamers.
		private List<Gamer>? gamers;

		// Constructor.
		public Menu(ref List<Gamer>? gamers_) 
		{
			gamers = gamers_;
			events[0] = () => IGetPath.GetPath();
			events[1] = () => ISortable.SortList(ref gamers);
			events[2] = () => IChangable.ChangeGamers(ref gamers);
			events[3] = () => ISaveble.Saving(ref gamers);
		}

		/// <summary>
		/// Launching menu.
		/// </summary>
		public void StartMenu()
		{
			// Getting tool for list from a user.
			int selectedTool = Slider("What you want to do with list of gamers?", new string[] { "Get new list from a file",
				"Sort list by some field", "Change elements from a list", "Save current table", "Show current table", "Leave Menu" });

			// Leaves menu.
			if (selectedTool == 5)
				return;

			// Use tools
			if(selectedTool<4)
				gamers = events[selectedTool].Invoke();

			if (selectedTool == 3)
				return;

			//Show result of tool.
			IShowTable.ShowTable(gamers);

			// Reopen menu.
			StartMenu();

		}
	}
}

