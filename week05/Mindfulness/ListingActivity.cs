// ListingActivity.cs
// Guides the user to list as many positive things as they can within the session duration.
// Counts and reports the total items entered at the end.

using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you\n" +
            "list as many things as you can in a certain area.")
    { }

    public void Run()
    {
        StartMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  --- {prompt} ---");
        Console.ResetColor();
        Console.WriteLine("\nYou may begin in:");
        ShowCountdown(5);
        Console.WriteLine();

        List<string> items = new List<string>();
        DateTime     end   = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
                items.Add(item.Trim());
        }

        Console.WriteLine($"\nYou listed {items.Count} item(s). Excellent work!");
        EndMessage();
    }
}
