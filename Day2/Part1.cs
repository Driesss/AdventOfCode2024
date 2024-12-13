namespace Day2;

public class Part1
{
    public static int Solve(int[][] input)
    {
        return input.Count(CheckReport);
    }

    private static bool CheckReport(int[] report)
    {
        Console.Write("{0, -30}", string.Join(" ", report) + ':');
        var increasing = false;
        var increasingIsSet = false;
        var previous = report[0];
        for (var i = 1; i < report.Length; i++)
        {
            var level = report[i];
            var change = previous - level;
            if (Math.Abs(change) is 0 or > 3)
            {
                Console.WriteLine("Change out of range: {0} - {1} = {2}", previous, level, change);
                return false;
            }
            
            var currentlyIncreasing = change < 0;
            
            if (!increasingIsSet)
            {
                increasing = currentlyIncreasing;
                increasingIsSet = true;
                previous = level;
                continue;
            }

            if (currentlyIncreasing != increasing)
            {
                Console.WriteLine("prev {0} - current {1}", increasing, currentlyIncreasing);
                return false;
            }
            
            previous = level;
        }
        Console.WriteLine("OK");
        return true;
    }
}