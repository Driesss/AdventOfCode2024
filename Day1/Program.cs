// See https://aka.ms/new-console-template for more information

using AdventOfCode;

Console.WriteLine("reading in file");

var input1 = ReadListsFromFile("input.txt");

var result1 = Part1.Solve(input1.array1, input1.array2);

Console.WriteLine("Result1: {0}", result1);

var result2 = Part2.Solve(input1.array1, input1.array2);

Console.WriteLine("Result2: {0}", result2);


Console.WriteLine("press any key to exit...");
Console.ReadKey();
return;


(int[] array1, int[] array2) ReadListsFromFile(string inputTxt)
{
    using var fs = File.OpenRead(inputTxt);
    using var reader = new StreamReader(fs);
    var list1 = new List<int>();
    var list2 = new List<int>();
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        if (line == null) break;
        var values = line.Split("   ");
        list1.Add(int.Parse(values[0]));
        list2.Add(int.Parse(values[1]));
    }
    return (list1.ToArray(), list2.ToArray());
}