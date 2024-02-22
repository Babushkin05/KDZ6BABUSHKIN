using System;
namespace GamersLib
{
	/// <summary>
	/// Extended event Args.
	/// </summary>
	public class TimeReachedEventArgs : EventArgs
	{
		// Time that event happend.
		public DateTime timeReached { get; private set; }

		// Is achievement changed of other field.
		public bool isAchievementChanged { get; private set; }

		// Constructor.
		public TimeReachedEventArgs(DateTime time_, bool isAchievementChanged_=false)
		{
			timeReached = time_;
			isAchievementChanged = isAchievementChanged_;
		}
		
	}
}

