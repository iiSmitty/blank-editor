namespace CSharpCoach;

/// <summary>
/// A deliberately tiny self-test helper. No test framework, no magic — just enough
/// to tell you PASS/FAIL on each case so you can verify your own reasoning.
/// Read this class: it's a good example of a small, focused helper.
/// </summary>
public static class Check
{
    private static int _passed;
    private static int _failed;

    /// <summary>Assert that <paramref name="actual"/> equals <paramref name="expected"/>.</summary>
    public static void Equal<T>(string label, T expected, T actual)
    {
        bool ok = EqualityComparer<T>.Default.Equals(expected, actual);
        if (ok)
        {
            _passed++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  PASS  {label}  (got {Show(actual)})");
        }
        else
        {
            _failed++;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  FAIL  {label}  expected {Show(expected)} but got {Show(actual)}");
        }
        Console.ResetColor();
    }

    /// <summary>Call once at the end of an exercise's Run() to print a summary.</summary>
    public static void Summary()
    {
        Console.WriteLine();
        Console.ForegroundColor = _failed == 0 ? ConsoleColor.Green : ConsoleColor.Yellow;
        Console.WriteLine($"  {_passed} passed, {_failed} failed.");
        Console.ResetColor();
        _passed = 0;
        _failed = 0;
    }

    private static string Show<T>(T value) => value?.ToString() ?? "null";
}
