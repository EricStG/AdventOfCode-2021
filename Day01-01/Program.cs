var content = File.ReadAllLines("input.txt");

var values = content.Select(s => int.Parse(s)).ToArray();

var count = 0;

for (var i = 1; i < values.Length; i++)
{
    if (values[i] > values[i-1])
    {
        count++;
    }
}

Console.WriteLine(count);
