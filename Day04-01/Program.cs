class Program
{
    static void Main()
    {
        var content = new Queue<string>(File.ReadAllLines("input.txt"));

        var numbers = content.Dequeue().Split(',').Select(x => Convert.ToInt32(x));

        var line = content.Dequeue();
        var grid = new List<int>(25);

        var cards = new List<Card>();

        do
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            grid.AddRange(line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)));

            if (grid.Count == 25)
            {
                cards.Add(new Card(grid));
                grid.Clear();
            }

        } while (content.TryDequeue(out line));

        foreach (var number in numbers)
        {
            foreach (var card in cards)
            {
                if (card.CheckNumber(number))
                {
                    Console.WriteLine(card.GetScore(number));
                    return;
                }
            }
        }
     }
}

class Card
{
    private (int Number, bool Marked)[,] _marks = new (int Number, bool Marked)[5,5];

    public Card(ICollection<int> numbers)
    {
        for (var i = 0; i < numbers.Count; i++)
        {
            _marks[i % 5, i / 5].Number = numbers.ElementAt(i);
        }
    }

    public bool CheckNumber(int number)
    {
        var found = false;
        for (var x = 0; x < 5; x++)
        {
            for (var y = 0; y < 5; y++)
            {
                if (_marks[x, y].Number == number)
                {
                    _marks[x, y].Marked = true;
                    found = true;
                }
            }
        }

        if (found)
        {
            for (var x = 0; x < 5; x++)
            {
                var bingo = true;
                for (var y = 0; y < 5; y++)
                {
                    bingo = bingo && _marks[x, y].Marked;
                }
                if (bingo)
                {
                    return true;
                }
            }

            for (var y = 0; y < 5; y++)
            {
                var bingo = true;
                for (var x = 0; x < 5; x++)
                {
                    bingo = bingo && _marks[x, y].Marked;
                }
                if (bingo)
                {
                    return true;
                }
            }

        }
        return false;
    }

    public int GetScore(int lastNumber)
    {
        var sum = 0;

        foreach (var mark in _marks)
        {
            if (!mark.Marked)
            {
                sum += mark.Number;
            }
        }

        return sum  * lastNumber;
    }
}
