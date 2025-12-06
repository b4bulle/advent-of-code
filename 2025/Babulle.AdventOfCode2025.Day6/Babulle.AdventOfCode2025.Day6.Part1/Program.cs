using System.Text.RegularExpressions;
using Babulle.AdventOfCode2025.Day6.Common;

ulong result = 0;

var lines = File.ReadAllLines("input.txt");

var numberLines = new List<List<ulong>>();

var numbersRegex = NumbersRegex();

for (var i = 0; i < lines.Length - 1; ++i)
{
    numberLines.Add([]);
    foreach (var number in numbersRegex.Matches(lines[i]))
    {
        numberLines[i].Add(ulong.Parse(number.ToString()!));
    }
}

var operandsRegex = OperandsRegex();

var operands = new List<EOperand>();
foreach (var operand in operandsRegex.Matches(lines[^1]))
{
    operands.Add(operand.ToString() switch
    {
        "+" => EOperand.Plus,
        "*" => EOperand.Multiply,
        _ => throw new Exception($"Unknown operand {operand}")
    });
}

for (var i = 0; i < operands.Count; ++i)
{
    result += operands[i] switch
    {
        EOperand.Plus => numberLines.Select(l => l[i]).Aggregate((a, b) => a + b),
        EOperand.Multiply => numberLines.Select(l => l[i]).Aggregate((a, b) => a * b),
        _ => throw new ArgumentOutOfRangeException()
    };
}

Console.WriteLine(result);

partial class Program
{
    [GeneratedRegex(@"(\*|\+)")]
    private static partial Regex OperandsRegex();
    
    [GeneratedRegex(@"(\d+)")]
    private static partial Regex NumbersRegex();
}