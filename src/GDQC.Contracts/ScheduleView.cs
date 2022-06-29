namespace GDQC.Contracts;


public class ScheduleView
{
    public List<ScheduleGameView> Games { get; set; } = new();
}

public class ScheduleGameView
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