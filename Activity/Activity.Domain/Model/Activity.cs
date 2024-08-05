namespace Activity.Domain;

public class Activity : Entity<Guid>
{
    public string Location { get; private set; } = default!;
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public double Distance { get; private set; }
    public TimeSpan Duration
    {
        get
        {
            return EndTime - StartTime;
        }
    }
    public double AveragePace
    {
        get
        {
            return Distance > 0 ? Duration.TotalMinutes / Distance : 0;
        }
    }
}