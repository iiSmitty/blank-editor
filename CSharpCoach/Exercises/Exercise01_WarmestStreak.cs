namespace CSharpCoach.Exercises;

/// <summary>
/// Exercise 1 — "Warmest Streak".
///
/// Return the LENGTH of the longest run of consecutive readings during which the
/// temperature STRICTLY increased (each reading strictly greater than the one before it).
///
/// Worked example from the spec:
///   [1, 2, 3, 2, 4, 5, 6, 1]  ->  the run 2,4,5,6 has length 4  ->  returns 4
///
/// Assumption you chose (write it down, it resolves the ambiguity):
///   If the temperature never increases anywhere, return 0.
///   (So a single reading, an all-decreasing list, and an all-equal list all return 0.)
/// </summary>
public class Exercise01_WarmestStreak : IExercise
{
    public string Name => "01 - Warmest Streak";

    // ---------------------------------------------------------------------
    //  THIS is the method you implement. No AI. No autocomplete.
    //  You already worked out the plan:
    //    - walk the list once
    //    - keep two ints: the best run so far, and the current run
    //    - decide what each starts at before the loop
    //  Delete the throw and write it yourself.
    // ---------------------------------------------------------------------
    public static int LongestIncreasingRun(List<int> readings)
    {
        int longest = 0;
        int current = 0;

        for (int i = 0; i < readings.Count - 1; i++)
        {
            if (readings[i + 1] > readings[i])
                current++;
            else
                current = 0;

            longest = Math.Max(longest, current);
        }
        return longest == 0 ? 0 : longest + 1; // the longest + 1 is for count the first reading[i] that was not counted
    }

    // Your five test cases (from the reasoning we did together).
    // Run the app, pick this exercise, and watch them go green.
    public void Run()
    {
        Check.Equal("empty list",              0, LongestIncreasingRun(new List<int>()));
        Check.Equal("single reading [42]",     0, LongestIncreasingRun(new List<int> { 42 }));
        Check.Equal("all decreasing",          0, LongestIncreasingRun(new List<int> { 9, 7, 5, 3 }));
        Check.Equal("all equal [5,5,5]",       0, LongestIncreasingRun(new List<int> { 5, 5, 5 }));
        Check.Equal("spec example -> 4",       4, LongestIncreasingRun(new List<int> { 1, 2, 3, 2, 4, 5, 6, 1 }));
        Check.Summary();
    }
}
