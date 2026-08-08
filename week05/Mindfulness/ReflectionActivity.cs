// ReflectionActivity.cs
// Guides the user through deep reflection on a past experience of strength or resilience.
// Shows a random prompt, then cycles through random reflective questions with spinner pauses.

using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown\n" +
            "strength and resilience. This will help you recognize the power you have and\n" +
            "how you can use it in other aspects of your life.")
    { }

    public void Run()
    {
        StartMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine("Consider the following prompt:\n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"  --- {prompt} ---");
        Console.ResetColor();
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now think deeply about the following questions as they are displayed.\n");
        ShowSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < end)
        {
            string question = _questions[random.Next(_questions.Count)];
            Console.WriteLine($"\n  > {question}");
            ShowSpinner(8);
        }

        EndMessage();
    }
}
