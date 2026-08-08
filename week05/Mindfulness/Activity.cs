// Activity.cs
// Base class for all mindfulness activities.
// Holds shared state (name, description, duration) and shared behaviors
// (start message, end message, spinner, countdown).

using System;
using System.Threading;

class Activity
{
    private string _name;
    private string _description;
    private int    _duration;   // in seconds

    public Activity(string name, string description)
    {
        _name        = name;
        _description = description;
    }

    // Accessible to derived classes so they can use duration in their loops.
    protected int Duration
    {
        get { return _duration; }
    }

    // ── Shared Starting Message ───────────────────────────────────────────────
    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
        Console.Clear();
    }

    // ── Shared Ending Message ─────────────────────────────────────────────────
    public void EndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name}.");
        Console.WriteLine($"Total time: {_duration} seconds.");
        ShowSpinner(3);
    }

    // ── Animation Helpers (available to all derived classes) ──────────────────

    // Displays a rotating spinner for the given number of seconds.
    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime end    = DateTime.Now.AddSeconds(seconds);
        int      i      = 0;
        while (DateTime.Now < end)
        {
            Console.Write($"\r  {frames[i % frames.Length]} ");
            Thread.Sleep(250);
            i++;
        }
        Console.Write("\r     \r");
    }

    // Displays a numeric countdown from 'seconds' down to 1.
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r  {i}  ");
            Thread.Sleep(1000);
        }
        Console.Write("\r     \r");
    }
}
