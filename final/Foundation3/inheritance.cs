public class Event
{
    public string Title, Description, Date, Address;

    public Event(string title, string description, string date, string address)
    {
        Title = title; Description = description; Date = date; Address = address;
    }

    public virtual void Display()
    {
        Console.WriteLine($"{Title} - {Date} at {Address}");
        Console.WriteLine(Description);
    }
}

public class Lecture : Event
{
    public string Speaker;
    public int Capacity;

    public Lecture(string title, string description, string date, string address, string speaker, int capacity)
        : base(title, description, date, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Speaker: {Speaker}, Capacity: {Capacity}");
    }
}

public class Reception : Event
{
    public string RSVP;

    public Reception(string title, string description, string date, string address, string rsvp)
        : base(title, description, date, address)
    {
        RSVP = rsvp;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"RSVP Email: {RSVP}");
    }
}

public class OutdoorGathering : Event
{
    public string Weather;

    public OutdoorGathering(string title, string description, string date, string address, string weather)
        : base(title, description, date, address)
    {
        Weather = weather;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Weather Forecast: {Weather}");
    }
}
