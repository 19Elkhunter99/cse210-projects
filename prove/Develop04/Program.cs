// Program.cs
using System;
using System.Collections.Generic;
using System.Threading;

// Exceeding Requirements:
// - Enhanced Animations: Implemented a distinct spinner animation for general pauses (e.g., "Prepare to begin...",
//   "Returning to menu...", and reflection questions) to provide clearer visual feedback.
//   The countdown animation (for "Breathe in...", "Breathe out...", and initial listing/reflection prompts)
//   has also been refined to clear numbers cleanly, making it a more dynamic visual countdown.
// - Input Validation: Added basic validation for the duration input, ensuring the user enters a positive number.
// - User Experience Enhancements: Implemented Console.Clear() before each activity and menu display for a cleaner
//   interface, and toggled Console.CursorVisible to hide the cursor during animations/pauses and show it for listing input.

class Program
{
    static void Main(string[] args)
    {
        // Hide the cursor for a cleaner console experience throughout the program
        Console.CursorVisible = false;

        Dictionary<string, MindfulnessActivity> activities = new()
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectionActivity() },
            { "3", new ListingActivity() }
        };

        while (true)
        {
            Console.Clear(); // Clear console for menu display
            Console.WriteLine("--- Mindfulness Program Menu ---");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an activity: ");

            string choice = Console.ReadLine();

            if (activities.ContainsKey(choice))
            {
                activities[choice].StartActivity();
            }
            else if (choice == "4")
            {
                Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                ShowSpinner(2); // Short spinner before exiting
                Console.WriteLine(); // Ensure newline after spinner
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                Thread.Sleep(1500); // Pause so user can read the error message
            }
        }
        Console.CursorVisible = true; // Restore cursor before program exits
    }

    // Helper method for the main Program class to show a spinner,
    // useful for the final goodbye message.
    private static void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        int i = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
    }
}