// See https://aka.ms/new-console-template for more information

using Day3;

Console.WriteLine("Reading input...");
var input = File.ReadAllText("input.txt");

// Console.WriteLine("Solving part1");
// var result1 = Part1.Solve(input);
// Console.WriteLine("Result 1: {0}", result1);

Console.WriteLine("Solving part2");
var result2 = Part2.Solve(input);
Console.WriteLine("Result 2: {0}", result2);
