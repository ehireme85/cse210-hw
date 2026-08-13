// Swimming.cs — Tracks a swimming session by number of laps (50 m each).
using System;

class Swimming : Activity
{
    private int _laps; // each lap = 50 meters

    public Swimming(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override string GetActivityName() => "Swimming";

    // Distance (miles) = laps * 50 / 1000 * 0.62
    public override double GetDistance() => _laps * 50.0 / 1000.0 * 0.62;

    // Speed (mph) = (distance / minutes) * 60
    public override double GetSpeed() => (GetDistance() / LengthMinutes) * 60;

    // Pace (min per mile) = minutes / distance
    public override double GetPace() => LengthMinutes / GetDistance();
}
