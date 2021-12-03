var content = File.ReadAllLines("input.txt");

var cols = content[0].Length;

var counts = new (int Ones, int Zeros)[cols];

foreach (var row in content)
{
    for (var col = 0; col < cols; col++)
    {
        if (row[col] == '1')
        {
            counts[col].Ones++;
        }
        else
        {
            counts[col].Zeros++;
        }
    }
}

var gamma = new char[cols];
var epsilon = new char[cols];

for (var col = 0; col < cols; col++)
{
    var (ones, zeroes) = counts[col];

    if (ones > zeroes)
    {
        gamma[col] = '1';
        epsilon[col] = '0';
    }
    else
    {
        gamma[col] = '0';
        epsilon[col] = '1';
    }
}

var intGamma = Convert.ToInt64(new string(gamma), 2);
var intEpsilon = Convert.ToInt64(new string(epsilon), 2);

Console.WriteLine(intGamma * intEpsilon);