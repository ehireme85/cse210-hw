// Activity.cs — Abstract base class for all fitness activities.
using System;

abstract class Activity
{
    private DateTime _date;
    private int _lengthMinutes;

    public Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    protected int LengthMinutes => _lengthMinutes;

    public abstract double GetDistance();    // miles
    public abstract double GetSpeed();       // mph
    public abstract double GetPace();        // min per mile
    public abstract string GetActivityName();

    // GetSummary is defined once here and works for all derived types
    // because it calls the abstract methods polymorphically.
    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetActivityName()} ({_lengthMinutes} min) - " +
               $"Distance: {GetDistance():F1} miles, " +
               $"Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F2} min per mile";
    }
}
