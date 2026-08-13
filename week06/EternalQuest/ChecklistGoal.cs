// ChecklistGoal.cs
// A goal that must be accomplished a set number of times.
// Awards _points each recording plus a _bonus on the final completion.
// Example: Attend the temple 10 times → 50 pts each, 500 bonus on the 10th.

class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target          = target;
        _bonus           = bonus;
    }

    // Constructor used when loading from file; restores progress.
    public ChecklistGoal(string name, string description, int points,
                         int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _target          = target;
        _bonus           = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
            return 0;   // Already finished — no further credit.

        _amountCompleted++;

        int earned = _points;
        if (_amountCompleted == _target)
            earned += _bonus;   // Bonus on final completion.

        return earned;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description}) -- " +
               $"Completed {_amountCompleted}/{_target} times";
    }

    // Format: ChecklistGoal|name|description|points|target|bonus|amountCompleted
    public override string GetStringRepresentation()
        => $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
}
