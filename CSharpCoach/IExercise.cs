namespace CSharpCoach;

/// <summary>
/// Every exercise implements this so the menu in Program.cs can list and run it.
/// To add a new exercise: create a class that implements IExercise, then
/// register it in the list inside Program.cs.
/// </summary>
public interface IExercise
{
    /// <summary>Short title shown in the menu, e.g. "01 - Warmest Streak".</summary>
    string Name { get; }

    /// <summary>Runs the exercise (usually: execute your solution against its test cases).</summary>
    void Run();
}
