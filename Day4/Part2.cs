namespace Day4;

public static class Part2
{
    private const string Mas = "MAS";
    private const string Sam = "SAM"; 
    private static readonly HashSet<(int, int)> GreenSet = [];
    
    public static int Solve(char[,] input)
    {
        var rows = input.GetLength(0);
        var cols = input.GetLength(1);
        var count = 0;
        
        for (var row = 0; row < rows - 2; row++)
        {
            for (var col = 0; col - 2 < cols; col++)
            {
                if (CompareX(input, row, col))
                {
                    count++;
                }
            }
        }

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (GreenSet.Contains((row, col))) Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(input[row, col]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        
        return count;
        
    }

    private static bool CompareX(char[,] input, int row, int col)
    {
        if (col + 3 > input.GetLength(1) || row + 3 > input.GetLength(0))
            return false;

        // \
        var slice1 = new string(new[] 
        { 
            input[row, col], 
            input[row + 1, col + 1], 
            input[row + 2, col + 2], 
        });
        
        // /
        var slice2 = new string(new[] 
        { 
            input[row + 2, col], 
            input[row + 1, col + 1], 
            input[row , col + 2], 
        });

        if (slice1 is Mas or Sam && slice2 is Mas or Sam)
        {
            GreenSet.Add((row, col));
            GreenSet.Add((row + 1, col + 1));
            GreenSet.Add((row + 2, col + 2));
            GreenSet.Add((row + 2, col));
            GreenSet.Add((row + 1, col + 1));
            GreenSet.Add((row, col + 2));
            return true;
        }
        return false;


        // if (slice is not (Xmas or Samx)) return false;
        // GreenSet.Add((row, col));
        // GreenSet.Add((row, col + 1));
        // GreenSet.Add((row, col + 2));
        // GreenSet.Add((row, col + 3));
        // return true;
    }
}