using System;

class Program
{
    static void Main(string[] args)
    {
        
        // Ask user for their grade percentage
        
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percentage = int.Parse(answer);


        string letter;

        
        // Determine letter grade with if / else if / else
       
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is: {letter}");

      
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course. Well done!");
        }
        else
        {
            Console.WriteLine("You did not pass this time, but don't give up — keep going!");
        }
    }
}