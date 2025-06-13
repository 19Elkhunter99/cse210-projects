// ReflectionActivity.cs
using System;
using System.Collections.Generic;
using System.Threading;

class ReflectionActivity : MindfulnessActivity
{
    // Static fields (collections) are typically PascalCase in C#
    private static readonly List<string> Prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> Questions = new()
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

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") {}

    protected override void PerformActivity(int duration)
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine($"\nConsider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("When you have thought about it, press enter to continue.");
        Console.ReadLine(); // Wait for user to read prompt

        Console.WriteLine("Now ponder on the following questions as you begin to reflect on your experience.");
        Console.Write("You may begin in ");
        ShowCountdown(5); // Initial countdown before questions start

        DateTime startTime = DateTime.Now;
        // Determine approximate time for each question to ensure it fits within duration
        int questionDisplayTime = 5; // seconds to show question and spinner

        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            string question = Questions[random.Next(Questions.Count)];
            Console.WriteLine($"> {question}");
            ShowSpinner(questionDisplayTime); // Using spinner for reflection question pauses
            Console.WriteLine(); // New line after spinner finishes for the next question
            // Small additional pause to prevent rapid-fire questions if duration is long
            Thread.Sleep(500);
        }
        Console.WriteLine("Reflection exercise complete.");
    }
}