// ListingActivity.cs
using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : MindfulnessActivity
{
    // Static fields (collections) are typically PascalCase in C#
    private static readonly List<string> Prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") {}

    protected override void PerformActivity(int duration)
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine($"\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in ");
        ShowCountdown(5); // Initial countdown for thinking
        
        Console.WriteLine("Start listing items now (press Enter after each item):");

        List<string> items = new();
        DateTime startTime = DateTime.Now;
        Console.CursorVisible = true; // Make cursor visible for user input

        // Loop while the elapsed time is less than the total duration.
        // Console.ReadLine() will block, and the time will count while blocking.
        // This is a common simplification for console apps to handle timed input.
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            // Optional: Give a warning if time is almost up
            if ((DateTime.Now - startTime).TotalSeconds + 3 >= duration) // 3-second buffer
            {
                Console.WriteLine("Time is almost up! Finish your thought.");
            }
            Console.Write("> "); // Indicate readiness for input
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
            }
            // If the user takes longer than remaining duration to type,
            // this loop will exit after ReadLine() finishes and time is checked.
        }
        Console.CursorVisible = false; // Hide cursor again after listing

        Console.WriteLine($"\nYou listed {items.Count} items!");
        Console.WriteLine("Listing exercise complete.");
    }
}