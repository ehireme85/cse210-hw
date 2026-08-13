// Running.cs — Tracks a running session by distance (miles).
using System;

class Running : Activity
{
    private double _distance; // miles

    public Running(DateTime date, int lengthMinutes, double distance)
        : base(date, lengthMinutes)
    {
        _distance = distance;
    }

    public override string GetActivityName() => "Running";

    // Distance is stored directly.
    public override double GetDistance() => _distance;

    // Speed (mph) = (distance / minutes) * 60
    public override double GetSpeed() => (_distance / LengthMinutes) * 60;

    // Pace (min per mile) = minutes / distance
    public override double GetPace() => LengthMinutes / _distance;
}
