namespace Activity.Domain;

public class Activity : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string Location { get; set; } = default!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Distance { get; set; }
    public TimeSpan Duration
    {
        get
        {
            return EndTime - StartTime;
        }
        set { }
    }
    public double AveragePace
    {
        get
        {
            return Distance > 0 ? Duration.TotalMinutes / Distance : 0;
        }
        set { }
    }
}