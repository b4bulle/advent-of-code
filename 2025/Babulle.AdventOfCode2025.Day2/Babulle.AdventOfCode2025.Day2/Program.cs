using System.Text.RegularExpressions;
using Babulle.AdventOfCode2025.Day2;

var rangeList = LongIntegerRangeFileParser.Parse("input.txt");

long result = 0;

foreach (var range in rangeList)
{
    var invalidIdRegex = InvalidIdRegex();
    for (var i = range.Min; i <= range.Max; ++i)
    {
        if (invalidIdRegex.IsMatch(i.ToString()))
        {
            result += i;
        }
    }
}

Console.WriteLine(result);

partial class Program
{
    [GeneratedRegex(@"^(\d+)\1+$")]
    private static partial Regex InvalidIdRegex();
}