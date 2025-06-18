class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) {}

    public override int RecordEvent()
    {
        isCompleted = true;
        return points;
    }
}
