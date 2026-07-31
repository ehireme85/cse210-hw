using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureReference reference = new ScriptureReference("Proverbs", 3, 5, 6);
        string text =
            "Trust in the Lord with all your heart and lean not on your own understanding; " +
            "in all your ways submit to him and he will make your paths straight.";

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Great work memorizing!");
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit") { Console.WriteLine("Goodbye!"); break; }

            scripture.HideRandomWords(3);
        }
    }
}