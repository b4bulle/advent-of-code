var result = 0L;
const int n = 12;

foreach (var line in File.ReadAllLines("input.txt"))
{
    var maxNumbers = new int[n];
    var maxDigitFirstIndex = -1;
    for (var i = 0; i < n; i++)
    {
        var maxIndex = 0;
        for (var j = line.Length - (n - i); j >= maxDigitFirstIndex + 1; j--)
        {
            var digit = int.Parse(line.Substring(j, 1));
            if (digit >= maxNumbers[i])
            {
                maxNumbers[i] = digit;
                maxIndex = j;
            }
        }
        
        maxDigitFirstIndex = maxIndex;
    }

    for (var i = 0; i < n; i++)
    {
        result += maxNumbers[i] * (long) Math.Pow(10, n - 1 - i);
    }
}

Console.WriteLine(result);