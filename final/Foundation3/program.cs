class Program
{
    static void Main()
    {
        Address addr = new Address("222 Pine Rd", "Salt Lake City", "UT", "USA");

        Event lecture = new Lecture("Tech Talk", "Learn about AI ethics.", "10 Sept 2025", "2:00 PM", addr, "Dr. Gray", 100);
        Event reception = new Reception("Networking Night", "Meet industry pros.", "12 Sept 2025", "6:00 PM", addr, "rsvp@company.com");
        Event outdoor = new OutdoorGathering("BBQ Bash", "Food, games, and fun!", "15 Sept 2025", "1:00 PM", addr, "Sunny, 75°F");

        List<Event> events = new List<Event> { lecture, reception, outdoor };

        foreach (var e in events)
        {
            Console.WriteLine("=== FULL DETAILS ===");
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine("\n--- SHORT ---");
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine();
        }
    }
}
