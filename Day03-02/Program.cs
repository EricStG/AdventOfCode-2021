class Program
{
    static void Main()
    {

        var content = File.ReadAllLines("input.txt");
        
        var o2gen = FindTarget(content, false);
        var co2scrub = FindTarget(content, true);

        Console.WriteLine(Convert.ToInt64(o2gen, 2) * Convert.ToInt64(co2scrub, 2));
    }

    private static string FindTarget(string[] content, bool reverseTarget)
    {
        var col = 0;

        while (content.Length > 1)
        {
            var oneCount = 0;
            var zeroCount = 0;

            foreach (var line in content)
            {
                if (line[col] == '0')
                {
                    zeroCount++;
                }
                else
                {
                    oneCount++;
                }
            }

            var target = oneCount >= zeroCount ^ reverseTarget? '0' : '1';
            content = content.Where(c => c[col] == target).ToArray();
            col++;
        }

        return content[0];
    }
}
