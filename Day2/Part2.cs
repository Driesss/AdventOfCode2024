namespace Day2;

public class Part2
{
    public static int Solve(int[][] input)
    {
        return input.Count(report =>
        {
            return CheckReport(report) || report.Where((t, i) => CheckReportSkip(report, i)).Any();
        });
    }
    
    private static bool CheckReportSkip(int[] report, int skipIndex)
    {
        Console.Write("{0, -30}", string.Join(" ", report) + ':');
        var increasing = false;
        var increasingIsSet = false;
        var previous = report[skipIndex == 0 ? 1 : 0];
        for (var i = skipIndex == 0 ? 2 : 1; i < report.Length; i++)
        {
            if (i == skipIndex) continue;
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