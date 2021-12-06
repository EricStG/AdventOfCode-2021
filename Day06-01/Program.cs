var content = File.ReadAllText("input.txt");

var state = content.Split(',').Select(x => int.Parse(x)).ToList();

const int days = 80;

for (var day = 0; day < days; day++)
{
    var count = state.Count;
    for (var i = 0; i < count; i++)
    {
        var current = --state[i];
        if (current < 0)
        {
            state[i] = 6;
            state.Add(8);
        }
    }
}

Console.WriteLine(state.Count);
