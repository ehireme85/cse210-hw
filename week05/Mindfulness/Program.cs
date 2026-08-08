// Program.cs
// Entry point for the Mindfulness Program.
// Displays a menu and launches the chosen activity in a loop until the user quits.

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==============================");
            Console.WriteLine("        Menu Options");
            Console.WriteLine("==============================");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine().Trim();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Take care and be mindful. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("\nInvalid option. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }
}
