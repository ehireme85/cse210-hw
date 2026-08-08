// BreathingActivity.cs
// Guides the user through slow, timed breathing cycles.
// Stretch challenge: uses a growing/shrinking block bar to simulate breath expanding and contracting.

using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "The Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly.\n" +
            "Clear your mind and focus on your breathing.")
    { }

    public void Run()
    {
        StartMessage();

        DateTime end      = DateTime.Now.AddSeconds(Duration);
        bool     breatheIn = true;

        while (DateTime.Now < end)
        {
            if (breatheIn)
            {
                Console.WriteLine("\nBreathe in...");
                ShowBreathBar(4, expanding: true);
            }
            else
            {
                Console.WriteLine("\nBreathe out...");
                ShowBreathBar(6, expanding: false);
            }
            breatheIn = !breatheIn;
        }

        EndMessage();
    }

    // Stretch: a block bar that grows for inhale and shrinks for exhale.
    // Progress starts fast and eases as it nears the end (simulating lung expansion slowing).
    private void ShowBreathBar(int seconds, bool expanding)
    {
        const int maxWidth = 24;
        int       steps    = seconds * 10;   // update every 100 ms for smooth animation

        for (int i = 0; i <= steps; i++)
        {
            // Ease-in-out curve: progress³ gives fast start, slow finish
            double t        = (double)i / steps;
            double eased    = expanding ? t * t : (1 - t) * (1 - t);
            int    barWidth = (int)(eased * maxWidth);

            string bar         = new string('█', barWidth).PadRight(maxWidth);
            int    secondsLeft = seconds - (int)(t * seconds);

            Console.Write($"\r  [{bar}]  {secondsLeft}s  ");
            Thread.Sleep(100);
        }
        Console.Write("\r" + new string(' ', maxWidth + 14) + "\r");
    }
}
