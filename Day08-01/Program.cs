var content = File.ReadAllLines("input.txt");

string[] GetDigits(ICollection<string> patterns)
{
    var numbers = new string[10];

    numbers[1] = patterns.Single(p => p.Length == 2);
    numbers[4] = patterns.Single(p => p.Length == 4);
    numbers[7] = patterns.Single(p => p.Length == 3);
    numbers[8] = patterns.Single(p => p.Length == 7);

    patterns.Remove(numbers[1]);
    patterns.Remove(numbers[4]);
    patterns.Remove(numbers[7]);
    patterns.Remove(numbers[8]);

    var top = numbers[7].Single(p => !numbers[1].Contains(p));

    numbers[3] = patterns.Single(p => p.Length == 5 && p.Count(c => numbers[1].Contains(c)) == 2);
    patterns.Remove(numbers[3]);

    var topLeft = numbers[4].Single(x => !numbers[3].Contains(x));

    numbers[5] = patterns.Single(p => p.Length == 5 && p.Contains(topLeft));
    numbers[2] = patterns.Single(p => p.Length == 5 && !p.Contains(topLeft));

    patterns.Remove(numbers[5]);
    patterns.Remove(numbers[2]);

    numbers[9] = patterns.Single(p => numbers[3].All(c => p.Contains(c)));
    patterns.Remove(numbers[9]);

    numbers[6] = patterns.Single(p => numbers[5].All(c => p.Contains(c)));
    patterns.Remove(numbers[6]);

    numbers[0] = patterns.Single();
    return numbers;
}

int count = 0;

foreach (var line in content)
{
    var lineSplit = line.Split('|', StringSplitOptions.TrimEntries);
    var patternsString = lineSplit[0];
    var patterns = lineSplit[0].Split(' ').ToHashSet();
    var valueString = lineSplit[1];

    var digits = GetDigits(patterns);

    var values = valueString.Split(' ');

    var digitsOfInterest = new[] { 1, 4, 7, 8 }.ToHashSet();

    foreach (var value in values)
    {
        var digit = -1;
        for (var i = 0; i < digits.Length; i++)
        {
            if (Enumerable.SequenceEqual(digits[i].OrderBy(t => t), value.OrderBy(t => t)))
            {
                digit = i;
                break;
            }
        }

        if (digitsOfInterest.Contains(digit))
        {
            count++;
        }
    }
}

Console.WriteLine(count);
