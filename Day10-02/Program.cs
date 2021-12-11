var content = File.ReadAllLines("input.txt");

var pointMap = new Dictionary<char, int>
{
    { ')', 1 },
    { ']', 2 },
    { '}', 3 },
    { '>', 4 },
};

var startMap = new Dictionary<char, char>
{
    { '(', ')' },
    { '[', ']' },
    { '{', '}' },
    { '<', '>' },
};

var endMap = new Dictionary<char, char>
{
    { ')', '(' },
    { ']', '[' },
    { '}', '{' },
    { '>', '<' },
};

var scores = new List<long>();

foreach (var line in content)
{
    var chunks = new Stack<char>();
    bool invalid = false;

    foreach(var x in line)
    {
        if (startMap.ContainsKey(x))
        {
            chunks.Push(x);
            continue;
        }

        var startChar = chunks.Pop();
        if (startChar != endMap[x])
        {
            invalid = true;
            break;
        }
    }

    if (invalid) continue;

    long points = 0;
    while (chunks.TryPop(out var start))
    {
        points = points * 5 + pointMap[startMap[start]];
    }

    scores.Add(points);

}

scores.Sort();

Console.WriteLine(scores[scores.Count / 2]);
