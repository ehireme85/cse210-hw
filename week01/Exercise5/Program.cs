using System;

class Program
{
    // Displays a welcome message to the user
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Asks for and returns the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Asks for and returns the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        return number;
    }

    // Accepts an integer and returns that number squared
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Accepts the user's name and the squared number and displays them
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName     = PromptUserName();
        int    userNumber   = PromptUserNumber();
        int    squaredValue = SquareNumber(userNumber);

        DisplayResult(userName, squaredValue);
    }
}