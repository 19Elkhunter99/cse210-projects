using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    protected string name;
    protected string description;

    public MindfulnessActivity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"\nStarting {name}...");
        Console.WriteLine(description);
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        ShowCountdown(3);

        PerformActivity(duration);
        EndActivity(duration);
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}... ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void EndActivity(int duration)
    {
        Console.WriteLine("\nGood job! You have completed the activity.");
        Console.WriteLine($"You did {name} for {duration} seconds.");
        ShowCountdown(3);
    }

    protected abstract void PerformActivity(int duration);
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity helps you relax by guiding you through deep breathing exercises.") {}

    protected override void PerformActivity(int duration)
    {
        for (int i = 0; i < duration / 2; i++)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountdown(3);
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new()
    {
        "Think of a time when you stood up for someone.",
        "Think of a time when you did something difficult.",
        "Think of a time when you helped someone in need."
    };

    private static readonly List<string> Questions = new()
    {
        "Why was this experience meaningful?",
        "How did you get started?",
        "What did you learn from this experience?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity helps you reflect on moments of strength and resilience.") {}

    protected override void PerformActivity(int duration)
    {
        string prompt = Prompts[new Random().Next(Prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        ShowCountdown(5);

        for (int i = 0; i < duration / 5; i++)
        {
            string question = Questions[new Random().Next(Questions.Count)];
            Console.WriteLine(question);
            ShowCountdown(5);
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new()
    {
        "Who are people you appreciate?",
        "What are your personal strengths?",
        "Who are your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity helps you reflect on positivity by listing things in an area of strength.") {}

    protected override void PerformActivity(int duration)
    {
        string prompt = Prompts[new Random().Next(Prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        ShowCountdown(5);

        List<string> items = new();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.Write("Enter an item: ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {items.Count} items!");
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, MindfulnessActivity> activities = new()
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectionActivity() },
            { "3", new ListingActivity() }
        };

        while (true)
        {
            Console.WriteLine("\nMindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");
            
            string choice = Console.ReadLine();

            if (activities.ContainsKey(choice))
                activities[choice].StartActivity();
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
                Console.WriteLine("Invalid choice, please try again.");
        }
    }
}
