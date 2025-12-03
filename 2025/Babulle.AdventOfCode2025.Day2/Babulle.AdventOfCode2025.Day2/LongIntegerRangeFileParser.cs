namespace Babulle.AdventOfCode2025.Day2;

public static class LongIntegerRangeFileParser
{
    public static List<LongIntegerRange> Parse(string filePath)
    {
        var list = new List<LongIntegerRange>();
        var inputString = File.ReadAllText(filePath);
        var ranges = inputString.Split(',');

        foreach (var range in ranges)
        {
            var numbers = range.Split('-');
            list.Add(new LongIntegerRange(long.Parse(numbers[0]), long.Parse(numbers[1])));
        }
        
        return list;
    }
}