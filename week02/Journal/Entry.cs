using System;

class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    
    public Entry(string date, string prompt, string response)
    {
        _date     = date;
        _prompt   = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date:     {_date}");
        Console.WriteLine($"Prompt:   {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine(new string('-', 50));
    }

    public string ToFileString()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');
        string date     = parts[0];
        string prompt   = parts[1];
        string response = parts[2];
        return new Entry(date, prompt, response);
    }
}