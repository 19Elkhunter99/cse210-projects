using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Abstraction
        Console.WriteLine("== Abstraction ==");
        var video = new Video("Learning C#", "Connor", 300);
        video.AddComment(new Comment("Alice", "Great explanation!"));
        video.AddComment(new Comment("Bob", "Loved this!"));
        video.Display();

        // Encapsulation
        Console.WriteLine("\n== Encapsulation ==");
        var customer = new Customer("Connor", "123 Developer Road");
        var order = new Order(customer);
        order.AddProduct(new Product("Laptop", 1000, 1));
        order.AddProduct(new Product("Cable", 20, 2));
        order.DisplayOrder();

        // Inheritance
        Console.WriteLine("\n== Inheritance ==");
        var lecture = new Lecture("AI Talk", "The Future of Tech", "07/01", "Tech Auditorium", "Dr. Smart", 100);
        var reception = new Reception("Networking Night", "Meet & Greet", "07/02", "Community Hall", "rsvp@event.com");
        var outdoor = new OutdoorGathering("Picnic", "Fun & Food!", "07/03", "Park Central", "Sunny");
        lecture.Display();
        Console.WriteLine();
        reception.Display();
        Console.WriteLine();
        outdoor.Display();

        // Polymorphism
        Console.WriteLine("\n== Polymorphism ==");
        List<Exercise> log = new List<Exercise>
        {
            new Running("06/17", 30, 3.5),
            new Cycling("06/18", 45, 15.2),
            new Swimming("06/19", 25, 30)
        };

        foreach (var ex in log)
        {
            Console.WriteLine(ex.GetSummary());
        }
    }
}
