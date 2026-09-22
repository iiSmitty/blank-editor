using CSharpCoach.Exercises;

namespace CSharpCoach;

public static class Program
{
    // Register each new exercise here once. That's the only wiring step.
    private static readonly List<IExercise> Exercises = new()
    {
        new Exercise01_WarmestStreak(),
        new Exercise02_FirstUniqueChar(),
    };

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== C# Coach ===");
            for (int i = 0; i < Exercises.Count; i++)
                Console.WriteLine($"  {i + 1}. {Exercises[i].Name}");
            Console.WriteLine("  q. Quit");
            Console.Write("Pick an exercise: ");

            string? input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input) || input.Equals("q", StringComparison.OrdinalIgnoreCase))
                return;

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= Exercises.Count)
            {
                Console.WriteLine();
                Console.WriteLine($"--- {Exercises[choice - 1].Name} ---");
                try
                {
                    Exercises[choice - 1].Run();
                }
                catch (NotImplementedException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"  Not implemented yet: {ex.Message}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("  Didn't understand that — enter a number from the list, or q.");
            }
        }
    }
}
