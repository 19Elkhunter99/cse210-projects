class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 3.0),
            new Cycling("05 Nov 2022", 40, 15.0),
            new Swimming("07 Nov 2022", 30, 20)
        };

        foreach (var act in activities)
        {
            Console.WriteLine(act.GetSummary());
        }
    }
}
