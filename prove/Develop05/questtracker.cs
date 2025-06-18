class QuestTracker
{
    private List<Goal> goals = new List<Goal>();
    private int totalScore = 0;

    public void AddGoal(Goal goal) => goals.Add(goal);

    public void RecordGoalEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.GetName().Equals(goalName, StringComparison.OrdinalIgnoreCase))
            {
                totalScore += goal.RecordEvent();
                Console.WriteLine($"✔ Recorded event for: {goalName}");
                return;
            }
        }
        Console.WriteLine($"⚠ Goal '{goalName}' not found.");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        foreach (var goal in goals) goal.Display();
        Console.WriteLine($"Total Score: {totalScore} pts\n");
    }
}
