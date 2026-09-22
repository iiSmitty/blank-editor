namespace CSharpCoach.Exercises;

/// <summary>
/// Exercise 2 — "First Unique Character".
///
/// Given a string, return the ZERO-BASED INDEX of the first character that
/// appears EXACTLY ONCE in the whole string.
/// If no character appears exactly once, return -1.
///
/// Worked examples from the spec:
///   "leetcode"      -> 0   ('l' is the first char that occurs only once)
///   "loveleetcode"  -> 2   ('v' is the first char that occurs only once)
///   "aabb"          -> -1  (every character repeats)
///
/// Questions to pin down BEFORE you touch the keyboard (write your answers):
///   - What do you return for the empty string ""?
///   - Is 'A' the same character as 'a'? (case-sensitive or not — you decide, then commit)
///   - Do spaces count as characters?
/// </summary>
public class Exercise02_FirstUniqueChar : IExercise
{
    public string Name => "02 - First Unique Character";

    // ---------------------------------------------------------------------
    //  THIS is the method you implement. No AI. No autocomplete.
    //  Think for 15 minutes first: restate the problem, list inputs/outputs/
    //  constraints, list edge cases with expected answers, then the approach.
    //  We'll talk through your reasoning before any code gets written.
    //  Delete the throw and write it yourself.
    // ---------------------------------------------------------------------
    public static int FirstUniqueCharIndex(string text)
    {

        string lowercase = text.ToLower();

        for (int i = 0; i < lowercase.Length; i++)
        {
            int count = 0;

            for (int j = 0; j < lowercase.Length; j++)
            {
                if (lowercase[j] == lowercase[i])
                {
                    count++;
                }
            }
            if (count == 1)
            {
                return i;
            }
        }
        return -1;
    }

    public void Run()
    {
        // One spec example is wired so the file compiles and runs.
        // Add YOUR edge-case tests here after we've discussed them
        // (empty string, all-repeating, single char, whatever else you find).
        Check.Equal("spec: leetcode -> 0",      0, FirstUniqueCharIndex("leetcode"));
        Check.Equal("spec: loveleetcode -> 2",  2, FirstUniqueCharIndex("loveleetcode"));
        Check.Equal("spec: aabb -> -1",        -1, FirstUniqueCharIndex("aabb"));
        Check.Equal("spec: empty -> -1",       -1, FirstUniqueCharIndex(""));
        Check.Equal("spec: a b -> 0",           0, FirstUniqueCharIndex("a b"));
        Check.Equal("spec: aAbB -> -1",        -1, FirstUniqueCharIndex("aAbB"));
        Check.Summary();
    }
}
