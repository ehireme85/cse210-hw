// Goal.cs
// Abstract base class for all goal types.
// Holds shared attributes and declares virtual methods overridden by derived classes.

using System;

abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int    _points;

    public Goal(string name, string description, int points)
    {
        _shortName   = name;
        _description = description;
        _points      = points;
    }

    // Returns points earned this recording; derived classes override for bonus logic.
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    // One-line display for the goal list (checkbox + name + extra info).
    public abstract string GetDetailsString();

    // Serialised string used when saving to file.
    public abstract string GetStringRepresentation();

    // Shared accessors used by GoalManager.
    public string ShortName   => _shortName;
    public string Description => _description;
    public int    Points      => _points;
}
