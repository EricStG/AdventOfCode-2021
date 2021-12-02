var content = File.ReadAllLines("input.txt");

var horizon = 0;
var depth = 0;

foreach (var line in content)
{
    var splitLine = line.Split(' ');
    var direction = splitLine[0];
    var distance = int.Parse(splitLine[1]);

    switch (direction)
    {
        case "forward":
            horizon += distance;
            break;
        case "down":
            depth += distance;
            break;
        case "up":
            depth -= distance;
            break;
    }
}

Console.WriteLine(horizon * depth);