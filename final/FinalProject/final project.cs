using System;
using System.Collections.Generic;

// ---------- Abstract Base Class ----------
abstract class TrackerItem
{
    private string _title;
    private string _notes;
    private DateTime _createdAt;

    public TrackerItem(string title, string notes)
    {
        _title = title;
        _notes = notes;
        _createdAt = DateTime.Now;
    }

    public string GetTitle() => _title;
    public string GetNotes() => _notes;
    public DateTime GetCreatedDate() => _createdAt;

    public abstract string GetSummary();
    public abstract bool IsComplete();
}

// ---------- One-Time Task ----------
class TaskItem : TrackerItem
{
    private DateTime _dueDate;
    private bool _completed;

    public TaskItem(string title, string notes, DateTime dueDate)
        : base(title, notes)
    {
        _dueDate = dueDate;
        _completed = false;
    }

    public void MarkComplete() => _completed = true;

    public override string GetSummary()
    {
        return $"[Task] {GetTitle()} - Due: {_dueDate.ToShortDateString()} - Completed: {_completed}";
    }

    public override bool IsComplete() => _completed;
}

// ---------- Recurring Habit ----------
class HabitItem : TrackerItem
{
    private string _frequency;
    private int _streakCount;
    private bool _checkedToday;

    public HabitItem(string title, string notes, string frequency)
        : base(title, notes)
    {
        _frequency = frequency;
        _streakCount = 0;
        _checkedToday = false;
    }

    public void MarkHabit(bool didIt)
    {
        if (didIt)
        {
            _streakCount++;
            _checkedToday = true;
        }
        else
        {
            _streakCount = 0;
            _checkedToday = false;
        }
    }

    public override string GetSummary()
    {
        return $"[Habit] {GetTitle()} - Frequency: {_frequency} - Streak: {_streakCount} - Logged Today: {_checkedToday}";
    }

    public override bool IsComplete() => _checkedToday;
}

// ---------- Aggregator ----------
class GoalTracker
{
    private List<TrackerItem> _items = new List<TrackerItem>();

    public void AddItem(TrackerItem item) => _items.Add(item);

    public void ShowAll()
    {
        foreach (var item in _items)
        {
            Console.WriteLine(item.GetSummary());
        }
    }

    public void ShowPending()
    {
        foreach (var item in _items)
        {
            if (!item.IsComplete())
                Console.WriteLine(item.GetSummary());
        }
    }
}

// ---------- Optional Reminder ----------
class Reminder
{
    private TrackerItem _linkedItem;
    private DateTime _remindAt;

    public Reminder(TrackerItem item, DateTime remindAt)
    {
        _linkedItem = item;
        _remindAt = remindAt;
    }

    public string GetReminderInfo()
    {
        return $"Reminder: '{_linkedItem.GetTitle()}' at {_remindAt}";
    }
}

// ---------- Streak Tracker ----------
class Streak
{
    private HabitItem _habit;
    private int _bestStreak;

    public Streak(HabitItem habit)
    {
        _habit = habit;
        _bestStreak = 0;
    }

    public void UpdateStreak(bool completedToday)
    {
        if (completedToday)
        {
            _habit.MarkHabit(true);
            if (_habit.IsComplete())
                _bestStreak++;
        }
        else
        {
            _habit.MarkHabit(false);
            _bestStreak = 0;
        }
    }

    public int GetBestStreak() => _bestStreak;
}

// ---------- User Profile ----------
class UserProfile
{
    private string _username;
    private string _timezone;

    public UserProfile(string username, string timezone)
    {
        _username = username;
        _timezone = timezone;
    }

    public string GetGreeting() => $"Welcome back, {_username}! Timezone: {_timezone}";
}

// ---------- Utilities ----------
static class DateHelper
{
    public static DateTime AddDays(DateTime input, int days)
    {
        return input.AddDays(days);
    }
}
