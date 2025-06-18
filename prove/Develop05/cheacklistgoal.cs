class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
        : base(name, points)
    {
        this.targetCount = targetCount;
        this.currentCount = 0;
        this.bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        currentCount++;
        if (currentCount >= targetCount)
        {
            isCompleted = true;
            return points + bonusPoints; // Bonus awarded
        }
        return points;
    }

    public override void Display()
    {
        Console.WriteLine($"[{(isCompleted ? "X" : " ")}] {name} ({points} pts) - Completed {currentCount}/{targetCount}");
    }
}
