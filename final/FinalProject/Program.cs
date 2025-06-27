using System;
using System.Collections.Generic;

// ---------- Abstract Base Class ----------
abstract class TrackerItem
{
    private string title;
    private string notes;
    private DateTime createdAt;

    public TrackerItem(string title, string notes)
    {
        this.title = title;
        this.notes = notes;
        this.createdAt = DateTime.Now;
    }

    public string GetTitle() => title;
    public string GetNotes() => notes;
    public DateTime GetCreatedDate() => createdAt;

    public abstract string GetSummary();
    public abstract bool IsComplete();
}

// ---------- One-Time Task ----------
class TaskItem : TrackerItem
{
    private DateTime dueDate;
    private bool completed;

    public TaskItem(string title, string notes, DateTime dueDate)
        : base(title, notes)
    {
        this.dueDate = dueDate;
        this.completed = false;
    }

    public void MarkComplete() => completed = true;

    public override string GetSummary()
    {
        return $"[Task] {GetTitle()} - Due: {dueDate.ToShortDateString()} - Completed: {completed}";
    }

    public override bool IsComplete() => completed;
}

// ---------- Recurring Habit ----------
class HabitItem : TrackerItem
{
    private string frequency; // "Daily", "Weekly", etc.
    private int streakCount;
    private bool checkedToday;

    public HabitItem(string title, string notes, string frequency)
        : base(title, notes)
    {
        this.frequency = frequency;
        this.streakCount = 0;
        this.checkedToday = false;
    }

    public void MarkHabit(bool didIt)
    {
        if (didIt)
        {
            streakCount++;
            checkedToday = true;
        }
        else
        {
            streakCount = 0;
            checkedToday = false;
        }
    }

    public override string GetSummary()
    {
        return $"[Habit] {GetTitle()} - Frequency: {frequency} - Streak: {streakCount} - Logged Today: {checkedToday}";
    }

    public override bool IsComplete() => checkedToday;
}

// ---------- Aggregator ----------
class GoalTracker
{
    private List<TrackerItem> items = new List<TrackerItem>();

    public void AddItem(TrackerItem item) => items.Add(item);

    public void ShowAll()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item.GetSummary());
        }
    }

    public void ShowPending()
    {
        foreach (var item in items)
        {
            if (!item.IsComplete())
                Console.WriteLine(item.GetSummary());
        }
    }
}

// ---------- Optional Reminder ----------
class Reminder
{
    private TrackerItem linkedItem;
    private DateTime remindAt;

    public Reminder(TrackerItem item, DateTime remindAt)
    {
        this.linkedItem = item;
        this.remindAt = remindAt;
    }

    public string GetReminderInfo()
    {
        return $"Reminder: '{linkedItem.GetTitle()}' at {remindAt}";
    }
}

// ---------- Streak Tracking ----------
class Streak
{
    private HabitItem habit;
    private int bestStreak;

    public Streak(HabitItem habit)
    {
        this.habit = habit;
        this.bestStreak = 0;
    }

    public void UpdateStreak(bool completedToday)
    {
        if (completedToday)
        {
            habit.MarkHabit(true);
            if (habit.IsComplete())
                bestStreak++;
        }
        else
        {
            habit.MarkHabit(false);
            bestStreak = 0;
        }
    }

    public int GetBestStreak() => bestStreak;
}

// ---------- User Profile ----------
class UserProfile
{
    private string username;
    private string timezone;

    public UserProfile(string username, string timezone)
    {
        this.username = username;
        this.timezone = timezone;
    }

    public string GetGreeting() => $"Welcome back, {username}! Timezone: {timezone}";
}

// ---------- Utility Class ----------
static class DateHelper
{
    public static DateTime AddDays(DateTime input, int days)
    {
        return input.AddDays(days);
    }
}
