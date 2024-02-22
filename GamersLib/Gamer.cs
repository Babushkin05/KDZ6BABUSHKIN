namespace GamersLib;
using System.Text.Json;

/// <summary>
/// Class for data.
/// </summary>
public class Gamer
{
    // Event for updating fields of object.
    public static event EventHandler<EventArgs> Updated;

    // Static constructor.
    static Gamer()
    {
        Updated += onChangingAchievements;
        Updated += AutoSaver.onChangingSaver;
    }

    // Id of player.
    private int player_id_;
    public int player_id
    {
        get => player_id_;
        set
        {
            if (player_id != default(int))
                throw new Exception("Unable to change player_id");

            player_id_ = value;
        }
    }

    // Username of player.
    private string? username_;
    public string? username
    {
        get => username_;
        set
        {
            bool isEmpty = username_ == default(string);
            username_ = value;

            // Starting update event.
            if (!isEmpty)
            {
                TimeReachedEventArgs timeReachedEventArgs = new TimeReachedEventArgs(DateTime.Now);
                Updated.Invoke(this, timeReachedEventArgs);
            }
        }
    }

    // Level of player.
    private int level_;
    public int level
    {
        get => level_;
        set
        {
            bool isEmpty = level_ == default(int);
            level_ = value;

            // Starting update event.
            if (!isEmpty)
            {
                TimeReachedEventArgs timeReachedEventArgs = new TimeReachedEventArgs(DateTime.Now);
                Updated.Invoke(this, timeReachedEventArgs);
            }
        }
    }

    // Player game score.
    public double game_score { get; set; }

    private List<Achievement>? achievements_;
    public List<Achievement>? achievements
    {
        get => achievements_;
        set
        {
            bool isEmpty = achievements_ == default(List<Achievement>);
            achievements_ = value;

            // Starting update event.
            if (!isEmpty)
            {
                TimeReachedEventArgs timeReachedEventArgs = new TimeReachedEventArgs(DateTime.Now,true);
                Updated.Invoke(this, timeReachedEventArgs);
            }
        }
    }

    // Player's guild.
    private string? guild_;
    public string? guild
    {
        get => guild_;
        set
        {
            bool isEmpty = guild_ == default(string);
            guild_ = value;

            // Starting upgrade event.
            if (!isEmpty)
            {
                TimeReachedEventArgs timeReachedEventArgs = new TimeReachedEventArgs(DateTime.Now);
                Updated.Invoke(this, timeReachedEventArgs);
            }
        }
    }

    /// <summary>
    /// Changing game score for all players.
    /// </summary>
    /// <param name="sender">Object that start this event.</param>
    /// <param name="ev">Event Args.</param>
    private static void onChangingAchievements(object? sender, EventArgs ev)
    {
        // Is achievement was changed.
        if (!((TimeReachedEventArgs)ev).isAchievementChanged)
            return;

        // Recounting gamers that earn some achieves.
        Achievement.GamersReachedAchievement = new Dictionary<string, int>();

        foreach(Gamer gamer in FileHandler.gamers)
        {
            foreach(Achievement ach in gamer.achievements)
            {
                if (Achievement.GamersReachedAchievement.ContainsKey(ach.achievement_id))
                    Achievement.GamersReachedAchievement[ach.achievement_id]++;
                else
                    Achievement.GamersReachedAchievement[ach.achievement_id] = 1;
            }
        }

        // Changing game score.
        for(int i=0;i<FileHandler.gamers.Count;i++)
        {
            double newScore = 0;
            foreach (Achievement ach in FileHandler.gamers[i].achievements)
            {
                try
                {
                    newScore += ach.points / (double)Achievement.GamersReachedAchievement[ach.achievement_id];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            FileHandler.gamers[i].game_score = Math.Round(newScore, 2);
        }

    }

    // Indexer.
    public object? this[string name]
    {
        get
        {
            return name switch
            {
                "player_id" => player_id,
                "username" => username,
                "level" => level,
                "game_score" => game_score,
                "achievements" => achievements,
                "guild" => guild,
                 _ => throw new ArgumentException($"there is no filed {name}")
            };
        }

        set
        {
            switch (name)
            {
                case "username":
                    username = (string?)value;
                    break;
                case "level":
                    level = (int)value;
                    break;
                case "achievements":
                    achievements = (List<Achievement>?)value;
                    break;
                case "guild":
                    guild = (string?)value;
                    break;
            }
        }
    }

    // Serialize object to json string.
    public string ToJSON()
        => JsonSerializer.Serialize(this);
}

