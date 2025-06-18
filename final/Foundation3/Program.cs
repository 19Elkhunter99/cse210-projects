public class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string Address { get; set; }

    public Event(string title, string description, string date, string address)
    {
        Title = title;
        Description = description;
        Date = date;
        Address = address;
    }

    public virtual void Display()
    {
        Console.WriteLine($"{Title} on {Date} at {Address}\n{Description}");
    }
}

public class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

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
    public string RSVPemail { get; set; }

    public Reception(string title, string description, string date, string address, string rsvpEmail)
        : base(title, description, date, address)
    {
        RSVPemail = rsvpEmail;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"RSVP to: {RSVPemail}");
    }
}

public class OutdoorGathering : Event
{
    public string WeatherForecast { get; set; }

    public OutdoorGathering(string title, string description, string date, string address, string weather)
        : base(title, description, date, address)
    {
        WeatherForecast = weather;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Weather Forecast: {WeatherForecast}");
    }
}
