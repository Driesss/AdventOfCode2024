namespace AdventOfCode;

public static class Part1
{
    public static int Solve(int[] list1, int[] list2)
    {
        Console.WriteLine("Ordering lists");

        var orderedList1 = list1.OrderBy(x => x).ToList();
        var orderedList2 = list2.OrderBy(x => x).ToList();

        Console.WriteLine("Zipping lists");

        var zipped = orderedList1.Zip(orderedList2, (x, y) => (x, y, Math.Abs(x - y))).ToList();

        zipped.ForEach(x => Console.WriteLine("{0} - {1}: {2}", x.x, x.y, x.Item3));

        Console.WriteLine("Adding entries");
        return zipped.Sum(x => x.Item3);
    }
}