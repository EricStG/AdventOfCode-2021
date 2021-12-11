var contentLines = File.ReadAllLines("input.txt");
/*
var content = @"2199943210
3987894921
9856789892
8767896789
9899965678";
var contentLines = content.Split("\r\n");
*/

var maxY = contentLines.Length - 1;
var maxX = contentLines[0].Length - 1;

var map = new Dictionary<(int Y, int X), byte>();

for (byte y = 0; y <= maxY; y++)
{
    for (byte x = 0; x <= maxX; x++)
    {
        map.Add((y, x), byte.Parse(contentLines[y][x].ToString()));
    }
}

var basinSizes = new List<int>();

bool IsValid(int y, int x)
{
    if (y >= 0 && y <= maxY && x >= 0 && x <= maxX)
    {
        if (map!.TryGetValue((y, x), out var value))
        {
            return value != 9;
        }
        return false;
    }
    return false;
}

void CheckBasin(int y, int x, ICollection<(int Y, int X)> basin)
{
    if (IsValid(y, x))
    {
        map.Remove((y, x));
        basin.Add((y, x));

        MapBasin(y, x, basin);
    }
    else
    {
        map.Remove((y, x));
    }
}

void MapBasin(int y, int x, ICollection<(int Y, int X)> basin)
{
    CheckBasin(y - 1, x, basin);
    CheckBasin(y + 1, x, basin);
    CheckBasin(y, x - 1, basin);
    CheckBasin(y, x + 1, basin);
}

while (map.Count > 0)
{
    var current = map.First();
    map.Remove(current.Key);

    if (current.Value == 9)
    {
        continue;
    }

    var basin = new List<(int Y, int X)> { ( current.Key.Y, current.Key.X )};

    MapBasin(current.Key.Y, current.Key.X, basin);
    basinSizes.Add(basin.Count);
}

var result = 1;
foreach (var basinSize in basinSizes.OrderByDescending(x => x).Take(3))
{
    result *= basinSize;
}

Console.WriteLine(result);
