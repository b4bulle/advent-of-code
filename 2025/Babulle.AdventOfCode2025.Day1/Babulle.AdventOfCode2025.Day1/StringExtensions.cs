namespace Babulle.AdventOfCode2025.Day1;

public static class StringExtensions
{
    public static EDirection ParseDirection(this string str)
    {
        return str switch
        {
            "L" => EDirection.Left,
            "R" => EDirection.Right,
            _ => throw new ArgumentException("Unknown direction: " + str)
        };
    }
}