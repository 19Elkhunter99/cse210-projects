using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

// Base class for all mindfulness activities
public abstract class MindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    // Static dictionary to store activity counts
    private static Dictionary<string, int> _activityCounts = new Dictionary<string, int>();

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
        // Initialize activity count if not present
        if (!_activityCounts.ContainsKey(name))
        {
            _activityCounts[name] = 0;
        }
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        PauseWithAnimation(3); // Pause for 3 seconds to prepare
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        PauseWithAnimation(3); // Pause for 3 seconds
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
        PauseWithAnimation(3); // Pause for 3 seconds before finishing
        _activityCounts[_name]++; // Increment the count for this activity
    }

    // Displays a spinner animation for a given number of seconds
    protected void PauseWithAnimation(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250); // Pause for 250 milliseconds
            Console.Write("\b \b"); // Erase the spinner character
            i = (i + 1) % spinner.Count;
        }
    }

    // Displays a countdown timer for a given number of seconds
    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000); // Pause for 1 second
            Console.Write("\b \b"); // Erase the number
        }
        Console.WriteLine();
    }

    // Abstract method to be implemented by derived classes
    public abstract void RunActivity();

    // Static method to get the count for a specific activity
    public static int GetActivityCount(string activityName)
    {
        return _activityCounts.ContainsKey(activityName) ? _activityCounts[activityName] : 0;
    }
}

// Derived class for the Breathing Activity
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            PauseWithCountdown(4); // Breathe in for 4 seconds
            Console.Write("Breathe out...");
            PauseWithCountdown(6); // Breathe out for 6 seconds
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}

// Derived class for the Reflection Activity
public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        // Select a random prompt
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine(); // Wait for user to press enter

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        PauseWithCountdown(5); // Give user 5 seconds to prepare

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        List<string> usedQuestions = new List<string>();

        while (DateTime.Now < endTime)
        {
            // Select a random question that hasn't been used yet in this session
            string question;
            List<string> availableQuestions = _questions.Except(usedQuestions).ToList();

            if (availableQuestions.Count == 0)
            {
                // All questions have been used, reset for this session
                usedQuestions.Clear();
                availableQuestions = _questions.ToList();
            }
            
            question = availableQuestions[_random.Next(availableQuestions.Count)];
            usedQuestions.Add(question);

            Console.WriteLine($"> {question}");
            PauseWithAnimation(5); // Pause for 5 seconds with animation for reflection
            Console.WriteLine(); // Add a new line after the animation
        }

        DisplayEndingMessage();
    }
}

// Derived class for the Listing Activity
public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        // Select a random prompt
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        PauseWithCountdown(5); // Give user 5 seconds to prepare

        Console.WriteLine();
        Console.WriteLine("Start listing items:");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        int itemCount = 0;

        // The listing activity needs to allow user input continuously within the duration.
        // This loop checks for key presses without blocking, allowing the time to run out.
        // Note: For a more robust input method, especially in a console, you might consider
        // asynchronous input or a separate thread, but this approach meets basic requirements.
        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable) // Check if a key has been pressed
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    itemCount++;
                }
            }
            // Small sleep to prevent busy-waiting and allow other processes to run
            Thread.Sleep(100);
        }
        Console.WriteLine();
        Console.WriteLine($"You listed {itemCount} items!");

        DisplayEndingMessage();
    }
}

// Main program class
public class Program
{
    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity (Completed: " + MindfulnessActivity.GetActivityCount("Breathing") + " times)");
            Console.WriteLine("  2. Start reflection activity (Completed: " + MindfulnessActivity.GetActivityCount("Reflection") + " times)");
            Console.WriteLine("  3. Start listing activity (Completed: " + MindfulnessActivity.GetActivityCount("Listing") + " times)");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000); // Pause for 2 seconds
                    break;
            }

            if (activity != null)
            {
                activity.RunActivity();
            }
        }
    }
}