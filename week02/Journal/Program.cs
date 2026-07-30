using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": journal.AddEntry();    break;
                case "2": journal.DisplayAll();  break;
                case "3": journal.SaveToFile();  break;
                case "4": journal.LoadFromFile(); break;
                case "5": running = false; Console.WriteLine("Goodbye!"); break;
                default:  Console.WriteLine("Invalid choice. Please enter 1-5."); break;
            }
        }
    }
}