var content = File.ReadAllText("input.txt");
var originalState = content.Split(',').Select(x => int.Parse(x)).ToList();

var max = originalState.Max();

var minFuel = int.MaxValue;

for (var i = 0; i <= max; i++)
{
    var fuel = 0;

    foreach (var item in originalState)
    {
        if (i == item) continue;

        fuel += Math.Abs(i - item);
    }

    if (fuel < minFuel)
    {
        minFuel = fuel;
    }
}

Console.WriteLine(minFuel);
