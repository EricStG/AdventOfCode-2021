var content = File.ReadAllText("input.txt");
var originalState = content.Split(',').Select(x => byte.Parse(x)).ToList();

const int days = 256;

var state = new long[9];

foreach (var item in originalState)
{
    state[item]++;
}

for (var day = 0; day < days; day++)
{
    var reset = state[0];
    for (var i = 1; i <= 8; i++)
    {
        state[i - 1] = state[i];
    }

    state[6] += reset;
    state[8] = reset;
}


var count = state.Sum(x => x);
Console.WriteLine(count);
