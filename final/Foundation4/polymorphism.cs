using System;
using System.Collections.Generic;

// ----------- Base Activity Class -----------
abstract class Activity
{
    private DateTime date;
    private int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public int GetMinutes() => minutes;
    public string GetDate() => date.ToString("dd MMM yyyy");

    public abstract double GetDistance(); // miles
    public abstract double GetSpeed();   // mph
    public abstract double GetPace();    // min per mile

    public virtual string GetSummary()
    {
        return $"{GetDate()} {GetType().Name} ({minutes} min): " +
               $"Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }
}

// ----------- Running Activity -----------
class Running : Activity
{
    private double distance; // miles

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;
    public override double GetSpeed() => (distance / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / distance;
}

// ----------- Cycling Activity -----------
class Cycling : Activity
{
    private double speed; // mph

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed() => speed;
    public override double GetDistance() => (speed / 60) * GetMinutes();
    public override double GetPace() => 60 / speed;
}

// ----------- Swimming Activity -----------
class Swimming : Activity
{
    private int laps; // 50 meters per lap

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62; // meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}

// ----------- Main Program -----------
class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 3), 40, 60)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
