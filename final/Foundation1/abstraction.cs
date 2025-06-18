public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }

    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthSeconds = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void Display()
    {
        Console.WriteLine($"{Title} by {Author} - {LengthSeconds} sec");
        Console.WriteLine("Comments:");
        foreach (var c in _comments)
        {
            Console.WriteLine($"  {c.Name}: {c.Text}");
        }
    }
}
