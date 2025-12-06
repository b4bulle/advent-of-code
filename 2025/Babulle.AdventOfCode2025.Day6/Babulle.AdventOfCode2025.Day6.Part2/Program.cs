using Babulle.AdventOfCode2025.Day6.Common;

var lines = File.ReadAllLines("input.txt");
ulong result = 0;
ulong current = 0;

var operand = EOperand.Plus;
for (var i = 0; i < lines[0].Length; ++i)
{
    var operandChar = lines[^1][i];
    switch (operandChar)
    {
        case '+':
            operand = EOperand.Plus;
            current = 0;
            break;
        case '*':
            operand = EOperand.Multiply;
            current = 1;
            break;
    }

    var column = lines[..^1].Select(l => l[i]).ToArray();
    if (column.Any(char.IsDigit))
    {
        var number = ulong.Parse(new string(column.Where(char.IsDigit).ToArray()));
        switch (operand)
        {
            case EOperand.Plus:
                current += number;
                break;
            case EOperand.Multiply:
                current *= number;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    else
    {
        result += current;
    }
}

result += current;

Console.WriteLine(result);