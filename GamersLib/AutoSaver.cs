using System;
namespace GamersLib
{
	/// <summary>
	/// Class saves json if last update was less than 15 seconds.
	/// </summary>
	public static class AutoSaver
	{
		// Time of last update.
        private static DateTime? predTime = DateTime.Now;

		/// <summary>
		/// Saves json if last update wass less than 15 seconds before.
		/// </summary>
		/// <param name="sender">Object that start event.</param>
		/// <param name="e">Args of event.</param>
		public static void onChangingSaver(object? sender, EventArgs e)
		{
			if(DateTime.Now.AddSeconds(-15) <= predTime)
			{
				FileHandler.SaveFile(FileHandler.nameOfJson + "_tmp");
            }
			predTime = DateTime.Now;
		}
	}
}

