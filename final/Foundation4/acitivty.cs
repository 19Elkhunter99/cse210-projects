public class Activity
{
    protected string _date;
    protected int _duration; // minutes

    public Activity(string date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public virtual double GetDistance() => 0;
    public virtual double GetSpeed() => 0;
    public virtual double GetPace() => 0;

    public virtual string GetSummary()
    {
        return $"{_date} Activity ({_duration} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min/mile";
    }
}
