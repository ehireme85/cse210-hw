using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<double> numbers = new List<double>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Keep asking until the user enters 0
        while (true)
        {
            Console.Write("Enter number: ");
            double input = Convert.ToDouble(Console.ReadLine());

            if (input == 0)
            {
                break;          
            }

            numbers.Add(input);
        }

       
        // Step 1 — Sum
       
        double sum = 0;
        foreach (double n in numbers)
        {
            sum += n;
        }
        Console.WriteLine($"The sum is: {sum}");

       
        // Step 2 — Average
       
        double average = sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        
        // Step 3 — Maximum (largest number)
        
        double largest = numbers[0];
        foreach (double n in numbers)
        {
            if (n > largest)
            {
                largest = n;
            }
        }
        Console.WriteLine($"The largest number is: {largest}");
    }
}