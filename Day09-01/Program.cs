var contentLines = File.ReadAllLines("input.txt");

var maxY = contentLines.Length - 1;
var maxX = contentLines[0].Length - 1;
                                                                                                                
var map = new byte[maxY + 1, maxX + 1];

for (var y = 0; y <= maxY; y++)
{
    for (var x = 0; x <= maxX; x++)
    {
        map[y, x] = byte.Parse(contentLines[y][x].ToString());
    }
}

var bytes = new List<byte>();

for (var y = 0; y <= maxY; y++)
{
    for (var x = 0; x <= maxX; x++)
    {
        var isLowPoint = true;

        if (x > 0)
        {
            isLowPoint = isLowPoint && map[y, x] < map[y, x - 1];
        }
        if (x < maxX)
        {
            isLowPoint = isLowPoint && map[y, x] < map[y, x + 1];
        }

        if (y > 0)
        {
            isLowPoint = isLowPoint && map[y, x] < map[y - 1, x];
        }
        if (y < maxY)
        {
            isLowPoint = isLowPoint && map[y, x] < map[y + 1, x];
        }

        if (isLowPoint)
        {
            bytes.Add(map[y, x]);
        }
    }
}

Console.WriteLine(bytes.Sum(b => b + 1));
