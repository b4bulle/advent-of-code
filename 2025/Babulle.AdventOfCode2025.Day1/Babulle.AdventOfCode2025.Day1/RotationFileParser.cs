using System.Text.RegularExpressions;

namespace Babulle.AdventOfCode2025.Day1;

public partial class RotationFileParser
{
    public static List<Rotation> Parse(string filePath)
    {
        var rotations = new List<Rotation>();
        var parsingExpression = RotationParsingRegex();
        using var reader = new StreamReader(File.OpenRead(filePath));
        while(reader.ReadLine() is { } line)
        {
            var match = parsingExpression.Match(line);

            if (!match.Success) continue;
            var direction = match.Groups[1].Value.ParseDirection();
            var ticks = int.Parse(match.Groups[2].Value);
            rotations.Add(new Rotation(direction, ticks));
        }
        
        return rotations;
    }

    [GeneratedRegex(@"(L|R)(\d*)")]
    private static partial Regex RotationParsingRegex();
}
