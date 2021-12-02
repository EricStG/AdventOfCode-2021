var content = File.ReadAllLines("input.txt");

var horizon = 0;
var depth = 0;
var aim = 0;

foreach (var line in content)
{
    var splitLine = line.Split(' ');
    var direction = splitLine[0];
    var distance = int.Parse(splitLine[1]);

    switch (direction)
    {
        case "forward":
            horizon += distance;
            depth += aim * distance;
            break;
        case "down":
            aim += distance;
            break;
        case "up":
            aim -= distance;
            break;
    }
}

Console.WriteLine(horizon * depth);