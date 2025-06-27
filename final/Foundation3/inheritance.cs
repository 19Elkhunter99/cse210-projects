// ---------- Base Event Class ----------
class Event
{
    private string title;
    private string description;
    private string date;
    private string time;

    public Event(string title, string description, string date, string time)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
    }

    // Shared behavior (can be overridden)
    public virtual string GetSummary()
    {
        return $"{title} - {description} on {date} at {time}";
    }
}

// ---------- Lecture: inherits Event ----------
class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, string speaker, int capacity)
        : base(title, description, date, time)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }
}

// ---------- Reception: inherits Event ----------
class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, string rsvpEmail)
        : base(title, description, date, time)
    {
        this.rsvpEmail = rsvpEmail;
    }
}

// ---------- OutdoorGathering: inherits Event ----------
class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, string weatherForecast)
        : base(title, description, date, time)
    {
        this.weatherForecast = weatherForecast;
    }
}
