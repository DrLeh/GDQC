namespace GDQC.Core
{
    public class Schedule
    {
        public List<ScheduleGame> Games { get; set; } = new();
    }

    public class ScheduleGame
    {
        public string Game { get; set; }
        public string Category { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan? SetupLength { get; set; }

        public TimeSpan Estimate { get; set; }

        public string Host { get; set; }
        public string Runner { get; set; }

        public bool IsCurrent { get; set; }

    }
    public class Game
    {
        public string Name { get; set; }
        public ICollection<GameCategory> Categories { get; set; } = new List<GameCategory>();
    }

    public class GameCategory
    {
        public Game Game { get; set; }
        public string Name { get; set; }

    }

    public class Person
    {
        public string Name { get; set; }
    }
}