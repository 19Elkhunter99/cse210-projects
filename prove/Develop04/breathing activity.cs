// BreathingActivity.cs
using System;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.") {}

    protected override void PerformActivity(int duration)
    {
        Console.WriteLine("Get ready to breathe...");
        int elapsed = 0;
        int breathInTime = 4; // seconds
        int breathOutTime = 6; // seconds

        while (elapsed < duration)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(breathInTime); // Uses base class countdown
            elapsed += breathInTime;
            if (elapsed >= duration) break; // Check if duration is met

            Console.Write("Breathe out... ");
            ShowCountdown(breathOutTime); // Uses base class countdown
            elapsed += breathOutTime;
        }
        Console.WriteLine("Breathing exercise complete.");
    }
}