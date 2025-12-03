using Babulle.AdventOfCode2025.Day1;

var rotations = RotationFileParser.Parse(args[0]);

var safe = new Safe(50);
var clicks = 0;
foreach (var rotation in rotations)
{
    clicks += safe.ApplyRotation(rotation);
}

Console.WriteLine(clicks);