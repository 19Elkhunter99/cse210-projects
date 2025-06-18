public abstract class Exercise
{
    public string Date;
    public int Duration; // in minutes

    public Exercise(string date, int duration)
    {
        Date = date;
        Duration = duration;
    }

    public abstract string GetSummary();
}

public class Running : Exercise
{
    public double Distance;

    public Running(string date, int duration, double distance)
        : base(date, duration)
    {
        Distance = distance;
    }

    public override string GetSummary() => $"{Date} Running ({Duration} min) - {Distance} miles";
}

public class Cycling : Exercise
{
    public double Speed;

    public Cycling(string date, int duration, double speed)
        : base(date, duration)
    {
        Speed = speed;
    }

    public override string GetSummary() => $"{Date} Cycling ({Duration} min) - {Speed} mph";
}

public class Swimming : Exercise
{
    public int Laps;

    public Swimming(string date, int duration, int laps)
        : base(date, duration)
    {
        Laps = laps;
    }

    public override string GetSummary() => $"{Date} Swimming ({Duration} min) - {Laps} laps";
}
