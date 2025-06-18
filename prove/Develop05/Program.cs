class Program
{
    static void Main()
    {
        QuestTracker tracker = new QuestTracker();
        
        // Sample goals
        tracker.AddGoal(new SimpleGoal("Run a Marathon", 1000));
        tracker.AddGoal(new EternalGoal("Read Scriptures", 100));
        tracker.AddGoal(new ChecklistGoal("Attend Temple", 50, 10, 500));

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. View Goals\n2. Record Progress\n3. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    tracker.DisplayGoals();
                    break;
                case "2":
                    Console.Write("Enter goal name to record progress: ");
                    string goalName = Console.ReadLine();
                    tracker.RecordGoalEvent(goalName);
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("⚠ Invalid option. Try again.");
                    break;
            }
        }
    }
}
