using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private Random _random = new Random();

    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something I learned or discovered today?",
        "What am I most grateful for today?",
        "What challenged me today, and how did I handle it?"
    };

    public void AddEntry()
    {
        int index = _random.Next(_prompts.Count);
        string prompt = _prompts[index];

        Console.WriteLine($"\n> {prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("MM/dd/yyyy");
        Entry newEntry = new Entry(date, prompt, response);
        _entries.Add(newEntry);

        Console.WriteLine("Entry saved!");
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal yet.");
            return;
        }

        Console.WriteLine();
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
        Console.WriteLine($"Journal saved to {filename}.");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                _entries.Add(Entry.FromFileString(line));
            }
        }
        Console.WriteLine($"Loaded {_entries.Count} entries from {filename}.");
    }
}