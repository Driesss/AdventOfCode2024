namespace Day4;

public static class Part1
{
    private const string Xmas = "XMAS";
    private const string Samx = "SAMX"; 
    private static readonly HashSet<(int, int)> GreenSet = [];
    
    public static int Solve(char[,] input)
    {
        var rows = input.GetLength(0);
        var cols = input.GetLength(1);
        var count = 0;
        
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (CompareHorizontal(input, row, col))
                {
                    count++;
                }
                if (CompareVertical(input, row, col))
                {
                    count++;
                }
                if (CompareForwardDiagonal(input, row, col))
                {
                    count++;
                }
                if (CompareBackwardsDiagonal(input, row, col))
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

    private static bool CompareHorizontal(char[,] input, int row, int col)
    {
        if (col + 4 > input.GetLength(1))
            return false;

        var slice = new string(new[] 
        { 
            input[row, col], 
            input[row, col + 1], 
            input[row, col + 2], 
            input[row, col + 3] 
        });
        
        if (slice is not (Xmas or Samx)) return false;
        GreenSet.Add((row, col));
        GreenSet.Add((row, col + 1));
        GreenSet.Add((row, col + 2));
        GreenSet.Add((row, col + 3));
        return true;
    }
    
    private static bool CompareVertical(char[,] input, int row, int col)
    {
        if (row + 4 > input.GetLength(0))
            return false;

        var slice = new string(new[] 
        { 
            input[row, col], 
            input[row + 1, col], 
            input[row + 2, col], 
            input[row + 3, col] 
        });

        if (slice is not (Xmas or Samx)) return false;
        GreenSet.Add((row, col));
        GreenSet.Add((row + 1, col));
        GreenSet.Add((row + 2, col));
        GreenSet.Add((row + 3, col));
        return true;
    }
    
    private static bool CompareForwardDiagonal(char[,] input, int row, int col)
    {
        if (row + 4 > input.GetLength(0) || col + 4 > input.GetLength(1))
            return false;

        var slice = new string(new[] 
        { 
            input[row, col], 
            input[row + 1, col + 1], 
            input[row + 2, col + 2], 
            input[row + 3, col + 3] 
        });

        if (slice is not (Xmas or Samx)) return false;
        GreenSet.Add((row, col));
        GreenSet.Add((row + 1, col + 1));
        GreenSet.Add((row + 2, col + 2));
        GreenSet.Add((row + 3, col + 3));
        return true;
    }
    
    private static bool CompareBackwardsDiagonal(char[,] input, int row, int col)
    {
        if (row + 4 > input.GetLength(0) || col - 3 < 0)
            return false;

        var slice = new string(new[] 
        { 
            input[row, col], 
            input[row + 1, col - 1], 
            input[row + 2, col - 2], 
            input[row + 3, col - 3] 
        });

        if (slice is not (Xmas or Samx)) return false;
        GreenSet.Add((row, col));
        GreenSet.Add((row + 1, col - 1));
        GreenSet.Add((row + 2, col - 2));
        GreenSet.Add((row + 3, col - 3));
        return true;
    }
}