using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"- {comment.Name}: {comment.Text}");
        }
        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Unboxing SmartWatch", "TechTrendy", 310);
        video1.AddComment(new Comment("Alice", "Awesome video, I’m buying one!"));
        video1.AddComment(new Comment("Bob", "Love the design details."));
        video1.AddComment(new Comment("Clara", "How’s the battery life?"));
        videos.Add(video1);

        Video video2 = new Video("Top 5 Running Shoes", "FitnessPro", 420);
        video2.AddComment(new Comment("Dan", "Just got the second pair—amazing support."));
        video2.AddComment(new Comment("Ella", "Thanks for the breakdown!"));
        video2.AddComment(new Comment("Felix", "Any women's options coming soon?"));
        videos.Add(video2);

        Video video3 = new Video("Kitchen Gadget Review", "HomeChef101", 265);
        video3.AddComment(new Comment("Gina", "Didn’t know this tool existed!"));
        video3.AddComment(new Comment("Henry", "Very useful demo."));
        video3.AddComment(new Comment("Ivy", "Can you do a follow-up?"));
        videos.Add(video3);

        // Display videos and their comments
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
