// SimpleGoal.cs
// A goal that can be completed once and awards full points on that single recording.
// Example: Run a marathon → 1000 pts.

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor used when loading from file; restores completion state.
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
            return 0;          // Already done — no further points.

        _isComplete = true;
        return _points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    // Format: SimpleGoal|name|description|points|isComplete
    public override string GetStringRepresentation()
        => $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
}
