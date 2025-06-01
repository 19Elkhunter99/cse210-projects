using System;
using System.Collections.Generic;
using System.Linq;

class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; } // Nullable for single verses

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse == null ? $"{Book} {Chapter}:{StartVerse}" : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public override string ToString()
    {
        return IsHidden ? "_____" : Text;
    }
}

class Scripture
{
    public Reference Ref { get; private set; }
    private List<Word> Words;

    public Scripture(string book, int chapter, int startVerse, string text, int? endVerse = null)
    {
        Ref = new Reference(book, chapter, startVerse, endVerse);
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideWords(int count)
    {
        var visibleWords = Words.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count == 0) return;

        var random = new Random();
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            var wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.IsHidden = true;
            visibleWords.Remove(wordToHide);
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(w => w.IsHidden);
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(Ref);
        Console.WriteLine(string.Join(" ", Words));
    }
}

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("Doctrine and Covenants", 82, 10, "I, the Lord, am bound when ye do what I say; but when ye do not what I say, ye have no promise.");

        while (!scripture.AllWordsHidden())
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            scripture.HideWords(2); // Hide 2 words at a time
        }

        Console.WriteLine("\nYou've memorized the scripture!");
    }
}

