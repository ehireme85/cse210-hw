// Program.cs
// Entry point for the Eternal Quest program.
// Creates a GoalManager and starts the menu loop.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
