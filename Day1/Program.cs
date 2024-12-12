// See https://aka.ms/new-console-template for more information

Console.WriteLine("reading in file");

var (list1, list2) = ReadListsFromFile("input.txt");

Console.WriteLine("Ordering lists");

var orderedList1 = list1.OrderBy(x => x).ToList();
var orderedList2 = list2.OrderBy(x => x).ToList();

Console.WriteLine("Zipping lists");

var zipped = orderedList1.Zip(orderedList2, (x, y) => (x, y, Math.Abs(x - y))).ToList();

zipped.ForEach(x => Console.WriteLine("{0} - {1}: {2}", x.x, x.y, x.Item3));

Console.WriteLine("Adding entries");
var result = zipped.Sum(x => x.Item3);

Console.WriteLine("Result: {0}", result);



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
