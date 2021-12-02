var content = File.ReadAllLines("input.txt");

var values = content.Select(s => int.Parse(s)).ToArray();

var count = 0;

const int size = 3;

var preSum = int.MaxValue;

for (var i = size - 1; i < values.Length; i++)
{
    var sum = values[(i - (size - 1))..(i + 1)].Sum();

    if (sum > preSum)
    {
        count++;
    }
    preSum = sum;
}

Console.WriteLine(count);
