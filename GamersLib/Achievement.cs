using System;
namespace GamersLib
{
	/// <summary>
	/// Achievement class.
	/// </summary>
	public class Achievement
	{
		// Id of achievement.
		private string? achievement_id_;
		public string? achievement_id {
			get => achievement_id_;
			set => achievement_id_ = value;
		}

		// Name of achievement.
		private string? achievement_name_;
		public string? achievement_name
		{
			get => achievement_name_;
			set => achievement_name_ = value;
		}

		// Achievement description.
		private string? description_;
		public string? description
		{
			get => description_;
			set => description_ = value;
		}

		// Point for achievement.
		private int points_;
		public int points
		{
			get => points_;
			set => points_ = value;
		}

		// Dictionary return full achievement by Id.
        public static Dictionary<string, Achievement> AchievementById = new Dictionary<string, Achievement>();

		// Counts how many times achievement was reached.
        internal static Dictionary<string, int> GamersReachedAchievement = new Dictionary<string, int>();
    }
}

