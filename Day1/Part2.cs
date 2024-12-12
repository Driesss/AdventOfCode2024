public static class Part2
{
    public static int Solve(int[] inputArray1, int[] inputArray2)
    {
        // var grouped = inputArray2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        // return inputArray1.Select(x => (x, grouped.GetValueOrDefault(x, 0))).Sum(x => x.x * x.Item2);
        
        // Create a dictionary to count occurrences in inputArray2
        var counts = new Dictionary<int, int>();
        foreach (var num in inputArray2)
        {
            if (!counts.TryAdd(num, 1))
                counts[num]++;
        }

        // Calculate the sum of products
        var allCounts = 0;
        foreach (var num in inputArray1)
        {
            if (counts.TryGetValue(num, out var count))
                allCounts += num * count;
        }

        return allCounts;
        
    }
}