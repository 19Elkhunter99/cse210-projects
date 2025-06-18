public abstract class Exercise
{
    public string Date { get; set; }
    public int DurationMinutes { get; set; }

    public Exercise(string date, int duration)
    {
        Date = date;
        DurationMinutes = duration;
    }

    public abstract string GetSummary();
}

public class Running : Exercise
{
    public float DistanceMiles { get; set; }

    public Running(string date, int duration, float distance)
        : base(date, duration)
    {
        DistanceMiles = distance;
    }

    public override string GetSummary()
    {
        return $"{Date} Running ({DurationMinutes} min): Distance {DistanceMiles} miles";
    }
}

public class Cycling : Exercise
{
    public float SpeedMph { get; set; }

    public Cycling(string date, int duration, float speed)
        : base(date, duration)
    {
        SpeedMph = speed;
    }

    public override string GetSummary()
    {
        return $"{Date} Cycling ({DurationMinutes} min): Speed {SpeedMph} mph";
    }
}

public class Swimming : Exercise
{
    public int Laps { get; set; }

    public Swimming(string date, int duration, int laps)
        : base(date, duration)
    {
        Laps = laps;
    }

    public override string GetSummary()
    {
        return $"{Date} Swimming ({DurationMinutes} min): {Laps} laps";
    }
}
