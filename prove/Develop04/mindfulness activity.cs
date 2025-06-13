// MindfulnessActivity.cs
using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    // Changed to _camelCase as per feedback
    protected string _name;
    protected string _description;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.Clear(); // Clear console for a fresh start for each activity
        Console.WriteLine($"\n--- {_name} ---");
        Console.WriteLine(_description);

        Console.Write("Enter duration in seconds: ");
        int duration;
        // Input validation for duration
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid duration. Please enter a positive number.");
            Console.Write("Enter duration in seconds: ");
        }

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3); // Using spinner for general preparation pause
        Console.WriteLine(); // Ensure new line after spinner

        PerformActivity(duration);
        EndActivity(duration);
    }

    // Method to show a numeric countdown with a visual animation (clearing numbers)
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}"); // Display the number
            Thread.Sleep(1000); // Wait 1 second
            // Clear the number by writing spaces and returning cursor
            Console.Write("\b" + new string(' ', i.ToString().Length) + "\b");
        }
        Console.WriteLine(); // New line after countdown finishes
    }

    // Method to show a spinner animation for general pauses
    protected void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        int i = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250); // Rotate every 250ms
            Console.Write("\b"); // Erase the spinner character
            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
        // No Console.WriteLine() here; caller should handle newline if needed
    }

    public void EndActivity(int duration)
    {
        Console.WriteLine("\nGood job! You have completed the activity.");
        Console.WriteLine($"You completed the {_name} for {duration} seconds.");
        Console.WriteLine("Returning to menu...");
        ShowSpinner(3); // Using spinner for general ending pause
        Console.WriteLine(); // New line after spinner finishes.
        Thread.Sleep(1000); // Brief pause before returning to main menu
    }

    protected abstract void PerformActivity(int duration);
}