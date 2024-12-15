// See https://aka.ms/new-console-template for more information

using Day4;

Console.WriteLine("Reading input...");
var grid = ReadInput("input.txt");

/*char[,] grid =
{
    {'.','M','.','S','.','.','.','.','.','.'},
    {'.','.','A','.','.','M','S','M','S','.'},
    {'.','M','.','S','.','M','A','A','.','.'},
    {'.','.','A','.','A','S','M','S','M','.'},
    {'.','M','.','S','.','M','.','.','.','.'},
    {'.','.','.','.','.','.','.','.','.','.'},
    {'S','.','S','.','S','.','S','.','S','.'},
    {'.','A','.','A','.','A','.','A','.','.'},
    {'M','.','M','.','M','.','M','.','M','.'},
    {'.','.','.','.','.','.','.','.','.','.'}
};*/

//
// Console.WriteLine("Solving part 1...");
// var result1 = Part1.Solve(grid);
// Console.WriteLine("Part 1 result: {0}", result1);

Console.WriteLine("Solving part 2...");
var result2 = Part2.Solve(grid);
Console.WriteLine("Part 2 result: {0}", result2);

return;

static char[,] ReadInput(string filename)
{
    var lines = File.ReadAllLines(filename);
    var rows = lines.Length;
    var cols = lines[0].Length;
    var input = new char[rows, cols];
    for (var row = 0; row < rows; row++)
    {
        for (var col = 0; col < cols; col++)
        {
            input[row, col] = lines[row][col];
        }
    }
    return input;
}