using Babulle.AdventOfCode2025.Day5;

var result1 = 0;

var ranges = new List<Range<long>>();

var reader = File.OpenText("input.txt");
string? line;

while (!string.IsNullOrEmpty(line = reader.ReadLine()))
{
    var values = line.Split('-');
    
    var range = new Range<long>(long.Parse(values[0]), long.Parse(values[1]));

    while(ranges.FirstOrDefault(r => r.OverlapsWith(range)) is { } overlap)
    {
        range = range.Fuse(overlap);
        ranges.Remove(overlap);
    }

    ranges.Add(range);
}

while ((line = reader.ReadLine()) != null)
{
    var ingredientId = long.Parse(line);

    if (ranges.Any(r => r.Contains(ingredientId)))
    {
        ++result1;
    }
}

var result2 = ranges.Sum(range => range.Max - range.Min + 1);

Console.WriteLine(result1);
Console.WriteLine(result2);