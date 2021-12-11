var content = File.ReadAllLines("input.txt");

var pointMap = new Dictionary<char, int>
{
    { ')', 3 },
    { ']', 57 },
    { '}', 1197 },
    { '>', 25137 },
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

var points = 0;

foreach (var line in content)
{
    var chunks = new Stack<char>();

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
            points += pointMap[x];
            break;
        }
    }
}

Console.WriteLine(points);
