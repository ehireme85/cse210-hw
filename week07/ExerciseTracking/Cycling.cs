// Cycling.cs — Tracks a stationary cycling session by speed (mph).
using System;

class Cycling : Activity
{
    private double _speed; // mph

    public Cycling(DateTime date, int lengthMinutes, double speed)
        : base(date, lengthMinutes)
    {
        _speed = speed;
    }

    public override string GetActivityName() => "Cycling";

    public override double GetSpeed() => _speed;

    // Distance (miles) = speed * minutes / 60
    public override double GetDistance() => _speed * LengthMinutes / 60;

    // Pace (min per mile) = 60 / speed
    public override double GetPace() => 60 / _speed;
}
