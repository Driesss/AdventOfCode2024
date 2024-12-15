using System.Text.RegularExpressions;

namespace Day3;

public static partial class Part1
{
    public static int Solve(string input)
    {
        // Define the regex pattern to match "mul(x,y)" where x and y are 1-3 digit numbers
        const string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        
        // Initialize a list to store the extracted x and y values
        var results = new List<(int x, int y)>();
        
        // Perform the regex match
        var matches = MyRegex().Matches(input);

        foreach (Match match in matches)
        {
            Console.WriteLine("{0} - {1} - {2}",match.Groups[0].Value, match.Groups[1].Value, match.Groups[2].Value);
        }
        
        var result = matches.Select(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value)).Sum();
        
        return result;
    }

    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)")]
    private static partial Regex MyRegex();
}