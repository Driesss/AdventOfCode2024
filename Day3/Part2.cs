using System.Data;
using System.Text.RegularExpressions;

namespace Day3;

public static partial class Part2
{
    public static int Solve(string input)
    {
        // Perform the regex match
        var matches = MyRegex().Matches(input);

        // foreach (Match match in matches)
        // {
        //     Console.WriteLine("{0} - {1} - {2}",match.Groups[0].Value, match.Groups[1].Value, match.Groups[2].Value);
        // }

        var result = matches.DoDont().Sum();
        
        return result;
    }

    private static IEnumerable<int> DoDont(this MatchCollection input)
    {
        var doMul = true;
        var originalColor = Console.ForegroundColor;
        foreach (Match match in input)
        {
            var command = match.Groups[0].Value;
            switch (command)
            {
                case "do()":
                    Console.WriteLine("do()");
                    doMul = true;
                    break;
                case "don't()":
                    Console.WriteLine("don't()");
                    doMul = false;
                    break;
                default:
                    Console.ForegroundColor = doMul ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine("{0} - {1} - {2}",match.Groups[0].Value, match.Groups[1].Value, match.Groups[2].Value);
                    Console.ForegroundColor = originalColor;
                    if (!doMul) continue;
                    var x = int.Parse(match.Groups[1].Value);
                    var y = int.Parse(match.Groups[2].Value);
                    yield return x * y;
                    break;
            }
        }
    }
    

    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)")]
    private static partial Regex MyRegex();
}