// EternalGoal.cs
// A goal that is never "finished" — it rewards points every time it is recorded.
// Example: Read scriptures daily → 100 pts each time.

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => _points;

    // Eternal goals are never complete.
    public override bool IsComplete() => false;

    public override string GetDetailsString()
        => $"[-] {_shortName} ({_description})";  // dash = ongoing

    // Format: EternalGoal|name|description|points
    public override string GetStringRepresentation()
        => $"EternalGoal|{_shortName}|{_description}|{_points}";
}
