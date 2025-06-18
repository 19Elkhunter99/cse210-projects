using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    protected string name;
    protected int points;
    protected bool isCompleted;

    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
        this.isCompleted = false;
    }

    public abstract int RecordEvent(); // Polymorphism
    public virtual void Display() => Console.WriteLine($"[{(isCompleted ? "X" : " ")}] {name} ({points} pts)");

    public string GetName() => name;
    public bool IsCompleted() => isCompleted;
}
