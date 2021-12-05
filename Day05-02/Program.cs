using System.Collections.Concurrent;

class Program
{
    static void Main()
    {
        var content = File.ReadAllLines("input.txt");

        var map = new ConcurrentDictionary<(int X, int Y), int>();

        foreach (var line in content)
        {
            var splitLine = line.Split("->", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var srcString = splitLine[0].Split(',');
            var src = (X: int.Parse(srcString[0]), Y: int.Parse(srcString[1]));

            var destString = splitLine[1].Split(',');
            var dest = (X: int.Parse(destString[0]), Y: int.Parse(destString[1]));

            if (src.X == dest.X)
            {
                var min = Math.Min(src.Y, dest.Y);
                var max = Math.Max(src.Y, dest.Y);

                for (var i = min; i <= max; i++)
                {
                    map.AddOrUpdate((src.X, i), 1, (_, x) => x + 1);
                }
            }
            else if (src.Y == dest.Y)
            {
                var min = Math.Min(src.X, dest.X);
                var max = Math.Max(src.X, dest.X);

                for (var i = min; i <= max; i++)
                {
                    map.AddOrUpdate((i, src.Y), 1, (_, x) => x + 1);
                }
            }
            else
            {
                var xs = GetRange(src.X, dest.X);
                var ys = GetRange(src.Y, dest.Y);

                var points = xs.Zip(ys);

                foreach (var point in points)
                {
                    map.AddOrUpdate((point.First, point.Second), 1, (_, v) => v + 1);
                }
            }
        }

        var print = false;

        if (print)
        {
            var maxX = map.Max(x => x.Key.X);
            var maxY = map.Max(x => x.Key.Y);

            for (var y = 0; y <= maxY; y++)
            {
                for (var x = 0; x <= maxX; x++)
                {
                    if (map.TryGetValue((x, y), out var p))
                    {
                        Console.Write(p);
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        var overlaps = map.Count(x => x.Value >= 2);
        Console.WriteLine(overlaps);
    }

    private static IEnumerable<int> GetRange(int start, int stop)
    {
        if (start <= stop)
        {
            return Enumerable.Range(start, stop - start + 1);
        }
        else
        {
            return Enumerable.Range(stop, start - stop + 1).Reverse();
        }
    }
}