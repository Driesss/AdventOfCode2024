// See https://aka.ms/new-console-template for more information

using Day2;

Console.WriteLine("Reading input file...");
var input = ReadFile("input.txt");

Console.WriteLine("Calculating part1");
var result1 = Part1.Solve(input);

Console.WriteLine("Part1 result: {0}", result1);


Console.WriteLine("Calculating part2");
var result2 = Part2.Solve(input);

Console.WriteLine("Part2 results: {0}", result2);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
return;



static int[][] ReadFile(string filePath)
{
    var lines = File.ReadAllLines(filePath); // Read all lines from the file
    var jaggedArray = new int[lines.Length][];

    for (var i = 0; i < lines.Length; i++)
    {
        // Split the line by spaces and convert to integers
        jaggedArray[i] = lines[i]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }

    return jaggedArray;
}