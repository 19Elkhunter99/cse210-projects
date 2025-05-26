using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Example scripture
        Scripture scripture = new Scripture(new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");

        while (!scripture.AllWordsHidden)
        {
            Console.Clear();
            Console.WriteLine(scripture.Display());
            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords();
        }

        Console.WriteLine("\nAll words are hidden! Well done memorizing!");
    }
}

// Represents the scripture reference (e.g., John 3:16 or Proverbs 3:5-6)
class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse.HasValue ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" : $"{Book} {Chapter}:{StartVerse}";
    }
}

// Represents an individual word in the scripture
class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide() => IsHidden = true;

    public override string ToString() => IsHidden ? "_____" : Text;
}

// Manages the scripture text and word hiding logic
class Scripture
{
    public Reference Reference { get; }
    private List<Word> Words { get; }
    public bool AllWordsHidden => Words.All(word => word.IsHidden);

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string Display()
    {
        string scriptureText = string.Join(" ", Words);
        return $"{Reference}\n{scriptureText}";
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = Math.Max(1, Words.Count / 8); // Hide a fraction of words each time

        List<Word> visibleWords = Words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count == 0) return;

        for (int i = 0; i < wordsToHide; i++)
        {
            if (visibleWords.Count == 0) break;
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
}
