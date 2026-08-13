// GoalManager.cs
// Manages the full list of goals and the player's score.
// Handles the menu loop, goal creation, event recording, and file save/load.

using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int        _score = 0;

    // ─── Level / title system (creativity) ───────────────────────────────────
    private static readonly (int threshold, string title)[] _levels =
    {
        (0,    "Wandering Novice"),
        (500,  "Determined Apprentice"),
        (1500, "Focused Journeyman"),
        (3000, "Resolute Knight"),
        (6000, "Steadfast Champion"),
        (10000,"Legendary Eternal Quester")
    };

    private string GetTitle()
    {
        string title = _levels[0].title;
        foreach (var level in _levels)
            if (_score >= level.threshold) title = level.title;
        return title;
    }

    // ─── Entry point ─────────────────────────────────────────────────────────
    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  Menu");
            Console.ResetColor();
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine().Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1": CreateGoal();   break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals();    break;
                case "4": LoadGoals();    break;
                case "5": RecordEvent();  break;
                case "6": running = false; break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine("Keep up the quest! Goodbye.");
    }

    // ─── Display ─────────────────────────────────────────────────────────────
    public void DisplayPlayerInfo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  Eternal Quest ");
        Console.ResetColor();
        Console.WriteLine($"  Title : {GetTitle()}");
        Console.WriteLine($"  Score : {_score} pts");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals yet."); return; }
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"  {i + 1}. {_goals[i].ShortName}");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Press Enter to return.");
            Console.ReadLine();
            return;
        }
        Console.WriteLine("Goals:");
        foreach (Goal g in _goals)
            Console.WriteLine($"  {g.GetDetailsString()}");
        Console.WriteLine("\nPress Enter to continue.");
        Console.ReadLine();
    }

    // ─── Create ──────────────────────────────────────────────────────────────
    public void CreateGoal()
    {
        Console.WriteLine("What kind of goal would you like to create?");
        Console.WriteLine("  1. Simple Goal    ");
        Console.WriteLine("  2. Eternal Goal   ");
        Console.WriteLine("  3. Checklist Goal ");
        Console.Write("\nChoice: ");
        string type = Console.ReadLine().Trim();

        Console.Write("Short name : ");
        string name = Console.ReadLine().Trim();

        Console.Write("Description: ");
        string desc = Console.ReadLine().Trim();

        Console.Write("Points per recording: ");
        int points = int.Parse(Console.ReadLine().Trim());

        Goal goal = null;

        if (type == "1")
        {
            goal = new SimpleGoal(name, desc, points);
        }
        else if (type == "2")
        {
            goal = new EternalGoal(name, desc, points);
        }
        else if (type == "3")
        {
            Console.Write("Required number of completions: ");
            int target = int.Parse(Console.ReadLine().Trim());
            Console.Write("Bonus points on final completion: ");
            int bonus = int.Parse(Console.ReadLine().Trim());
            goal = new ChecklistGoal(name, desc, points, target, bonus);
        }
        else
        {
            Console.WriteLine("Invalid type. Press Enter to return.");
            Console.ReadLine();
            return;
        }

        _goals.Add(goal);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nGoal \"{name}\" created! Press Enter to continue.");
        Console.ResetColor();
        Console.ReadLine();
    }

    // ─── Record ──────────────────────────────────────────────────────────────
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Press Enter to return.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames();
        Console.Write("\nEnter goal number: ");

        if (!int.TryParse(Console.ReadLine().Trim(), out int index) ||
            index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid selection. Press Enter to return.");
            Console.ReadLine();
            return;
        }

        Goal chosen = _goals[index - 1];

        if (chosen.IsComplete())
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\"{chosen.ShortName}\" is already complete!");
            Console.ResetColor();
        }
        else
        {
            int earned = chosen.RecordEvent();
            _score += earned;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWell done! You earned {earned} points.");
            Console.ResetColor();
            Console.WriteLine($"Total score: {_score} — {GetTitle()}");

            if (chosen.IsComplete())
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"🎉 GOAL COMPLETE: \"{chosen.ShortName}\" finished!");
                Console.ResetColor();
            }
        }

        Console.WriteLine("\nPress Enter to continue.");
        Console.ReadLine();
    }

    // ─── Save ─────────────────────────────────────────────────────────────────
    public void SaveGoals()
    {
        Console.Write("Filename to save (e.g. goals.txt): ");
        string filename = Console.ReadLine().Trim();

        using StreamWriter writer = new StreamWriter(filename);
        writer.WriteLine(_score);
        foreach (Goal g in _goals)
            writer.WriteLine(g.GetStringRepresentation());

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Goals saved to \"{filename}\". Press Enter to continue.");
        Console.ResetColor();
        Console.ReadLine();
    }

    // ─── Load ─────────────────────────────────────────────────────────────────
    public void LoadGoals()
    {
        Console.Write("Filename to load (e.g. goals.txt): ");
        string filename = Console.ReadLine().Trim();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Press Enter to return.");
            Console.ReadLine();
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string   line  = lines[i];
            string[] parts = line.Split('|');
            string   type  = parts[0];

            if (type == "SimpleGoal")
            {
                // SimpleGoal|name|description|points|isComplete
                _goals.Add(new SimpleGoal(
                    parts[1], parts[2],
                    int.Parse(parts[3]),
                    bool.Parse(parts[4])));
            }
            else if (type == "EternalGoal")
            {
                // EternalGoal|name|description|points
                _goals.Add(new EternalGoal(
                    parts[1], parts[2],
                    int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                // ChecklistGoal|name|description|points|target|bonus|amountCompleted
                _goals.Add(new ChecklistGoal(
                    parts[1], parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6])));
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Loaded {_goals.Count} goal(s). Score restored to {_score}.");
        Console.ResetColor();
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}
