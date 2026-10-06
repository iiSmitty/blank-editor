using System.Diagnostics;

namespace CSharpCoach.Exercises;

/// <summary>
/// Exercise 3 — "Most Frequent Word".
///
/// You're given the words from a support-ticket log, already split into an array.
/// Return the word that occurs MOST OFTEN.
/// If two or more words are tied for most occurrences, return the one whose
/// FIRST APPEARANCE in the array comes earliest.
/// Comparison is case-sensitive: "Error" and "error" are different words.
///
/// Worked examples from the spec:
///   ["apple","banana","apple","cherry","banana","apple"]  -> "apple"   (3 times)
///   ["red","blue","blue","red"]                            -> "red"     (read the tie rule carefully)
///   ["dog"]                                                -> "dog"
///
/// Constraint: real logs hold up to 1,000,000 words. Your solution must stay fast
/// at that size — there's a performance test at the bottom of Run().
///
/// Questions to pin down BEFORE you touch the keyboard (write your answers):
///   - What do you return for an empty array? (look at the return type)
///   - In the "red/blue" example, which word reaches 2 occurrences first?
///     Which word does the spec say wins? Why are those different?
///   - How many operations would your Exercise 2 approach (count every element
///     by scanning the whole array again) do for 1,000,000 words?
/// </summary>
public class Exercise03_MostFrequentWord : IExercise
{
    public string Name => "03 - Most Frequent Word";

    // ---------------------------------------------------------------------
    //  THIS is the method you implement. No AI. No autocomplete.
    //  Think for 15 minutes first: restate the problem, list inputs/outputs/
    //  constraints, list edge cases with expected answers, then the approach.
    //  We'll talk through your reasoning before any code gets written.
    //  Delete the throw and write it yourself.
    // ---------------------------------------------------------------------
    public static string? MostFrequentWord(string[] words)
    {
        if (words == null)
        {
            return null;
        }

        int bestCount = 0;
        string? bestWord = null;

        var counts = new Dictionary<string, int>();

        foreach(var word in words)
        {
            if (!counts.ContainsKey(word))
            {
                counts[word] = 1;
            }
            else
            {
                counts[word]++;
            }
        }

        foreach (var word in words)
        {
            int count = counts[word];

            if (count > bestCount)
            {
                bestCount = count;
                bestWord = word;
            }
        }
        return bestWord;
    }

    public void Run()
    {
        Check.Equal("spec: apple x3 -> apple", "apple",
            MostFrequentWord(["apple", "banana", "apple", "cherry", "banana", "apple"]));
        Check.Equal("spec: red/blue tie -> red", "red",
            MostFrequentWord(["red", "blue", "blue", "red"]));
        Check.Equal("spec: single word -> dog", "dog",
            MostFrequentWord(["dog"]));

        // Add YOUR edge-case tests here after we've discussed them.
        Check.Equal("spec: null string array -> null", null,
            MostFrequentWord([]));

        Check.Equal("spec: one element in the array -> no value/word", "",
            MostFrequentWord([""]));

        Check.Equal("spec: 5-tie breaker -> happy", "happy",
            MostFrequentWord(["happy", "sad", "angry", "thankful", "cry", "happy", "sad", "angry", "thankful", "cry"]));

        // Performance: 20,001 words. "w0".."w199" appear 100 times each, then one
        // extra "w137" at the end makes it the outright winner with 101.
        var big = new string[20_001];
        for (int i = 0; i < 20_000; i++)
            big[i] = "w" + (i % 200);
        big[20_000] = "w137";

        var timer = Stopwatch.StartNew();
        string? bigResult = MostFrequentWord(big);
        timer.Stop();

        Check.Equal("perf: 20k words -> w137", "w137", bigResult);
        Check.Equal($"perf: under 250ms (took {timer.ElapsedMilliseconds}ms)", true, timer.ElapsedMilliseconds < 250);
        Check.Summary();
    }
}
