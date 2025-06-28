using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>
        {
            CreateVideo("Ocean Life", "BlueWorld", 210, new[] {
                ("Alice", "Stunning footage!"),
                ("Bob", "Loved the narration."),
                ("Charlie", "So peaceful.") }),

            CreateVideo("Space Journey", "AstroScope", 300, new[] {
                ("Diana", "Felt like I was in orbit."),
                ("Eli", "Incredible visuals!"),
                ("Fay", "Great background music.") }),

            CreateVideo("Mountain Hiking", "TrailTrekker", 180, new[] {
                ("George", "Wish I were there!"),
                ("Hannah", "Love the natural sounds."),
                ("Irene", "This was inspiring.") })
        };

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (var comment in video.GetComments())
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");

            Console.WriteLine(new string('-', 40));
        }
    }

    static Video CreateVideo(string title, string author, int length, (string, string)[] comments)
    {
        Video video = new Video(title, author, length);
        foreach (var (name, text) in comments)
            video.AddComment(new Comment(name, text));
        return video;
    }
}

